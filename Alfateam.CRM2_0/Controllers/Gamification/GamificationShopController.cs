using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.Shop;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.Shop.Order;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.Shop;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.Shop.Order;
using Alfateam.CRM2_0.Models.EditModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.EditModels.Gamification.Shop;
using Alfateam.CRM2_0.Models.EditModels.Gamification.Shop.Order;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Achievements;
using Alfateam.CRM2_0.Models.Gamification.Shop;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Gamification
{
    public class GamificationShopController : AbsGamificationController
    {
        public GamificationShopController(ControllerParams @params) : base(@params)
        {
        }


        #region Товары

        [HttpGet, Route("GetShopItems")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetShopItems(int offset, int count = 20)
        {
            var queryable = DB.ShopItems.Include(o => o.Category)
                                        .Where(o => o.GamificationModelId == this.GetGamificationId());

            return DBService.GetMany<ShopItem, ShopItemClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetShopItem")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetShopItem(int id)
        {
            var item = DB.ShopItems.Include(o => o.Category)
                                   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopItem(item),
                () => RequestResult<ShopItem>.AsSuccess(item)
            });
        }




        [HttpPost, Route("CreateShopItem")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> CreateShopItem(ShopItemCreateModel model)
        {
            var category = DB.ShopCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopCategory(category),
                () => DBService.TryCreateModel(DB.ShopItems, model, (item) =>
                {
                    var imgUploadResult = FileService.TryUploadFile("imgPath", Enums.FileType.Image).Result;
                    if (!imgUploadResult.Success)
                    {
                        return imgUploadResult;
                    }
                    item.ImagePath = imgUploadResult.Value;

                    item.GamificationModelId = (int)this.GetGamificationId();
                    return RequestResult<ShopItem>.AsSuccess(item);
                })
            });
        }

        [HttpPut, Route("UpdateShopItem")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> UpdateShopItem(ShopItemEditModel model)
        {
            var item = DB.ShopItems.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var category = DB.ShopCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopItem(item),
                () => CheckBaseShopCategory(category),
                () =>
                {
                    if(Request.Form.Files.Any(o => o.Name == "imgPath"))
                    {
                        var imgUploadResult = FileService.TryUploadFile("imgPath",Enums.FileType.Image).Result;
                        if (!imgUploadResult.Success)
                        {
                            return imgUploadResult;
                        }
                        item.ImagePath = imgUploadResult.Value;
                    }
                    return DBService.TryUpdateModel(DB.ShopItems, item, model);
                }
            });
        }

        [HttpDelete, Route("DeleteShopItem")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> DeleteShopItem(int id)
        {
            var item = DB.ShopItems.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopItem(item),
                () => DBService.DeleteModel(DB.ShopItems, item)
            });
        }

        #endregion

        #region Категории товаров

        [HttpGet, Route("GetShopCategories")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetShopCategories(int offset, int count = 20)
        {
            var queryable = DB.ShopCategories.Where(o => o.GamificationModelId == this.GetGamificationId());
            return DBService.GetMany<ShopCategory, ShopCategoryClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetShopCategory")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetShopCategory(int id)
        {
            var category = DB.ShopCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopCategory(category),
                () => RequestResult<ShopCategory>.AsSuccess(category)
            });
        }



        [HttpPost, Route("CreateShopCategory")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> CreateShopCategory(ShopCategoryCreateModel model)
        {
            return DBService.TryCreateModel(DB.ShopCategories, model, (item) =>
            {
                item.GamificationModelId = (int)this.GetGamificationId();
                return RequestResult<ShopCategory>.AsSuccess(item);
            });
        }

        [HttpPut, Route("UpdateShopCategory")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> UpdateShopCategory(ShopCategoryEditModel model)
        {
            var category = DB.ShopCategories.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopCategory(category),
                () => DBService.TryUpdateModel(DB.ShopCategories, category, model)
            });
        }

        [HttpDelete, Route("DeleteShopCategory")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> DeleteShopCategory(int id)
        {
            var category = DB.ShopCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopCategory(category),
                () => DBService.DeleteModel(DB.ShopCategories, category)
            });
        }

        #endregion

        #region Заказы (Админ)

        [HttpGet, Route("GetOrders")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> GetOrders(ShopOrderStatus status, int offset, int count = 20)
        {
            var queryable = DB.ShopOrders.Include(o => o.OrderedBy)
                                         .Include(o => o.DeliveryAddress)
                                         .Where(o => o.GamificationModelId == this.GetGamificationId()
                                                   && o.Status == status);

            return DBService.GetMany<ShopOrder, ShopOrderClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetOrder")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> GetOrder(int id)
        {
            var order = DB.ShopOrders.Include(o => o.OrderedBy)
                                     .Include(o => o.DeliveryAddress)
                                     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrder(order),
                () => RequestResult<ShopOrder>.AsSuccess(order)
            });
        }


        #region OrderItems

        [HttpGet, Route("GetOrderItems")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> GetOrderItems(int orderId)
        {
            var order = DB.ShopOrders.Include(o => o.Items).ThenInclude(o => o.Item)
                                     .FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrder(order),
                () =>
                {
                    var clientModels = ShopOrderItemClientModel.CreateItems(order.Items);
                    return RequestResult<IEnumerable<ShopOrderItemClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetOrderItem")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> GetOrderItem(int orderId,int itemId)
        {
            var order = DB.ShopOrders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            var item = DB.ShopOrderItems.Include(o => o.Item)
                                        .FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderAndItem(order, item),
                () =>
                {
                    var clientModel = ShopOrderItemClientModel.Create(item);
                    return RequestResult<ShopOrderItemClientModel>.AsSuccess(clientModel);
                }
            });
        }

        #endregion


        [HttpPut, Route("SetOrderStatus")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> SetOrderStatus(int id, ShopOrderStatus status)
        {
            var order = DB.ShopOrders.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrder(order),
                () =>
                {
                    if(order.Status == ShopOrderStatus.Basket)
                    {
                         return RequestResult.AsError(403,"Невозможно изменить статус заказа, т.к. клиент еще не заказал");
                    }

                    if(status == ShopOrderStatus.Basket)
                    {
                         return RequestResult.AsError(403,"Невозможно установить данный статус заказа");
                    }

                    if(order.Status == ShopOrderStatus.Delivered
                       || order.Status == ShopOrderStatus.Canceled
                       || order.Status == ShopOrderStatus.Rejected)
                    {
                        return RequestResult.AsError(403,"Невозможно изменить статус заказа, т.к. уже завершен");
                    }

                    order.Status = status;
                    return DBService.UpdateModel(DB.ShopOrders, order);
                }
            });
        }

        #endregion

        #region Заказы (Сотрудник)

        [HttpGet, Route("GetOrdersAsEmployee")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetOrdersAsEmployee(ShopOrderStatus status, int offset, int count = 20)
        {
            var authorizedUser = GetAuthorizedUser();
            var queryable = DB.ShopOrders.Include(o => o.OrderedBy)
                                         .Include(o => o.DeliveryAddress)
                                         .Where(o => o.Status == status && o.OrderedById == authorizedUser.Id);

            return DBService.GetMany<ShopOrder, ShopOrderClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetOrderAsEmployee")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetOrderAsEmployee(int id)
        {
            var authorizedUser = GetAuthorizedUser();
            var order = DB.ShopOrders.Include(o => o.OrderedBy)
                                     .Include(o => o.DeliveryAddress)
                                     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrder(order),
                () => RequestResult.FromBoolean(order.OrderedById == authorizedUser.Id, 403, "Заказ не принадлежит текущему пользователю"),
                () => RequestResult<ShopOrder>.AsSuccess(order)
            });
        }




        #region OrderItems

        [HttpGet, Route("GetOrderItemsAsEmployee")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetOrderItemsAsEmployee(int orderId)
        {
            var order = DB.ShopOrders.Include(o => o.Items).ThenInclude(o => o.Item)
                                     .FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrder(order),
                () => RequestResult.FromBoolean(order.OrderedById == GetAuthorizedUser().Id, 403, "Заказ не принадлежит текущему пользователю"),
                () =>
                {
                    var clientModels = ShopOrderItemClientModel.CreateItems(order.Items);
                    return RequestResult<IEnumerable<ShopOrderItemClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetOrderItemAsEmployee")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetOrderItemAsEmployee(int orderId, int itemId)
        {
            var order = DB.ShopOrders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            var item = DB.ShopOrderItems.Include(o => o.Item)
                                        .FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderAndItem(order, item),
                () => RequestResult.FromBoolean(order.OrderedById == GetAuthorizedUser().Id, 403, "Заказ не принадлежит текущему пользователю"),
                () =>
                {
                    var clientModel = ShopOrderItemClientModel.Create(item);
                    return RequestResult<ShopOrderItemClientModel>.AsSuccess(clientModel);
                }
            });
        }




        [HttpPost, Route("CreateOrderItemAsEmployee")]
        public async Task<RequestResult> CreateOrderItemAsEmployee(int orderId, ShopOrderItemCreateModel model)
        {
            var order = DB.ShopOrders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            var shopItem = DB.ShopItems.FirstOrDefault(o => o.Id == model.ItemId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderToEdit(order),
                () => RequestResult.FromBoolean(order.OrderedById == GetAuthorizedUser().Id, 403, "Заказ не принадлежит текущему пользователю"),
                () => CheckBaseShopItem(shopItem),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var item = model.Create();
                    order.Items.Add(item);

                    DBService.UpdateModel(DB.ShopOrders, order);
                    return RequestResult<ShopOrderItem>.AsSuccess(item);
                }
            });
        }

        [HttpPut, Route("UpdateOrderItemAsEmployee")]
        public async Task<RequestResult> UpdateOrderItemAsEmployee(int orderId, ShopOrderItemEditModel model)
        {
            var order = DB.ShopOrders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            var orderItem = DB.ShopOrderItems.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            var shopItem = DB.ShopItems.FirstOrDefault(o => o.Id == model.ItemId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderAndItemToEdit(order,orderItem),
                () => RequestResult.FromBoolean(order.OrderedById == GetAuthorizedUser().Id, 403, "Заказ не принадлежит текущему пользователю"),
                () => CheckBaseShopItem(shopItem),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => DBService.TryUpdateModel(DB.ShopOrderItems,orderItem,model)
            });
        }

        [HttpDelete, Route("DeleteOrderItemAsEmployee")]
        public async Task<RequestResult> DeleteOrderItemAsEmployee(int orderId, int itemId)
        {
            var order = DB.ShopOrders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            var item = DB.ShopOrderItems.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderAndItemToEdit(order, item),
                () => RequestResult.FromBoolean(order.OrderedById == GetAuthorizedUser().Id, 403, "Заказ не принадлежит текущему пользователю"),
                () => DBService.DeleteModel(DB.ShopOrderItems,item)
            });
        }

        #endregion



        [HttpPost, Route("CreateOrderAsEmployee")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> CreateOrderAsEmployee(ShopOrderCreateModel model)
        {
            var authorizedUser = GetAuthorizedUser();

            return DBService.TryCreateModel(DB.ShopOrders, model, (item) =>
            {
                item.GamificationModelId = (int)this.GetGamificationId();
                item.OrderedById = authorizedUser.Id;
                return RequestResult<ShopOrder>.AsSuccess(item);
            });
        }

        [HttpPut, Route("UpdateOrderAsEmployee")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> UpdateOrderAsEmployee(ShopOrderEditModel model)
        {
            var authorizedUser = GetAuthorizedUser();

            var order = DB.ShopOrders.Include(o => o.DeliveryAddress)
                                     .FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderToEdit(order),
                () => RequestResult.FromBoolean(order.OrderedById == authorizedUser.Id, 403, "Заказ не принадлежит текущему пользователю"),
                () => DBService.TryUpdateModel(DB.ShopOrders, order, model)
            });
        }

        [HttpDelete, Route("DeleteOrderAsEmployee")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> DeleteOrderAsEmployee(int id)
        {
            var authorizedUser = GetAuthorizedUser();

            var order = DB.ShopOrders.Include(o => o.DeliveryAddress)
                                     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderToEdit(order),
                () => RequestResult.FromBoolean(order.OrderedById == authorizedUser.Id, 403, "Заказ не принадлежит текущему пользователю"),
                () => RequestResult.FromBoolean(order.Status == ShopOrderStatus.Basket, 403, "Заказ уже оплачен, нельзя удалить"),
                () => DBService.DeleteModel(DB.ShopOrders, order)
            });
        }

        #endregion









        #region Private check methods

        private RequestResult CheckBaseShopItem(ShopItem shopItem)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(shopItem != null,404,"Товар с данным id не найден"),
                () => RequestResult.FromBoolean(shopItem.GamificationModelId == this.GetGamificationId(),403,"Нет доступа к данному товару"),
            });
        }
        private RequestResult CheckBaseShopCategory(ShopCategory category)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(category != null,404,"Категория с данным id не найдена"),
                () => RequestResult.FromBoolean(category.GamificationModelId == this.GetGamificationId(),403,"Нет доступа к данной категории"),
            });
        }


        private RequestResult CheckBaseShopOrder(ShopOrder order)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(order != null,404,"Заказ с данным id не найден"),
                () => RequestResult.FromBoolean(order.GamificationModelId == this.GetGamificationId(),403,"Нет доступа к данному заказу"),
            });
        }
        private RequestResult CheckBaseShopOrderToEdit(ShopOrder order)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrder(order),
                () => RequestResult.FromBoolean(order.Status == ShopOrderStatus.Basket,403,"Невозможно редактирование заказа"),
            });
        }


        private RequestResult CheckBaseShopOrderAndItem(ShopOrder order, ShopOrderItem item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrder(order),
                () => RequestResult.FromBoolean(item != null,404,"Позиция заказа с данным id не найдена"),
                () => RequestResult.FromBoolean(item.ShopOrderId == order.Id,403,"Позиция не принадлежит текущему заказу"),
            });
        }
        private RequestResult CheckBaseShopOrderAndItemToEdit(ShopOrder order, ShopOrderItem item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseShopOrderAndItem(order,item),
                () => RequestResult.FromBoolean(order.Status == ShopOrderStatus.Basket,403,"Невозможно редактирование заказа"),
            });
        }

        #endregion
    }
}
