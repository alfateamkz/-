using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.BusinessProposals;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.API.Models.DTO.Invoices.Kanban;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.API.Models.Kanban;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.Orders;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers
{
    public class SaleFunnelsController : AbsController
    {
        public SaleFunnelsController(ControllerParams @params) : base(@params)
        {
        }


        #region Воронки продаж

        [HttpGet, Route("GetSaleFunnels")]
        public async Task<ItemsWithTotalCount<SalesFunnelDTO>> GetSaleFunnels(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<SalesFunnel, SalesFunnelDTO>(GetAvailableSalesFunnels(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetSaleFunnel")]
        public async Task<SalesFunnelDTO> GetSaleFunnel(int id)
        {
            return (SalesFunnelDTO)DBService.TryGetOne(GetAvailableSalesFunnels(), id, new SalesFunnelDTO());
        }


        [HttpPost, Route("CreateSaleFunnel")]
        public async Task<SalesFunnelDTO> CreateSaleFunnel(SalesFunnelDTO model)
        {
            return (SalesFunnelDTO)DBService.TryCreateEntity(DB.SalesFunnels, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                AddDefaultFunnelStages(entity);
            }, 
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление воронки продаж", $"Добавлена воронка продаж {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateSaleFunnel")]
        public async Task<SalesFunnelDTO> UpdateSaleFunnel(SalesFunnelDTO model)
        {
            var item = GetAvailableSalesFunnels().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (SalesFunnelDTO)DBService.TryUpdateEntity(DB.SalesFunnels, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование воронки продаж", $"Отредактирована воронка продаж с id={entity.Id}");
            });
        }





        [HttpDelete, Route("DeleteSaleFunnel")]
        public async Task DeleteSaleFunnel(int id)
        {
            var item = GetAvailableSalesFunnels().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.SalesFunnels, item);

            this.AddHistoryAction("Удаление воронки продаж", $"Удалена воронка продаж {item.Title} с id={id}");
        }

        #endregion

        #region Этапы воронок продаж

        [HttpPost, Route("CreateSaleFunnelStage")]
        public async Task<SalesFunnelStageDTO> CreateSaleFunnelStage(int funnelId, int stageAfterId, SalesFunnelStageDTO model)
        {
            var funnel = TryGetSalesFunnel(funnelId);
            if(TryGetFunnelStage(stageAfterId).SalesFunnelId != funnelId)
            {
                throw new Exception403("Этап не принадлежит текущей воронке продаж");
            }
            else if (!model.IsValid())
            {
                throw new Exception400("Проверьте корректность заполнения полей");
            }

            var stageEntity = model.CreateDBModelFromDTO();
            funnel.InsertStage(stageAfterId, stageEntity);
            DBService.UpdateEntity(DB.SalesFunnels, funnel);

            this.AddHistoryAction("Добавление этапа воронки продаж", $"Добавлен этап воронки продаж {stageEntity.Title}");
            return (SalesFunnelStageDTO)new SalesFunnelStageDTO().CreateDTO(stageEntity);
        }

        [HttpPut, Route("UpdateSaleFunnelStage")]
        public async Task<SalesFunnelStageDTO> UpdateSaleFunnelStage(SalesFunnelStageDTO model)
        {
            var item = TryGetFunnelStage(model.Id);
            return (SalesFunnelStageDTO)DBService.TryUpdateEntity(DB.SalesFunnelStages, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование этапа воронки продаж", $"Отредактирован этап воронки продаж с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteSaleFunnelStage")]
        public async Task DeleteSaleFunnelStage(int id)
        {
            var item = TryGetFunnelStage(id);

            if (item.IsSystemStage)
            {
                throw new Exception403("Невозможно удалить системную стадию");
            }
            else if (GetAvailableOrders(item.SalesFunnelId).Where(o => o.SaleInfo.FunnelStageId == id).Any())
            {
                throw new Exception400("Этап воронки продаж не пустой");
            }

            DBService.TryDeleteEntity(DB.SalesFunnelStages, item);
            this.AddHistoryAction("Удаление этапа воронки продаж", $"Удален этап воронки продаж {item.Title} с id={id}");
        }

        #endregion

        #region Карточки в канбане

        [HttpGet, Route("GetFunnelItems")]
        public async Task<KanbanClientModel<OrderDTO>> GetFunnelItems(int funnelId)
        {
            var funnel = DBService.TryGetOne(GetAvailableSalesFunnels(), funnelId);
            var orders = GetAvailableOrders(funnelId);


            var clientModel = new KanbanClientModel<OrderDTO>();

            foreach (var stage in funnel.Stages)
            {
                var items = orders.Where(o => o.SaleInfo.FunnelStageId == stage.Id);

                clientModel.Stages.Add(new KanbanStageClientModel<OrderDTO>
                {
                    StageId = stage.Id,
                    Items = new OrderDTO().CreateDTOs(items).Cast<OrderDTO>()
                });
            }

            return clientModel;
        }

        [HttpPut, Route("SetFunnelItemStage")]
        public async Task SetFunnelItemStage(int orderId, int funnelId, int stageId)
        {
            var order = DBService.TryGetOne(GetAvailableOrders(), orderId);
            TryGetFunnelStage(stageId);

            order.SaleInfo.FunnelStageId = stageId;
            DBService.UpdateEntity(DB.Orders, order);
        }

        #endregion










        #region Private sale funnels methods

        private IEnumerable<SalesFunnel> GetAvailableSalesFunnels()
        {
            return DB.SalesFunnels.Include(o => o.Stages)
                                  .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        private SalesFunnel TryGetSalesFunnel(int funnelId)
        {
            return DBService.TryGetOne(GetAvailableSalesFunnels(), funnelId);
        }
        private void ThrowIfFunnelDontExist(int funnelId)
        {
            TryGetSalesFunnel(funnelId);
        }



        private void AddDefaultFunnelStages(SalesFunnel entity)
        {
            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.NewOrder,
                Title = "Новый",
                TextHexColor = "#07141C",
                BGHexColor = "#39A8EF",
                IsSystemStage = true,
            });
            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.InWork,
                Title = "Подготовка документов",
                TextHexColor = "#07141C",
                BGHexColor = "#2FC6F6",
                IsSystemStage = false,
            });
            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.InWork,
                Title = "Cчёт на предоплату",
                TextHexColor = "#07141C",
                BGHexColor = "#55D0E0",
                IsSystemStage = false,
            });
            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.InWork,
                Title = "В работе",
                TextHexColor = "#07141C",
                BGHexColor = "#47E4C2",
                IsSystemStage = false,
            });
            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.InWork,
                Title = "Финальный счёт",
                TextHexColor = "#07141C",
                BGHexColor = "#FFA900",
                IsSystemStage = false,
            });



            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.OrderLost,
                Title = "Сделка провалена",
                TextHexColor = "#FFFFFF",
                BGHexColor = "#FF5752",
                IsSystemStage = true,
            });
            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.OrderLost,
                Title = "Анализ причины провала",
                TextHexColor = "#FFFFFF",
                BGHexColor = "#FF5752",
                IsSystemStage = false,
            });
            entity.Stages.Add(new SalesFunnelStage
            {
                Status = SalesFunnelStageStatus.OrderClosed,
                Title = "Сделка успешна",
                TextHexColor = "#07141C",
                BGHexColor = "#7BD500",
                IsSystemStage = true,
            });
        }

        private SalesFunnelStage TryGetFunnelStage(int stageId)
        {
            var stage = DBService.TryGetOne(DB.SalesFunnelStages, stageId);
            if(!GetAvailableSalesFunnels().Any(o => o.Id == stage.SalesFunnelId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return stage;
        }

        #endregion

        #region Private order methods
        private IEnumerable<Order> GetAvailableOrders()
        {
            return DB.Orders.Include(o => o.SaleInfo).ThenInclude(o => o.FunnelStage)
                            .Include(o => o.SaleInfo).ThenInclude(o => o.Funnel)
                            .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<Order> GetAvailableOrders(int funnelId)
        {
            return GetAvailableOrders().Where(o => o.SaleInfo.FunnelId == funnelId);
        }
        
        #endregion
    }
}
