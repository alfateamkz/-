using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.ClientModels.Shop;
using Alfateam.Website.API.Models.ClientModels.Shop.Orders;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels.Events;
using Alfateam.Website.API.Models.EditModels.Shop;
using Alfateam.Website.API.Models.LocalizationEditModels.Events;
using Alfateam.Website.API.Models.LocalizationEditModels.Shop;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminShopController : AbsAdminController
    {
        public AdminShopController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
            //TODO: доработать контроллер
        }

        #region Товары

        [HttpGet, Route("GetProducts")]
        public async Task<RequestResult<IEnumerable<ShopProductClientModel>>> GetProducts(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<ShopProductClientModel>>();

            var checkAccesResult = CheckAccess(1);
            if (!checkAccesResult.Success)
            {
                return new RequestResult<IEnumerable<ShopProductClientModel>>().FillFromRequestResult(checkAccesResult);
            }

            var user = checkAccesResult.Value;
            var items = GetAvailableModels(user, GetProductsList(), offset, count);
            var models = ShopProductClientModel.CreateItems(items.Cast<ShopProduct>(), LanguageId,CountryId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetProduct")]
        public async Task<RequestResult<ShopProduct>> GetProduct(int id)
        {
            var checkAccessResult = CheckAccess(1);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProduct>().FillFromRequestResult(checkAccessResult);
            }
         
            var item = GetProductsFullIncludedList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if(item == null)
            {
                return new RequestResult<ShopProduct>().SetError(404, "Сущность по данному id не найдена");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, item))
            {
                return new RequestResult<ShopProduct>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return new RequestResult<ShopProduct>().SetSuccess(item);
        }
  
        [HttpGet, Route("GetProductLocalization")]
        public async Task<RequestResult<ShopProductLocalization>> GetProductLocalization(int id)
        {
            var localization = DB.ShopProductLocalizations.Include(o => o.Language)
                                                          .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<ShopProductLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            var checkAccessResult = CheckAccess(1);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductLocalization>().FillFromRequestResult(checkAccessResult);
            }

            var mainEntity = GetProductsList().FirstOrDefault(o => o.Id == localization.ShopProductId);
            if (mainEntity == null)
            {
                return new RequestResult<ShopProductLocalization>().SetError(500, "Внутренняя ошибка");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProductLocalization>().SetError(403, "У данного пользователя нет доступа к записи");
            }


            return new RequestResult<ShopProductLocalization>().SetSuccess(localization);
        }






        [HttpPost, Route("CreateProduct")]
        public async Task<RequestResult<ShopProduct>> CreateProduct(ShopProduct item)
        {
            var checkAccessResult = CheckAccess(8);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProduct>().FillFromRequestResult(checkAccessResult);
            }

            var prepareResult = await CheckAndPrepareProductBeforeCreate(item);
            if (!prepareResult.Success)
            {
                return new RequestResult<ShopProduct>().FillFromRequestResult(prepareResult);
            }

            if (!item.IsValid())
            {
                return new RequestResult<ShopProduct>().SetError(400, "Проверьте корректность заполнения полей");
            }


            DB.ShopProducts.Add(item);
            DB.SaveChanges();
            return new RequestResult<ShopProduct>().SetSuccess(item);
        }
        [HttpPost, Route("CreateProductLocalization")]
        public async Task<RequestResult<ShopProductLocalization>> CreateProductCategoryLocalization(int itemId, ShopProductLocalization localization)
        {
            var checkAccessResult = CheckAccess(6);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductLocalization>().FillFromRequestResult(checkAccessResult);
            }

            var mainEntity = GetProductsList().FirstOrDefault(o => o.Id == itemId);
            if (mainEntity == null)
            {
                return new RequestResult<ShopProductLocalization>().SetError(404, "Сущность по данному id не найдена");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProductLocalization>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            var prepareResult = await CheckAndPrepareProductLocalizationBeforeCreate(localization);
            if (!prepareResult.Success)
            {
                return new RequestResult<ShopProductLocalization>().FillFromRequestResult(prepareResult);
            }



            mainEntity.Localizations.Add(localization);
            DB.ShopProducts.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<ShopProductLocalization>().SetSuccess(localization);
        }




        //TODO: доработать метод UpdateProductLocalization и сделать UpdateProduct
        [HttpPut, Route("UpdateProductLocalization")]
        public async Task<RequestResult<ShopProductLocalization>> UpdateProductLocalization(ShopProductLocalizationEditModel model)
        {
            var res = new RequestResult<ShopProductLocalization>();

            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkAccessResult = CheckAccess(6);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductLocalization>().FillFromRequestResult(checkAccessResult);
            }


            var mainEntity = GetProductsFullIncludedList().FirstOrDefault(o => o.Id == localization.ShopProductId);
            if (mainEntity == null)
            {
                return new RequestResult<ShopProductLocalization>().SetError(500, "Внутренняя ошибка");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProductLocalization>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            var prepareResult = await CheckAndPrepareProductLocalizationBeforeUpdate(localization,model);
            if (!prepareResult.Success)
            {
                return new RequestResult<ShopProductLocalization>().FillFromRequestResult(prepareResult);
            }


            return UpdateModel(DB.ShopProductLocalizations, model, localization);
        }







        [HttpDelete, Route("DeleteProduct")]
        public async Task<RequestResult> DeleteProduct(int id)
        {
            var res = new RequestResult();

            var item = GetProductsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkAccessResult = CheckAccess(9);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProduct>().FillFromRequestResult(checkAccessResult);
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, item))
            {
                return new RequestResult<ShopProduct>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return DeleteModel(DB.ShopProducts, item);
        }

        [HttpDelete, Route("DeleteProductLocalization")]
        public async Task<RequestResult> DeleteProductLocalization(int id)
        {
            var res = new RequestResult();

            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var mainEntity = DB.ShopProducts.FirstOrDefault(o => o.Id == localization.ShopProductId && !o.IsDeleted);
            if(mainEntity == null)
            {
                return res.SetError(500, "Внутренняя ошибка");
            }

            var checkAccessResult = CheckAccess(9);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProduct>().FillFromRequestResult(checkAccessResult);
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProduct>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return DeleteModel(DB.ShopProductLocalizations, localization, false);
        }



        #endregion

        #region Категории товаров

        [HttpGet, Route("GetProductCategories")]
        public async Task<RequestResult<IEnumerable<ShopProductCategoryClientModel>>> GetProductCategories(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<ShopProductCategoryClientModel>>();
           
            var checkAccesResult = CheckAccess(1);
            if (!checkAccesResult.Success)
            {
                return res.FillFromRequestResult(checkAccesResult);
            }

            var user = checkAccesResult.Value;
            var items = GetAvailableModels(user, GetProductCategoriesList(), offset, count);
            var models = ShopProductCategoryClientModel.CreateItems(items.Cast<ShopProductCategory>(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetProductCategory")]
        public async Task<RequestResult<ShopProductCategory>> GetProductCategory(int id)
        {
            var checkAccessResult = CheckAccess(1);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductCategory>().FillFromRequestResult(checkAccessResult);
            }

            var item = GetProductCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return new RequestResult<ShopProductCategory>().SetError(404, "Сущность по данному id не найдена");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, item))
            {
                return new RequestResult<ShopProductCategory>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return new RequestResult<ShopProductCategory>().SetSuccess(item);
        }

        [HttpGet, Route("GetProductCategoryLocalization")]
        public async Task<RequestResult<ShopProductCategoryLocalization>> GetProductCategoryLocalization(int id)
        {
            var localization = DB.ShopProductCategoryLocalizations.Include(o => o.Language)
                                                                  .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            var checkAccessResult = CheckAccess(1);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductCategoryLocalization>().FillFromRequestResult(checkAccessResult);
            }

            var mainEntity = GetProductCategoriesList().FirstOrDefault(o => o.Id == localization.ShopProductCategoryId);
            if (mainEntity == null)
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(500, "Внутренняя ошибка");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(403, "У данного пользователя нет доступа к записи");
            }


            return new RequestResult<ShopProductCategoryLocalization>().SetSuccess(localization);
        }





        [HttpPost, Route("CreateProductCategory")]
        public async Task<RequestResult<ShopProductCategory>> CreateProductCategory(ShopProductCategory item)
        {
            var checkAccessResult = CheckAccess(8);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductCategory>().FillFromRequestResult(checkAccessResult);
            }

            if (!item.IsValid())
            {
                return new RequestResult<ShopProductCategory>().SetError(400, "Проверьте корректность заполнения полей");
            }

            DB.ShopProductCategories.Add(item);
            DB.SaveChanges();
            return new RequestResult<ShopProductCategory>().SetSuccess(item);
        }

        [HttpPost, Route("CreateProductCategoryLocalization")]
        public async Task<RequestResult<ShopProductCategoryLocalization>> CreateProductCategoryLocalization(int itemId, ShopProductCategoryLocalization localization)
        {

            var checkAccessResult = CheckAccess(8);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductCategoryLocalization>().FillFromRequestResult(checkAccessResult);
            }


            var mainEntity = GetProductCategoriesList().FirstOrDefault(o => o.Id == itemId);
            if (mainEntity == null)
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(404, "Сущность по данному id не найдена");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(403, "У данного пользователя нет доступа к записи");
            }


            if (!localization.IsValid())
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(400, "Проверьте корректность заполнения полей");
            }


            mainEntity.Localizations.Add(localization);
            DB.ShopProductCategories.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<ShopProductCategoryLocalization>().SetSuccess(localization);
        }




        [HttpPut, Route("UpdateProductCategoryMain")]
        public async Task<RequestResult<ShopProductCategory>> UpdateProductCategoryMain(ShopProductCategoryMainEditModel model)
        {
            var res = new RequestResult<ShopProductCategory>();

            var item = GetProductCategoriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if(item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkAccessResult = CheckAccess(5);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductCategory>().FillFromRequestResult(checkAccessResult);
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, item))
            {
                return new RequestResult<ShopProductCategory>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return UpdateModel(DB.ShopProductCategories, model, item);
        }

        [HttpPut, Route("UpdateProductCategoryLocalization")]
        public async Task<RequestResult<ShopProductCategoryLocalization>> UpdateProductCategoryLocalization(ShopProductCategoryLocalizationEditModel model)
        {
            var res = new RequestResult<ShopProductCategoryLocalization>();

            var localization = DB.ShopProductCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkAccessResult = CheckAccess(6);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProductCategoryLocalization>().FillFromRequestResult(checkAccessResult);
            }


            var mainEntity = GetProductCategoriesList().FirstOrDefault(o => o.Id == localization.ShopProductCategoryId);
            if (mainEntity == null)
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(500, "Внутренняя ошибка");
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProductCategoryLocalization>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return UpdateModel(DB.ShopProductCategoryLocalizations, model, localization);
        }






        [HttpDelete, Route("DeleteProductCategory")]
        public async Task<RequestResult> DeleteProductCategory(int id)
        {
            var res = new RequestResult();

            var item = GetProductCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkAccessResult = CheckAccess(9);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProduct>().FillFromRequestResult(checkAccessResult);
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, item))
            {
                return new RequestResult<ShopProduct>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return DeleteModel(DB.ShopProductCategories, item);
        }

        [HttpDelete, Route("DeleteProductCategoryLocalization")]
        public async Task<RequestResult> DeleteProductCategoryLocalization(int id)
        {
            var res = new RequestResult();

            var localization = DB.ShopProductCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var mainEntity = DB.ShopProducts.FirstOrDefault(o => o.Id == localization.ShopProductCategoryId && !o.IsDeleted);
            if (mainEntity == null)
            {
                return res.SetError(500, "Внутренняя ошибка");
            }

            var checkAccessResult = CheckAccess(9);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ShopProduct>().FillFromRequestResult(checkAccessResult);
            }

            var user = checkAccessResult.Value;
            if (!this.CheckBasePermissions(user, mainEntity))
            {
                return new RequestResult<ShopProduct>().SetError(403, "У данного пользователя нет доступа к записи");
            }

            return DeleteModel(DB.ShopProductCategoryLocalizations, localization, false);
        }


        #endregion

        #region Заказы

        [HttpGet, Route("GetOrders")]
        public async Task<RequestResult<IEnumerable<ShopOrderClientModel>>> GetOrders(int offset, int count = 20)
        {
            var checkAccessResult = CheckAccess(2);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<IEnumerable<ShopOrderClientModel>>().FillFromRequestResult(checkAccessResult);
            }

            var user = checkAccessResult.Value;

            //TODO: сделать выборку по заказам, которые доступны конкретному админу, в зависимости от стран
            var orders = GetOrdersList().Skip(offset).Take(count);
            var models = ShopOrderClientModel.CreateItems(orders, LanguageId, CountryId);
            return new RequestResult<IEnumerable<ShopOrderClientModel>>().SetSuccess(models);
        }

        [HttpPut, Route("UpdateOrderData")]
        public async Task<RequestResult> UpdateOrderData(EditOrderAdminModel model)
        {
            var res = new RequestResult();

            var item = GetOrdersList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkAccessResult = CheckAccess(3);
            if (!checkAccessResult.Success)
            {
                return new RequestResult().FillFromRequestResult(checkAccessResult);
            }
            //TODO: сделать проверку доступа к заказу по стране


            if (model.Status == ShopOrderStatus.Basket
                || model.Status == ShopOrderStatus.Unpaid
                || model.Status == ShopOrderStatus.Canceled
                || model.Status == ShopOrderStatus.ReturnedByCustomer
                || model.Status == ShopOrderStatus.ReturnedByDeliveryService)
            {
                return res.SetError(400, "Неправильный статус");
            }


            return UpdateModel(DB.ShopOrders, model, item);
        }

        [HttpPut, Route("CancelOrder")]
        public async Task<RequestResult> CancelOrder(int orderId, ShopOrderStatus status, ShopOrderReturn returnInfo)
        {
            var res = new RequestResult();

            var item = GetOrdersList().FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkAccessResult = CheckAccess(4);
            if (!checkAccessResult.Success)
            {
                return new RequestResult().FillFromRequestResult(checkAccessResult);
            }

            //TODO: сделать проверку доступа к заказу по стране

            if (status != ShopOrderStatus.Canceled 
                && status != ShopOrderStatus.ReturnedByCustomer
                && status != ShopOrderStatus.ReturnedByDeliveryService)
            {
                return res.SetError(400, "Неправильный статус");
            }


            item.Return = returnInfo;
            item.Status = status;
            return UpdateModel(DB.ShopOrders, item);
        }


        #endregion






        #region Private methods

        private RequestResult<User> CheckAccess(int requiredLevel)
        {
            var session = GetSessionWithRoleInclude();

            if (session.User.RoleModel.Role == UserRole.User)
            {
                return new RequestResult<User>().SetError(403, "У данного пользователя нет доступа в администраторскую панель");
            }
        
            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                return new RequestResult<User>().FillFromRequestResult(checkSessionRes);
            }

            if (session.User.RoleModel.ShopAccess.AccessLevel < requiredLevel && session.User.RoleModel.Role != UserRole.Owner)
            {
                return new RequestResult<User>().SetError(403, "У данного пользователя нет прав на выполнение данного действия");
            }

            return RequestResult<User>.AsSuccess(session.User);
        }



        private async Task<RequestResult> CheckAndPrepareProductBeforeCreate(ShopProduct product)
        {
            //Загрузка главной картинки
            var mainFileUploadResult = await TryUploadFile($"mainImg", FileType.Image);
            if (!mainFileUploadResult.Success)
            {
                return mainFileUploadResult;
            }

            if (product.MainImage is null)
            {
                product.MainImage = new ShopProductImage();
            }
            product.MainImage.ImgPath = mainFileUploadResult.Value;


            //Загружаем остальные картинки
            product.Images = new List<ShopProductImage>();
            var files = Request.Form.Files.Where(o => o.Name.StartsWith("main_") && o.Name.EndsWith("_shopImg"));
            foreach (var file in files)
            {
                var imgUploadResult = await TryUploadFile(file, FileType.Image);
                if (!imgUploadResult.Success)
                {
                    return imgUploadResult;
                }

                product.Images.Add(new ShopProductImage
                {
                    ImgPath = imgUploadResult.Value
                });
            }


            foreach (var localization in product.Localizations)
            {
                var localizationPrepareResult = await CheckAndPrepareProductLocalizationBeforeCreate(localization);
                if (!localizationPrepareResult.Success)
                {
                    return localizationPrepareResult;
                }   
            }


            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> CheckAndPrepareProductLocalizationBeforeCreate(ShopProductLocalization localization)
        {

            if (localization.UseLocalizationImages)
            {
                //Загрузка главной картинки
                var mainFileUploadResult = await TryUploadFile($"localization_{localization.LanguageId}_mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }

                if (localization.MainImage is null)
                {
                    localization.MainImage = new ShopProductImage();
                }
                localization.MainImage.ImgPath = mainFileUploadResult.Value;


                
                //Загружаем остальные картинки
                localization.Images = new List<ShopProductImage>();
                var files = Request.Form.Files.Where(o => o.Name.StartsWith("localization_") && o.Name.EndsWith("_shopImg"));
                foreach (var file in files)
                {
                    var imgUploadResult = await TryUploadFile(file, FileType.Image);
                    if (!imgUploadResult.Success)
                    {
                        return imgUploadResult;
                    }

                    localization.Images.Add(new ShopProductImage
                    {
                        ImgPath = imgUploadResult.Value
                    });
                }

            }


            if (!localization.IsValid())
            {
                return RequestResult.AsError(400, "Проверьте корректность заполнения полей");
            }

            return RequestResult.AsSuccess();
        }


        private async Task<RequestResult> CheckAndPrepareProductBeforeUpdate(ShopProduct product, ShopProductMainEditModel model)
        {
            //Загрузка главной картинки

            if (product.MainImage.ImgPath != model.MainImage?.ImgPath)
            {
                var mainFileUploadResult = await TryUploadFile($"mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }
                product.MainImage.ImgPath = mainFileUploadResult.Value;
            }



            //TODO: здесь затык
            //Загружаем остальные картинки
            product.Images = new List<ShopProductImage>();
            var files = Request.Form.Files.Where(o => o.Name.StartsWith("main_") && o.Name.EndsWith("_shopImg"));
            foreach (var file in files)
            {
                var imgUploadResult = await TryUploadFile(file, FileType.Image);
                if (!imgUploadResult.Success)
                {
                    return imgUploadResult;
                }

                product.Images.Add(new ShopProductImage
                {
                    ImgPath = imgUploadResult.Value
                });
            }


            foreach (var localization in product.Localizations)
            {
                var localizationPrepareResult = await CheckAndPrepareProductLocalizationBeforeCreate(localization);
                if (!localizationPrepareResult.Success)
                {
                    return localizationPrepareResult;
                }
            }


            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> CheckAndPrepareProductLocalizationBeforeUpdate(ShopProductLocalization localization, ShopProductLocalizationEditModel model)
        {

            if (model.UseLocalizationImages)
            {

                if(localization.MainImage.ImgPath != model.MainImage?.ImgPath)
                {
                    //Загрузка главной картинки
                    var mainFileUploadResult = await TryUploadFile($"localization_{localization.LanguageId}_mainImg", FileType.Image);
                    if (!mainFileUploadResult.Success)
                    {
                        return mainFileUploadResult;
                    }
                    localization.MainImage.ImgPath = mainFileUploadResult.Value;
                }


                //TODO: и здесь затык
                //Загружаем остальные картинки
                localization.Images = new List<ShopProductImage>();
                var files = Request.Form.Files.Where(o => o.Name.StartsWith("localization_") && o.Name.EndsWith("_shopImg"));
                foreach (var file in files)
                {
                    var imgUploadResult = await TryUploadFile(file, FileType.Image);
                    if (!imgUploadResult.Success)
                    {
                        return imgUploadResult;
                    }

                    localization.Images.Add(new ShopProductImage
                    {
                        ImgPath = imgUploadResult.Value
                    });
                }

            }


            if (!localization.IsValid())
            {
                return RequestResult.AsError(400, "Проверьте корректность заполнения полей");
            }

            return RequestResult.AsSuccess();
        }
        #endregion

        #region Private get included methods


        private IQueryable<ShopProduct> GetProductsList()
        {
            return DB.ShopProducts.IncludeAvailability()
                                  .IncludePricing()
                                  .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                  .Include(o => o.MainImage)
                                  .Include(o => o.MainLanguage)
                                  .Where(o => !o.IsDeleted);
        }
        private IQueryable<ShopProduct> GetProductsFullIncludedList()
        {
            return DB.ShopProducts.IncludeAvailability()
                                  .Include(o => o.Category).ThenInclude(o => o.Localizations)
                                  .Include(o => o.MainImage)
                                  .Include(o => o.Images)
                                  .IncludePricing()
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Localizations)
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Localizations)
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                  .Include(o => o.Localizations)
                                  .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }



        private IQueryable<ShopProductCategory> GetProductCategoriesList()
        {
            return DB.ShopProductCategories.IncludeAvailability()
                                           .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                           .Include(o => o.MainLanguage)
                                           .Where(o => !o.IsDeleted);
        }


        private IQueryable<ShopOrder> GetOrdersList()
        {
            var orders = DB.ShopOrders.Include(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                       .Include(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                                       .Include(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                                       .Include(o => o.Address).ThenInclude(o => o.Country)
                                       .Include(o => o.Currency)
                                       .Include(o => o.Payments).ThenInclude(o => o.Currency)
                                       .Include(o => o.Return)
                                       .Where(o => !o.IsDeleted && o.Status != ShopOrderStatus.Basket);

            return orders;
        }

        #endregion
    }
}
