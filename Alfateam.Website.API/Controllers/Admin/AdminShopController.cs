using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO.Shop.Orders;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Promocodes;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Website.API.Models.DTOLocalization.Shop;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Modifiers;
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

        }

        #region Товары

        [HttpGet, Route("GetProducts")]
        public async Task<RequestResult<IEnumerable<ShopProductDTO>>> GetProducts(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<ShopProductDTO>>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => {
                    var items = GetAvailableModels(GetSessionWithRoleInclude().User, GetProductsList(), offset, count);
                    var models = ShopProductDTO.CreateItems(items.Cast<ShopProduct>(), LanguageId,CountryId);
                    return RequestResult<IEnumerable<ShopProductDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetProduct")]
        public async Task<RequestResult<ShopProduct>> GetProduct(int id)
        {
            var item = GetProductsFullIncludedList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProduct>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item),403, "У данного пользователя нет доступа к записи"),
                () => RequestResult<ShopProduct>.AsSuccess(item)
            });
        }
  
        [HttpGet, Route("GetProductLocalization")]
        public async Task<RequestResult<ShopProductLocalization>> GetProductLocalization(int id)
        {
            var localization = DB.ShopProductLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted); 
            return TryFinishAllRequestes<ShopProductLocalization>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(localization != null, 404, "Сущность с данным id не найдена"),
                () => CheckFromProduct(localization.ShopProductId),
                () => RequestResult<ShopProductLocalization>.AsSuccess(localization)
            });
        }






        [HttpPost, Route("CreateProduct")]
        public async Task<RequestResult<ShopProduct>> CreateProduct(ShopProduct item)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<ShopProduct>(new[]
            {
                () => CheckSession(session),
                () => CheckAccess(8),
                () => CheckAndPrepareProductBeforeCreate(item).Result,
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => CanSetAvailabilityCountries(session.User, item.Availability),
                () => CreateModel(DB.ShopProducts,item)
            });
        }

        [HttpPost, Route("CreateProductLocalization")]
        public async Task<RequestResult<ShopProductLocalization>> CreateProductCategoryLocalization(int itemId, ShopProductLocalization localization)
        {
            var mainEntity = GetProductsList().FirstOrDefault(o => o.Id == itemId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductLocalization>(new[]
            {
                () => CheckAccess(6),
                () => RequestResult.FromBoolean(mainEntity != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                () => CheckAndPrepareProductLocalizationBeforeCreate(localization).Result,
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.ShopProducts,mainEntity);
                    return RequestResult<ShopProductLocalization>.AsSuccess(localization);
                }
             });
        }




        [HttpPut, Route("UpdateProductMain")]
        public async Task<RequestResult<ShopProduct>> UpdateProductMain(ShopProductDTO model)
        {
            var item = GetProductsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProduct>(new[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(item != null, 404,  "Запись по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => CheckAndPrepareProductBeforeUpdate(item,model).Result,
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ShopProducts, model, item)
            });
        }

        [HttpPut, Route("UpdateProductLocalization")]
        public async Task<RequestResult<ShopProductLocalization>> UpdateProductLocalization(ShopProductLocalizationDTO model)
        {
            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null) return RequestResult<ShopProductLocalization>.AsError(404, "Локализация с данным id не найдена");

            var mainEntity = GetProductCategoriesList().FirstOrDefault(o => o.Id == localization.ShopProductId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductLocalization>(new[]
            {
                 () => CheckAccess(6),
                 () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                 () => CheckAndPrepareProductLocalizationBeforeUpdate(localization,model).Result,
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ShopProductLocalizations, model, localization)
            });
        }



        #region Фотки товара и локализаций  


        [HttpPost, Route("AddProductPhoto")]
        public async Task<RequestResult<ShopProductImage>> AddProductPhoto(int productId)
        {
            var product = GetProductsList().FirstOrDefault(o => o.Id == productId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes<ShopProductImage>(new Func<RequestResult>[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(product != null, 404, "Сущность по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, product), 403, "У данного пользователя нет доступа к записи"),
                 () =>
                 {
                     var photo = new ShopProductImage();

                     var imgUploadResult = TryUploadFile("productPhoto", FileType.Image).Result;
                     if (!imgUploadResult.Success)
                     {
                         return imgUploadResult;
                     }

                     product.Images.Add(photo);
                     UpdateModel(DB.ShopProducts, product);
                     return RequestResult<ShopProductImage>.AsSuccess(photo);
                 }
            });
        }

        [HttpPost, Route("AddProductLocalizationPhoto")]
        public async Task<RequestResult<ShopProductImage>> AddProductLocalizationPhoto(int localizationId)
        {
            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == localizationId && !o.IsDeleted);
            if (localization == null) return RequestResult<ShopProductImage>.AsError(404, "Сущность по данному id не найдена");

            var product = GetProductsList().FirstOrDefault(o => o.Id == localization.ShopProductId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductImage>(new Func<RequestResult>[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(product != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, product), 403, "У данного пользователя нет доступа к записи"),
                 () =>
                 {
                     var photo = new ShopProductImage();

                     var imgUploadResult = TryUploadFile("productPhoto", FileType.Image).Result;
                     if (!imgUploadResult.Success)
                     {
                         return imgUploadResult;
                     }

                     localization.Images.Add(photo);
                     UpdateModel(DB.ShopProductLocalizations, localization);
                     return RequestResult<ShopProductImage>.AsSuccess(photo);
                 }
            });
        }




        [HttpDelete, Route("DeleteProductPhoto")]
        public async Task<RequestResult> DeleteProductPhoto(int productId,int photoId)
        {
            var product = GetProductsList().FirstOrDefault(o => o.Id == productId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes(new Func<RequestResult>[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(product != null, 404, "Сущность по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, product), 403, "У данного пользователя нет доступа к записи"),
                 () =>
                 {
                     var photo = product.Images.FirstOrDefault(o => o.Id == photoId);
                     if(photo == null)
                     {
                         return RequestResult.AsError(404, "Фото по данному id не найдена");
                     }
                     DeleteFile(photo.ImgPath);
                     product.Images.Remove(photo);
                     return UpdateModel(DB.ShopProducts, product);
                 }
            });
        }

        [HttpDelete, Route("DeleteProductLocalizationPhoto")]
        public async Task<RequestResult> DeleteProductLocalizationPhoto(int localizationId, int photoId)
        {
            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == localizationId && !o.IsDeleted);
            if (localization == null) return RequestResult.AsError(404, "Сущность по данному id не найдена");

            var product = GetProductsList().FirstOrDefault(o => o.Id == localization.ShopProductId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes(new Func<RequestResult>[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(product != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, product), 403, "У данного пользователя нет доступа к записи"),
                 () =>
                 {
                     var photo = localization.Images.FirstOrDefault(o => o.Id == photoId);
                     if(photo == null)
                     {
                         return RequestResult.AsError(404, "Фото по данному id не найдена");
                     }
                     DeleteFile(photo.ImgPath);
                     localization.Images.Remove(photo);
                     return UpdateModel(DB.ShopProductLocalizations, localization);
                 }
            });
        }

        #endregion


        [HttpDelete, Route("DeleteProduct")]
        public async Task<RequestResult> DeleteProduct(int id)
        {
            var item = GetProductsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => DeleteModel(DB.ShopProducts, item)
            });
        }

        [HttpDelete, Route("DeleteProductLocalization")]
        public async Task<RequestResult> DeleteProductLocalization(int id)
        {
            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult.AsError(404, "Запись по данному id не найдена");
    
            var mainEntity = DB.ShopProducts.FirstOrDefault(o => o.Id == localization.ShopProductId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                 () => DeleteModel(DB.ShopProductLocalizations, localization,false)
            });
        }



        #endregion

        #region Модификаторы

        [HttpGet, Route("GetProductModifier")]
        public async Task<RequestResult<ProductModifier>> GetProductModifier(int id)
        {
            var item = GetProductModifiersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<ProductModifier>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность с данным id не найдена"),
                () => CheckFromProduct(item.ShopProductId),
                () => RequestResult<ProductModifier>.AsSuccess(item)
            });
        }

        [HttpGet, Route("GetProductModifierLocalization")]
        public async Task<RequestResult<ProductModifierLocalization>> GetProductModifierLocalization(int id)
        {
            var localization = DB.ProductModifierLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<ProductModifierLocalization>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(localization != null, 404, "Сущность с данным id не найдена"),
                () => CheckFromProductModifier(localization.ProductModifierId),
                () => RequestResult<ProductModifierLocalization>.AsSuccess(localization)
            });
        }





        [HttpPost, Route("CreateProductModifier")]
        public async Task<RequestResult<ProductModifier>> CreateProductModifier(ProductModifier item)
        {
            return TryFinishAllRequestes<ProductModifier>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => CreateModel(DB.ProductModifiers,item)
           });
        }

        [HttpPost, Route("CreateProductModifierLocalization")]
        public async Task<RequestResult<ProductModifierLocalization>> CreateProductCategoryLocalization(int itemId, ProductModifierLocalization localization)
        {
            var mainEntity = GetProductModifiersList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<ProductModifierLocalization>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(mainEntity != null, 404, "Сущность по данному id не найдена"),
                () => CheckFromProductModifier(localization.ProductModifierId),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.ProductModifiers,mainEntity);
                    return RequestResult<ProductModifierLocalization>.AsSuccess(localization);
                }
            });
        }





        [HttpPut, Route("UpdateProductModifierMain")]
        public async Task<RequestResult<ProductModifier>> UpdateProductModifierMain(ProductModifierDTO model)
        {
            var item = GetProductModifiersList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<ProductModifier>(new[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(item != null, 404,  "Запись по данному id не найдена"),
                 () => CheckFromProduct(item.ShopProductId),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ProductModifiers, model, item)
            });
        }
     
        [HttpPut, Route("UpdateProductModifierLocalization")]
        public async Task<RequestResult<ProductModifierLocalization>> UpdateProductModifierLocalization(ProductModifierLocalizationDTO model)
        {
            var localization = DB.ProductModifierLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null) return RequestResult<ProductModifierLocalization>.AsError(404, "Локализация с данным id не найдена");

            return TryFinishAllRequestes<ProductModifierLocalization>(new[]
            {
                 () => CheckAccess(6),
                 () => CheckFromProductModifier(localization.ProductModifierId),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ProductModifierLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeleteProductModifier")]
        public async Task<RequestResult> DeleteProductModifier(int id)
        {
            var item = GetProductModifiersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(item != null,404, "Сущность с данным id не найдена"),
                 () => CheckFromProduct(item.ShopProductId),
                 () => DeleteModel(DB.ProductModifiers, item)
            });
        }
    
        [HttpDelete, Route("DeleteProductModifierLocalization")]
        public async Task<RequestResult> DeleteProductModifierLocalization(int id)
        {
            var localization = DB.ProductModifierLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                 () => CheckFromProductModifier(localization.ProductModifierId),
                 () => DeleteModel(DB.ProductModifierLocalizations, localization, false)
            });
        }




        #endregion

        #region Опции модификаторов

        [HttpGet, Route("GetProductModifierOption")]
        public async Task<RequestResult<ProductModifierItem>> GetProductModifierOption(int id)
        {
            var item = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<ProductModifierItem>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null,404, "Сущность с данным id не найдена"),
                () => CheckFromProductModifier(item.ProductModifierId),
                () => RequestResult<ProductModifierItem>.AsSuccess(item)
            });
        }

        [HttpGet, Route("GetProductModifierOptionLocalization")]
        public async Task<RequestResult<ProductModifierItemLocalization>> GetProductModifierOptionLocalization(int id)
        {
            var localization = DB.ProductModifierItemLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<ProductModifierItemLocalization>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckFromProductModifierOption(localization.ProductModifierItemId),
                () => RequestResult<ProductModifierItemLocalization>.AsSuccess(localization)
            });
        }





        [HttpPost, Route("CreateProductModifierOption")]
        public async Task<RequestResult<ProductModifierItem>> CreateProductModifierOption(ProductModifierItem item)
        {
            return TryFinishAllRequestes<ProductModifierItem>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => CreateModel(DB.ProductModifierItems,item)
           });
        }

        [HttpPost, Route("CreateProductModifierOptionLocalization")]
        public async Task<RequestResult<ProductModifierItemLocalization>> CreateProductModifierOptionLocalization(int itemId, ProductModifierItemLocalization localization)
        {
            var mainEntity = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<ProductModifierItemLocalization>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(mainEntity != null, 404, "Сущность по данному id не найдена"),
                () => CheckFromProductModifierOption(localization.ProductModifierItemId),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.ProductModifierItems,mainEntity);
                    return RequestResult<ProductModifierItemLocalization>.AsSuccess(localization);
                }
            });
        }




        [HttpPut, Route("UpdateProductModifierOptionMain")]
        public async Task<RequestResult<ProductModifierItem>> UpdateProductCategoryMain(ProductModifierItemDTO model)
        {
            var item = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<ProductModifierItem>(new[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(item != null, 404,  "Запись по данному id не найдена"),
                 () => CheckFromProductModifier(item.ProductModifierId),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ProductModifierItems, model, item)
            });
        }
      
        [HttpPut, Route("UpdateProductModifierOptionLocalization")]
        public async Task<RequestResult<ProductModifierItemLocalization>> UpdateProductModifierOptionLocalization(ProductModifierItemLocalizationDTO model)
        {
            var localization = DB.ProductModifierItemLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null) return RequestResult<ProductModifierItemLocalization>.AsError(404, "Локализация с данным id не найдена");

            return TryFinishAllRequestes<ProductModifierItemLocalization>(new[]
            {
                 () => CheckAccess(6),
                 () => CheckFromProductModifierOption(localization.ProductModifierItemId),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ProductModifierItemLocalizations, model, localization)
            });
        }







        [HttpDelete, Route("DeleteProductModifierOption")]
        public async Task<RequestResult> DeleteProductModifierOption(int id)
        {
            var item = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(item != null,404, "Сущность с данным id не найдена"),
                 () => CheckFromProductModifier(item.ProductModifierId),
                 () => DeleteModel(DB.ProductModifierItems, item)
            });
        }
      
        [HttpDelete, Route("DeleteProductModifierOptionLocalization")]
        public async Task<RequestResult> DeleteProductModifierOptionLocalization(int id)
        {
            var localization = DB.ProductModifierItemLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                 () => CheckFromProductModifierOption(localization.ProductModifierItemId),
                 () => DeleteModel(DB.ProductModifierItemLocalizations, localization, false)
            });
        }

        #endregion

        #region Категории товаров

        [HttpGet, Route("GetProductCategories")]
        public async Task<RequestResult<IEnumerable<ShopProductCategoryDTO>>> GetProductCategories(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<ShopProductCategoryDTO>>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => {
                    var items = GetAvailableModels(GetSessionWithRoleInclude().User, GetProductCategoriesList(), offset, count);
                    var models = ShopProductCategoryDTO.CreateItemsWithLocalization(items.Cast<ShopProductCategory>(), LanguageId) as IEnumerable<ShopProductCategoryDTO>;
                    return RequestResult<IEnumerable<ShopProductCategoryDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetProductCategory")]
        public async Task<RequestResult<ShopProductCategory>> GetProductCategory(int id)
        {
            var item = GetProductCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductCategory>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item),403, "У данного пользователя нет доступа к записи"),
                () => RequestResult<ShopProductCategory>.AsSuccess(item)
            });
        }

        [HttpGet, Route("GetProductCategoryLocalization")]
        public async Task<RequestResult<ShopProductCategoryLocalization>> GetProductCategoryLocalization(int id)
        {
            var localization = DB.ShopProductCategoryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<ShopProductCategoryLocalization>.AsError(404, "Локализация с данным id не найдена");

            var mainEntity = GetProductsList().FirstOrDefault(o => o.Id == localization.ShopProductCategoryId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductCategoryLocalization>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity),403, "У данного пользователя нет доступа к записи"),
                () => RequestResult<ShopProductCategoryLocalization>.AsSuccess(localization)
            });
        }





        [HttpPost, Route("CreateProductCategory")]
        public async Task<RequestResult<ShopProductCategory>> CreateProductCategory(ShopProductCategory item)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<ShopProductCategory>(new[]
            {
                () => CheckSession(session),
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => CanSetAvailabilityCountries(session.User, item.Availability),
                () => CreateModel(DB.ShopProductCategories,item)
            });
        }

        [HttpPost, Route("CreateProductCategoryLocalization")]
        public async Task<RequestResult<ShopProductCategoryLocalization>> CreateProductCategoryLocalization(int itemId, ShopProductCategoryLocalization localization)
        {
            var mainEntity = GetProductCategoriesList().FirstOrDefault(o => o.Id == itemId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductCategoryLocalization>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(mainEntity != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.ShopProductCategories,mainEntity);
                    return RequestResult<ShopProductCategoryLocalization>.AsSuccess(localization);
                }
            });
        }




        [HttpPut, Route("UpdateProductCategoryMain")]
        public async Task<RequestResult<ShopProductCategory>> UpdateProductCategoryMain(ShopProductCategoryDTO model)
        {
            var item = GetProductCategoriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductCategory>(new[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(item != null, 404,  "Запись по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ShopProductCategories, model, item)
            });
        }

        [HttpPut, Route("UpdateProductCategoryLocalization")]
        public async Task<RequestResult<ShopProductCategoryLocalization>> UpdateProductCategoryLocalization(ShopProductCategoryLocalizationDTO model)
        {
            var localization = DB.ShopProductCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null) return RequestResult<ShopProductCategoryLocalization>.AsError(404, "Локализация с данным id не найдена");
       
            var mainEntity = GetProductCategoriesList().FirstOrDefault(o => o.Id == localization.ShopProductCategoryId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopProductCategoryLocalization>(new[]
            {
                 () => CheckAccess(6),
                 () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.ShopProductCategoryLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeleteProductCategory")]
        public async Task<RequestResult> DeleteProductCategory(int id)
        {
            var item = GetProductCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => DeleteModel(DB.ShopProductCategories, item)
            });
        }

        [HttpDelete, Route("DeleteProductCategoryLocalization")]
        public async Task<RequestResult> DeleteProductCategoryLocalization(int id)
        {
            var localization = DB.ShopProductCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult.AsError(404, "Запись по данному id не найдена");

            var mainEntity = DB.ShopProducts.FirstOrDefault(o => o.Id == localization.ShopProductCategoryId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                 () => DeleteModel(DB.ShopProductCategoryLocalizations, localization,false)
            });
        }


        #endregion

        #region Заказы

        [HttpGet, Route("GetOrders")]
        public async Task<RequestResult<IEnumerable<ShopOrderDTO>>> GetOrders(int offset, int count = 20)
        {
            var checkAccessResult = CheckAccess(2);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<IEnumerable<ShopOrderDTO>>().FillFromRequestResult(checkAccessResult);
            }

            var user = GetSessionWithRoleInclude().User;
            var orders = GetAvailableOrders(user,offset,count);
            var models = ShopOrderDTO.CreateItems(orders, LanguageId, CountryId);
            return new RequestResult<IEnumerable<ShopOrderDTO>>().SetSuccess(models);
        }

        [HttpGet, Route("GetOrder")]
        public async Task<RequestResult<ShopOrder>> GetOrder(int id)
        {
            var user = GetSessionWithRoleInclude()?.User;
            var item = GetAvailableOrders(user).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<ShopOrder>(new Func<RequestResult>[]
            {
                () => CheckAccess(2),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult<ShopOrder>.AsSuccess(item)
            });
        }

        [HttpPut, Route("UpdateOrderData")]
        public async Task<RequestResult> UpdateOrderData(EditOrderAdminModel model)
        {
            var item = GetOrdersList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            var checkAccessResult = CheckAccess(3);
            if (!checkAccessResult.Success)
            {
                return checkAccessResult;
            }

            var user = GetSessionWithRoleInclude().User;
            var orders = GetAvailableOrders(user);
            if(!orders.Any(o => o.Id == item.Id))
            {
                return RequestResult.AsError(403, "У пользователя нет доступа к данному заказы");
            }


            if (model.Status == ShopOrderStatus.Basket
                || model.Status == ShopOrderStatus.Unpaid
                || model.Status == ShopOrderStatus.Canceled
                || model.Status == ShopOrderStatus.ReturnedByCustomer
                || model.Status == ShopOrderStatus.ReturnedByDeliveryService)
            {
                return RequestResult.AsError(400, "Неправильный статус");
            }


            return UpdateModel(DB.ShopOrders, model, item);
        }

        [HttpPut, Route("CancelOrder")]
        public async Task<RequestResult> CancelOrder(int orderId, ShopOrderStatus status, ShopOrderReturn returnInfo)
        {
            var item = GetOrdersList().FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            var checkAccessResult = CheckAccess(4);
            if (!checkAccessResult.Success)
            {
                return new RequestResult().FillFromRequestResult(checkAccessResult);
            }

            var user = GetSessionWithRoleInclude().User;
            var orders = GetAvailableOrders(user);
            if (!orders.Any(o => o.Id == item.Id))
            {
                return RequestResult.AsError(403, "У пользователя нет доступа к данному заказы");
            }

            if (status != ShopOrderStatus.Canceled 
                && status != ShopOrderStatus.ReturnedByCustomer
                && status != ShopOrderStatus.ReturnedByDeliveryService)
            {
                return RequestResult.AsError(400, "Неправильный статус");
            }


            item.Return = returnInfo;
            item.Status = status;
            return UpdateModel(DB.ShopOrders, item);
        }


        #endregion

        #region Промокоды

        [HttpGet, Route("GetPromocodes")]
        public async Task<RequestResult<IEnumerable<PromocodeDTO>>> GetPromocodes(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PromocodeDTO>>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => {
                    var items = GetAvailableModels(GetSessionWithRoleInclude().User, GetPromocodesList(), offset, count);
                    var models = PromocodeDTO.CreateItems(items.Cast<Promocode>(), LanguageId,(int)CurrencyId) as IEnumerable<PromocodeDTO>;
                    return RequestResult<IEnumerable<PromocodeDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPromocode")]
        public async Task<RequestResult<Promocode>> GetPromocode(int id)
        {
            var item = GetPromocodesFullIncludedList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<Promocode>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item),403, "У данного пользователя нет доступа к записи"),
                () => RequestResult<Promocode>.AsSuccess(item)
            });
        }



        [HttpPost, Route("CreatePromocode")]
        public async Task<RequestResult<ShopProduct>> CreatePromocode(Promocode item)
        {
            return TryFinishAllRequestes<ShopProduct>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => CreateModel(DB.Promocodes,item)
             });
        }



        [HttpPut, Route("UpdatePromocode")]
        public async Task<RequestResult<Promocode>> UpdatePromocode(PromocodeDTO model)
        {
            var item = GetPromocodesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<Promocode>(new Func<RequestResult>[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(item != null, 404,  "Запись по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.Promocodes, model, item)
            });
        }



        [HttpDelete, Route("DeletePromocode")]
        public async Task<RequestResult> DeletePromocode(int id)
        {
            var item = GetPromocodesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(9),
                 () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => DeleteModel(DB.Promocodes, item)
            });
        }

        #endregion




        #region Матрицы цен
        [HttpPut, Route("UpdatePricingMatrix")]
        public async Task<RequestResult<PricingMatrix>> UpdatePricingMatrix(PricingMatrixDTO model)
        {
           var matrix = DB.GetIncludedPricingMatrix(model.Id);
         
           return TryFinishAllRequestes<PricingMatrix>(new[]
           {
                () => CheckAccess(7),
                () => RequestResult.FromBoolean(matrix != null, 404, "Запись по данному id не найдена"),
                () => RequestResult.FromBoolean(matrix.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => UpdateModel(DB.PricingMatrices, model, matrix)
            });
        }

        [HttpPut, Route("SetDefaultProductPricingMatrix")]
        public async Task<RequestResult<PricingMatrix>> SetDefaultProductPricingMatrix(int productId)
        {
            var product = GetProductsFullIncludedList().FirstOrDefault(o => o.Id == productId);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes<PricingMatrix>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(product != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, product), 403, "У данного пользователя нет доступа к записи"),
                () =>
                {
                    product.BasePricing = CreateDefaultPricingMatrix();
                    return UpdateModel(DB.ShopProducts,product);
                }
            });
        }
    
        [HttpPut, Route("SetDefaultProductModifierItemPricingMatrix")]
        public async Task<RequestResult<PricingMatrix>> SetDefaultProductModifierItemPricingMatrix(int optionId)
        {
            var option = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == optionId);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes<PricingMatrix>(new[]
            {
                () => CheckAccess(8),
                () => RequestResult.FromBoolean(option != null, 404, "Сущность по данному id не найдена"),
                () => CheckFromProductModifier(option.ProductModifierId),
                () =>
                {
                    option.Pricing = CreateDefaultPricingMatrix();
                    return UpdateModel(DB.ProductModifierItems,option);
                }
            });
        }
        #endregion

        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.ShopProducts.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= GetAvailableModels(user, DB.ShopProductCategories.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            var availability = DB.GetIncludedAvailability(model.Id);
            return TryFinishAllRequestes<Availability>(new[]
            {
                () => RequestResult.FromBoolean(availability != null, 404, "Запись по данному id не найдена"),
                () => CanSetAvailabilityCountries(user, availability),
                () => CheckAccess(5),
                () => UpdateModel(DB.Availabilities, model, availability)
            });
        }






        #region Private get available orders
        private List<ShopOrder> GetAvailableOrders(User user, int offset, int count = 20)
        {
            return GetAvailableOrders(user).Skip(offset).Take(count).ToList();
        }
        private List<ShopOrder> GetAvailableOrders(User user)
        {
            var allOrders = GetOrdersList();
            var availableOrders = new List<ShopOrder>();

            if (user.RoleModel.Role == UserRole.Owner)
            {
                return allOrders.ToList();
            }

            foreach(var order in allOrders)
            {
                if (user.RoleModel.IsAllCountriesAccess)
                {
                    bool isForbidden = false;

                    foreach(var country in user.RoleModel.ForbiddenCountries)
                    {
                        if(order.CountryId == country.Id)
                        {
                            isForbidden = true;
                            break;
                        }
                    }

                    if (!isForbidden)
                    {
                        availableOrders.Add(order);
                    }                 
                }
                else
                {
                    foreach (var country in user.RoleModel.AvailableCountries)
                    {
                        if (order.CountryId == country.Id)
                        {
                            availableOrders.Add(order);
                            break;
                        }
                    }

                }
            }


            return availableOrders;
        }

        #endregion

        #region Private check access methods

        private RequestResult CheckAccess(int requiredLevel)
        {
           var session = GetSessionWithRoleInclude();
           return TryFinishAllRequestes(new Func<RequestResult>[]
           {
                () => CheckSession(session),
                () => CheckForBan(session.User,BanType.AdminPanel),
                () => RequestResult.FromBoolean(session.User.RoleModel.Role != UserRole.User,
                        403, "У данного пользователя нет доступа в администраторскую панель"),  
                () => RequestResult.FromBoolean(session.User.RoleModel.ShopAccess.AccessLevel >= requiredLevel 
                            || session.User.RoleModel.Role == UserRole.Owner || session.User.RoleModel.Role == UserRole.LocalDirector,
                       403, "У данного пользователя нет прав на выполнение данного действия")
            });
        }

        private RequestResult CheckFromProductModifierOption(int optionId)
        {
            var option = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == optionId && !o.IsDeleted);
            if (option == null) return RequestResult.AsError(500, "Внутренняя ошибка");

            return CheckFromProductModifier(option.ProductModifierId);
        }
        private RequestResult CheckFromProductModifier(int modifierId)
        {
            var modifier = GetProductModifiersList().FirstOrDefault(o => o.Id == modifierId);
            if (modifier == null) return RequestResult<ProductModifierItem>.AsError(500, "Внутренняя ошибка");

            return CheckFromProduct(modifier.ShopProductId);
        }
        private RequestResult CheckFromProduct(int productId)
        {
            var product = GetProductsFullIncludedList().FirstOrDefault(o => o.Id == productId && !o.IsDeleted);
            if (product == null) return RequestResult.AsError(500, "Внутренняя ошибка");

            var user = GetSessionWithRoleInclude()?.User;
            return RequestResult.FromBoolean(this.CheckBasePermissions(user, product), 403, "У данного пользователя нет доступа к записи");
        }

        #endregion 

        #region Private prepare model methods

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
                var mainFileUploadResult = await TryUploadFile($"localization_{localization.LanguageEntityId}_mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }


                localization.MainImage ??= new ShopProductImage();
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


        private async Task<RequestResult> CheckAndPrepareProductBeforeUpdate(ShopProduct product, ShopProductDTO model)
        {
            //Загрузка главной картинки
            if (Request.Form.Files.Any(o => o.Name == "mainImg"))
            {
                var mainFileUploadResult = await TryUploadFile($"mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }
                product.MainImage.ImgPath = mainFileUploadResult.Value;
            }

            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> CheckAndPrepareProductLocalizationBeforeUpdate(ShopProductLocalization localization, ShopProductLocalizationDTO model)
        {

            if (model.UseLocalizationImages)
            {
                string formFileName = $"localization_{localization.LanguageEntityId}_mainImg";
                if (Request.Form.Files.Any(o => o.Name == formFileName))
                {
                    //Загрузка главной картинки
                    var mainFileUploadResult = await TryUploadFile($"localization_{localization.LanguageEntityId}_mainImg", FileType.Image);
                    if (!mainFileUploadResult.Success)
                    {
                        return mainFileUploadResult;
                    }
                    localization.MainImage.ImgPath = mainFileUploadResult.Value;
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
                                  .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
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
                                  .Where(o => !o.IsDeleted);
        }



        private IQueryable<ProductModifier> GetProductModifiersList()
        {
            return DB.ProductModifiers.Include(o => o.Localizations)
                                      .Include(o => o.Options).ThenInclude(o => o.Localizations)
                                      .Include(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                      .Include(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                      .Where(o => !o.IsDeleted);
        }
        private IQueryable<ProductModifierItem> GetProductModifiersItemsList()
        {
            return DB.ProductModifierItems.Include(o => o.Localizations)
                                          .Include(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                          .Include(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                          .Where(o => !o.IsDeleted);
        }


        private IQueryable<ShopProductCategory> GetProductCategoriesList()
        {
            return DB.ShopProductCategories.IncludeAvailability()
                                           .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
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



        private IQueryable<Promocode> GetPromocodesList()
        {
            return DB.Promocodes.IncludeAvailability()
                                .Include(o => o.PriceFrom).ThenInclude(o => o.Costs)
                                .Include(o => o.PriceTo).ThenInclude(o => o.Costs)
                                .Where(o => !o.IsDeleted);
        }
        private IQueryable<Promocode> GetPromocodesFullIncludedList()
        {
            return DB.Promocodes.IncludeAvailability()
                                .Include(o => o.PriceFrom).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                .Include(o => o.PriceFrom).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                .Include(o => o.PriceTo).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                .Include(o => o.PriceTo).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                .Where(o => !o.IsDeleted);
        }


        #endregion
    }
}
