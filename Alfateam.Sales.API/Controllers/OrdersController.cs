﻿using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Sales.API.Controllers
{
    public class OrdersController : AbsController
    {
        public OrdersController(ControllerParams @params) : base(@params)
        {
        }


        #region Заказы

        [HttpGet, Route("GetOrders")]
        public async Task<ItemsWithTotalCount<OrderDTO>> GetOrders(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Order, OrderDTO>(GetAvailableOrders(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetOrder")]
        public async Task<OrderDTO> GetOrder(int id)
        {
            return (OrderDTO)DBService.TryGetOne(GetAvailableOrders(), id, new OrderDTO());
        }


        [HttpPost, Route("CreateOrder")]
        public async Task<OrderDTO> CreateOrder(OrderDTO model)
        {
            var user = this.AuthorizedUser;

            return (OrderDTO)DBService.TryCreateEntity(DB.Orders, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                entity.SaleInfo = new OrderSaleInfo()
                {
                    FoundById = user.Id,
                    ResponsibleId = user.Id,
                };
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление заказа", $"Добавлен заказ {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateOrder")]
        public async Task<OrderDTO> UpdateOrder(OrderDTO model)
        {
            var item = GetAvailableOrders().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (OrderDTO)DBService.TryUpdateEntity(DB.Orders, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование заказа", $"Отредактирован заказ с id={entity.Id}");
            });
        }



        [HttpDelete, Route("DeleteOrder")]
        public async Task DeleteOrder(int id)
        {
            var item = GetAvailableOrders().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Orders, item);

            this.AddHistoryAction("Удаление заказа", $"Удален заказ {item.Title} с id={id}");
        }

        #endregion

        #region Статусы заказов

        [HttpGet, Route("GetOrderStatuses")]
        public async Task<ItemsWithTotalCount<OrderStatusDTO>> GetOrderStatuses(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<OrderStatus, OrderStatusDTO>(GetAvailableOrderStatuses(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetOrderStatus")]
        public async Task<OrderStatusDTO> GetSaleFunnelStageType(int id)
        {
            return (OrderStatusDTO)DBService.TryGetOne(GetAvailableOrderStatuses(), id, new OrderStatusDTO());
        }




        [HttpPost, Route("CreateOrderStatus")]
        public async Task<OrderStatusDTO> CreateOrderStatus(OrderStatusDTO model)
        {
            return (OrderStatusDTO)DBService.TryCreateEntity(DB.OrderStatuses, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                entity.Type = OrderStatusType.Custom;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление пользовательского статуса заказа", $"Добавлен статуса заказа {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateOrderStatus")]
        public async Task<OrderStatusDTO> UpdateOrderStatus(OrderStatusDTO model)
        {
            var item = GetAvailableOrderStatuses().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (OrderStatusDTO)DBService.TryUpdateEntity(DB.OrderStatuses, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование пользовательского статуса заказа", $"Отредактирован статуса заказа с id={entity.Id}");
            });
        }



        [HttpDelete, Route("DeleteOrderStatus")]
        public async Task DeleteOrderStatus(int id)
        {
            var item = GetAvailableOrderStatuses().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item.IsDefault)
            {
                throw new Exception403("Нельзя удалить встроенный статус заказа. Можно только редактировать текст");
            }

            DBService.TryDeleteEntity(DB.OrderStatuses, item);
            this.AddHistoryAction("Удаление пользовательского статуса заказа", $"Удален статуса заказа {item.Title} с id={id}");
        }

        #endregion



        #region Управление заказами (не круд, а бизнес процессы)





        #endregion







        #region Private methods
        private IEnumerable<Order> GetAvailableOrders()
        {
            return DB.Orders.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<OrderStatus> GetAvailableOrderStatuses()
        {
            return DB.OrderStatuses.Where(o => !o.IsDeleted && (o.BusinessCompanyId == this.CompanyId || o.IsDefault));
        }


        #endregion
    }
}
