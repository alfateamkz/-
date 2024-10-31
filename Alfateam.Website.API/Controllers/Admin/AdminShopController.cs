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
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Website.API.Models.DTOLocalization.Posts;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Enums;
using Alfateam.Website.API.Services;
using Microsoft.Extensions.Options;
using Alfateam.Website.API.Models.DTOLocalization.Team;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swashbuckle.AspNetCore.Annotations;
using Alfateam.Website.API.Models.DTO.Shop.ProductModifierItems;
using Microsoft.AspNetCore.Http.Features;
using Alfateam.Website.API.Filters.AdminSearch;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminShopController : AbsAdminController
    {
        public AdminShopController(ControllerParams @params) : base(@params)
        {
        }

        #region Товары

        [HttpGet, Route("GetProducts")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ShopProductDTO>> GetProducts(int offset, int count = 20)
        {
            var items = GetAvailableShopProducts().Skip(offset).Take(count);
            return new ShopProductDTO().CreateDTOs(items).Cast<ShopProductDTO>();
        }

        [HttpGet, Route("GetProductsFiltered")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ShopProductDTO>> GetProductsFiltered([FromQuery] ShopProductSearchFilter filter)
        {
            var items = filter.Filter(GetAvailableShopProducts(), (item) => item.Title);
            return new ShopProductDTO().CreateDTOs(items).Cast<ShopProductDTO>();
        }


        [HttpGet, Route("GetProduct")]
        [ShopSectionAccess(1)]
        public async Task<ShopProductDTO> GetProduct(int id)
        {
            return (ShopProductDTO)DbService.TryGetOne(GetAvailableShopProducts(), id, new ShopProductDTO());
        }

        [HttpGet, Route("GetProductLocalizations")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ShopProductLocalizationDTO>> GetProductLocalizations(int id)
        {
            var localizations = DB.ShopProductLocalizations.Include(o => o.LanguageEntity).Where(o => o.ShopProductId == id && !o.IsDeleted);
            var mainEntity = GetAvailableShopProducts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new ShopProductLocalizationDTO()).Cast<ShopProductLocalizationDTO>();
        }

        [HttpGet, Route("GetProductLocalization")]
        [ShopSectionAccess(1)]
        public async Task<ShopProductLocalizationDTO> GetProductLocalization(int id)
        {
            var localization = DB.ShopProductLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableShopProducts().FirstOrDefault(o => o.Id == localization?.ShopProductId && !o.IsDeleted);

            return (ShopProductLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new ShopProductLocalizationDTO());
        }






        [HttpPost, Route("CreateProduct")]
        [ShopSectionAccess(8)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task<ShopProductDTO> CreateProduct([FromForm(Name ="model")]ShopProductDTO model)
        {
            return (ShopProductDTO)DbService.TryCreateAvailabilityEntity(DB.ShopProducts, model, this.Session, (entity) =>
            {
                HandleProduct(entity, DBModelFillMode.Create);
            });
        }

        [HttpPost, Route("CreateProductLocalization")]
        [ShopSectionAccess(6)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg (опционально)")]
        public async Task<ShopProductLocalizationDTO> CreateProductCategoryLocalization(int itemId, [FromForm(Name = "localization")] ShopProductLocalizationDTO localization)
        {
            var mainEntity = GetAvailableShopProducts().FirstOrDefault(o => o.Id == itemId);
            return (ShopProductLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.ShopProducts, mainEntity, localization, (entity) =>
            {
                HandleProductLocalization(entity, DBModelFillMode.Create);
            });
        }




        [HttpPut, Route("UpdateProductMain")]
        [ShopSectionAccess(5)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем изображение")]
        public async Task<ShopProductDTO> UpdateProductMain([FromForm(Name = "model")] ShopProductDTO model)
        {
            var item = GetAvailableShopProducts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ShopProductDTO)DbService.TryUpdateEntity(DB.ShopProducts, model, item, (entity) =>
            {
                HandleProduct(entity, DBModelFillMode.Update);
            });
        }

        [HttpPut, Route("UpdateProductLocalization")]
        [ShopSectionAccess(6)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg (опционально), если изменяем изображение")]
        public async Task<ShopProductLocalizationDTO> UpdateProductLocalization([FromForm(Name = "model")] ShopProductLocalizationDTO model)
        {
            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableShopProducts().FirstOrDefault(o => o.Id == localization.ShopProductId && !o.IsDeleted);

            return (ShopProductLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.ShopProductLocalizations, localization, model, mainEntity, (entity) =>
            {
                HandleProductLocalization(entity, DBModelFillMode.Update);
            });
        }



        #region Фотки товара и локализаций  


        [HttpPost, Route("AddProductPhoto")]
        [ShopSectionAccess(5)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task AddProductPhoto(int productId)
        {
            var product = GetAvailableShopProducts().FirstOrDefault(o => o.Id == productId  && !o.IsDeleted);
            if(product == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            HandleProductAddPhoto(product);
            DbService.UpdateEntity(DB.ShopProducts, product);
        }

        [HttpPost, Route("AddProductLocalizationPhoto")]
        [ShopSectionAccess(5)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task AddProductLocalizationPhoto(int localizationId)
        {
            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == localizationId && !o.IsDeleted);
            var product = GetAvailableShopProducts().FirstOrDefault(o => o.Id == localization?.ShopProductId && !o.IsDeleted);
            if (localization == null || product == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            HandleProductLocalizationAddPhoto(localization);
            DbService.UpdateEntity(DB.ShopProductLocalizations, localization);
        }




        [HttpDelete, Route("DeleteProductPhoto")]
        [ShopSectionAccess(5)]
        public async Task DeleteProductPhoto(int productId,int photoId)
        {
            var product = GetAvailableShopProducts().FirstOrDefault(o => o.Id == productId && !o.IsDeleted);
            var photo = product?.Images?.FirstOrDefault(o => o.Id == photoId);
            if (product == null || photo == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            FilesService.DeleteFile(photo.ImgPath);
            product.Images.Remove(photo);
            DbService.UpdateEntity(DB.ShopProducts, product);
        }

        [HttpDelete, Route("DeleteProductLocalizationPhoto")]
        [ShopSectionAccess(5)]
        public async Task DeleteProductLocalizationPhoto(int localizationId, int photoId)
        {
            var localization = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == localizationId && !o.IsDeleted);
            var photo = localization?.Images?.FirstOrDefault(o => o.Id == photoId);
            var product = GetAvailableShopProducts().FirstOrDefault(o => o.Id == localization?.ShopProductId && !o.IsDeleted);

            if (localization == null || product == null || localization == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            FilesService.DeleteFile(photo.ImgPath);
            localization.Images.Remove(photo);
            DbService.UpdateEntity(DB.ShopProductLocalizations, localization);
        }

        #endregion


        [HttpDelete, Route("DeleteProduct")]
        [ShopSectionAccess(9)]
        public async Task DeleteProduct(int id)
        {
            var item = GetAvailableShopProducts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.ShopProducts, item);
        }

        [HttpDelete, Route("DeleteProductLocalization")]
        [ShopSectionAccess(9)]
        public async Task DeleteProductLocalization(int id)
        {
            var item = DB.ShopProductLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailableShopProducts().FirstOrDefault(o => o.Id == item.ShopProductId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.ShopProductLocalizations, item, mainModel);
        }



        #endregion

        #region Модификаторы

        [HttpGet, Route("GetProductModifier")]
        [ShopSectionAccess(1)]
        public async Task<ProductModifierDTO> GetProductModifier(int id)
        {
            var item = GetProductModifiersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromProductModifier(id);
            return (ProductModifierDTO)new ProductModifierDTO().CreateDTO(item);
        }

        [HttpGet, Route("GetProductModifierLocalizations")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ProductModifierLocalizationDTO>> GetProductModifierLocalizations(int id)
        {
            var localizations = DB.ProductModifierLocalizations.Include(o => o.LanguageEntity).Where(o => o.ProductModifierId == id && !o.IsDeleted);
            var mainEntity = GetProductModifiersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromProductModifier(id);
            return DbService.GetLocalizationModels(localizations, mainEntity, new ProductModifierLocalizationDTO()).Cast<ProductModifierLocalizationDTO>();
        }

        [HttpGet, Route("GetProductModifierLocalization")]
        [ShopSectionAccess(1)]
        public async Task<ProductModifierLocalizationDTO> GetProductModifierLocalization(int id)
        {
            var localization = DB.ProductModifierLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetProductModifiersList().FirstOrDefault(o => o.Id == localization?.ProductModifierId && !o.IsDeleted);

            CheckFromProductModifier(localization?.ProductModifierId);
            return (ProductModifierLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new ProductModifierLocalizationDTO());
        }





        [HttpPost, Route("CreateProductModifier")]
        [ShopSectionAccess(8)]
        public async Task<ProductModifierDTO> CreateProductModifier(ProductModifierDTO model)
        {
            CheckFromProduct(model.ShopProductId);
            return (ProductModifierDTO)DbService.TryCreateEntity(DB.ProductModifiers, model);
        }

        [HttpPost, Route("CreateProductModifierLocalization")]
        [ShopSectionAccess(8)]
        public async Task<ProductModifierLocalizationDTO> CreateProductModifierLocalization(int itemId, ProductModifierLocalizationDTO model)
        {
            var mainEntity = GetProductModifiersList().FirstOrDefault(o => o.Id == itemId);

            CheckFromProductModifier(itemId);
            return (ProductModifierLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.ProductModifiers, mainEntity, model);
        }





        [HttpPut, Route("UpdateProductModifierMain")]
        [ShopSectionAccess(5)]
        public async Task<ProductModifierDTO> UpdateProductModifierMain(ProductModifierDTO model)
        {
            var item = GetProductModifiersList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            CheckFromProductModifier(model.Id);
            return (ProductModifierDTO)DbService.TryUpdateEntity(DB.ProductModifiers, model, item);
        }
     
        [HttpPut, Route("UpdateProductModifierLocalization")]
        [ShopSectionAccess(6)]
        public async Task<ProductModifierLocalizationDTO> UpdateProductModifierLocalization(ProductModifierLocalizationDTO model)
        {
            var localization = DB.ProductModifierLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetProductModifiersList().FirstOrDefault(o => o.Id == localization?.ProductModifierId && !o.IsDeleted);

            CheckFromProductModifier(localization.ProductModifierId);
            return (ProductModifierLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.ProductModifierLocalizations, localization, model, mainEntity);
        }






        [HttpDelete, Route("DeleteProductModifier")]
        [ShopSectionAccess(9)]
        public async Task DeleteProductModifier(int id)
        {
            var item = GetProductModifiersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromProductModifier(id);
            DbService.TryDeleteEntity(DB.ProductModifiers, item);
        }
    
        [HttpDelete, Route("DeleteProductModifierLocalization")]
        [ShopSectionAccess(9)]
        public async Task DeleteProductModifierLocalization(int id)
        {
            var item = DB.ProductModifierLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetProductModifiersList().FirstOrDefault(o => o.Id == item?.ProductModifierId && !o.IsDeleted);

            CheckFromProductModifier(item?.ProductModifierId);
            DbService.TryDeleteLocalizationEntity(DB.ProductModifierLocalizations, item, mainModel);
        }




        #endregion

        #region Опции модификаторов

        [HttpGet, Route("GetProductModifierOption")]
        [ShopSectionAccess(1)]
        public async Task<ProductModifierItemDTO> GetProductModifierOption(int id)
        {
            var item = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromProductModifierOption(id);
            return (ProductModifierItemDTO)new ProductModifierItemDTO().CreateDTO(item);
        }

        [HttpGet, Route("GetProductModifierOptionLocalizations")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ProductModifierItemLocalizationDTO>> GetProductModifierOptionLocalizations(int id)
        {
            var localizations = DB.ProductModifierItemLocalizations.Include(o => o.LanguageEntity).Where(o => o.ProductModifierItemId == id && !o.IsDeleted);
            var mainEntity = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromProductModifierOption(id);
            return DbService.GetLocalizationModels(localizations, mainEntity, new ProductModifierItemLocalizationDTO()).Cast<ProductModifierItemLocalizationDTO>();
        }

        [HttpGet, Route("GetProductModifierOptionLocalization")]
        [ShopSectionAccess(1)]
        public async Task<ProductModifierItemLocalizationDTO> GetProductModifierOptionLocalization(int id)
        {
            var localization = DB.ProductModifierItemLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == localization?.ProductModifierItemId && !o.IsDeleted);

            CheckFromProductModifierOption(localization?.ProductModifierItemId);
            return (ProductModifierItemLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new ProductModifierItemLocalizationDTO());
        }





        [HttpPost, Route("CreateProductModifierOption")]
        [ShopSectionAccess(8)]
        public async Task<ProductModifierItemDTO> CreateProductModifierOption(ProductModifierItemDTO model)
        {
            CheckFromProductModifier(model.ProductModifierId);
            return (ProductModifierItemDTO)DbService.TryCreateEntity(DB.ProductModifierItems, model);
        }

        [HttpPost, Route("CreateProductModifierOptionLocalization")]
        [ShopSectionAccess(8)]
        public async Task<ProductModifierItemLocalizationDTO> CreateProductModifierOptionLocalization(int itemId, ProductModifierItemLocalizationDTO model)
        {
            var mainEntity = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == itemId);

            CheckFromProductModifierOption(itemId);
            return (ProductModifierItemLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.ProductModifierItems, mainEntity, model);
        }




        [HttpPut, Route("UpdateProductModifierOptionMain")]
        [ShopSectionAccess(5)]
        public async Task<ProductModifierItemDTO> UpdateProductModifierOptionMain(ProductModifierItemDTO model)
        {
            var item = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            CheckFromProductModifierOption(model.Id);
            return (ProductModifierItemDTO)DbService.TryUpdateEntity(DB.ProductModifierItems, model, item);
        }
      
        [HttpPut, Route("UpdateProductModifierOptionLocalization")]
        [ShopSectionAccess(6)]
        public async Task<ProductModifierItemLocalizationDTO> UpdateProductModifierOptionLocalization(ProductModifierItemLocalizationDTO model)
        {
            var localization = DB.ProductModifierItemLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == localization?.ProductModifierItemId && !o.IsDeleted);

            CheckFromProductModifier(localization.ProductModifierItemId);
            return (ProductModifierItemLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.ProductModifierItemLocalizations, localization, model, mainEntity);
        }







        [HttpDelete, Route("DeleteProductModifierOption")]
        [ShopSectionAccess(9)]
        public async Task DeleteProductModifierOption(int id)
        {
            var item = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromProductModifierOption(id);
            DbService.TryDeleteEntity(DB.ProductModifierItems, item);
        }
      
        [HttpDelete, Route("DeleteProductModifierOptionLocalization")]
        [ShopSectionAccess(9)]
        public async Task DeleteProductModifierOptionLocalization(int id)
        {
            var item = DB.ProductModifierItemLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == item?.ProductModifierItemId && !o.IsDeleted);

            CheckFromProductModifierOption(item?.ProductModifierItemId);
            DbService.TryDeleteLocalizationEntity(DB.ProductModifierItemLocalizations, item, mainModel);
        }

        #endregion

        #region Категории товаров

        [HttpGet, Route("GetProductCategories")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ShopProductCategoryDTO>> GetProductCategories(int offset, int count = 20)
        {
            var items = GetAvailableShopProductCategories().Skip(offset).Take(count);
            return new ShopProductCategoryDTO().CreateDTOs(items).Cast<ShopProductCategoryDTO>();
        }

        [HttpGet, Route("GetProductCategoriesFiltered")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ShopProductCategoryDTO>> GetProductCategoriesFiltered([FromQuery] SearchFilter filter)
        {
            var items = filter.FilterBase(GetAvailableShopProductCategories(), (item) => item.Title);
            return new ShopProductCategoryDTO().CreateDTOs(items).Cast<ShopProductCategoryDTO>();
        }

        [HttpGet, Route("GetProductCategory")]
        [ShopSectionAccess(1)]
        public async Task<ShopProductCategoryDTO> GetProductCategory(int id)
        {
            return (ShopProductCategoryDTO)DbService.TryGetOne(GetAvailableShopProductCategories(), id, new ShopProductCategoryDTO());
        }

        [HttpGet, Route("GetProductCategoryLocalizations")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<ShopProductCategoryLocalizationDTO>> GetProductCategoryLocalizations(int id)
        {
            var localizations = DB.ShopProductCategoryLocalizations.Include(o => o.LanguageEntity).Where(o => o.ShopProductCategoryId == id && !o.IsDeleted);
            var mainEntity = GetAvailableShopProductCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new ShopProductCategoryLocalizationDTO()).Cast<ShopProductCategoryLocalizationDTO>();
        }

        [HttpGet, Route("GetProductCategoryLocalization")]
        [ShopSectionAccess(1)]
        public async Task<ShopProductCategoryLocalizationDTO> GetProductCategoryLocalization(int id)
        {
            var localization = DB.ShopProductCategoryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableShopProductCategories().FirstOrDefault(o => o.Id == localization?.ShopProductCategoryId && !o.IsDeleted);

            return (ShopProductCategoryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new ShopProductCategoryLocalizationDTO());
        }





        [HttpPost, Route("CreateProductCategory")]
        [ShopSectionAccess(8)]
        public async Task<ShopProductCategoryDTO> CreateProductCategory(ShopProductCategoryDTO model)
        {
            return (ShopProductCategoryDTO)DbService.TryCreateAvailabilityEntity(DB.ShopProductCategories, model, this.Session);
        }

        [HttpPost, Route("CreateProductCategoryLocalization")]
        [ShopSectionAccess(8)]
        public async Task<ShopProductCategoryLocalizationDTO> CreateProductCategoryLocalization(int itemId, ShopProductCategoryLocalizationDTO localization)
        {
            var mainEntity = GetAvailableShopProductCategories().FirstOrDefault(o => o.Id == itemId);
            return (ShopProductCategoryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.ShopProductCategories, mainEntity, localization);
        }




        [HttpPut, Route("UpdateProductCategoryMain")]
        [ShopSectionAccess(5)]
        public async Task<ShopProductCategoryDTO> UpdateProductCategoryMain(ShopProductCategoryDTO model)
        {
            var item = GetAvailableShopProductCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ShopProductCategoryDTO)DbService.TryUpdateEntity(DB.ShopProductCategories, model, item);
        }

        [HttpPut, Route("UpdateProductCategoryLocalization")]
        [ShopSectionAccess(6)]
        public async Task<ShopProductCategoryLocalizationDTO> UpdateProductCategoryLocalization(ShopProductCategoryLocalizationDTO model)
        {
            var localization = DB.ShopProductCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableShopProductCategories().FirstOrDefault(o => o.Id == localization.ShopProductCategoryId && !o.IsDeleted);

            return (ShopProductCategoryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.ShopProductCategoryLocalizations, localization, model, mainEntity);
        }






        [HttpDelete, Route("DeleteProductCategory")]
        [ShopSectionAccess(9)]
        public async Task DeleteProductCategory(int id)
        {
            var item = GetAvailableShopProductCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.ShopProductCategories, item);
        }

        [HttpDelete, Route("DeleteProductCategoryLocalization")]
        [ShopSectionAccess(9)]
        public async Task DeleteProductCategoryLocalization(int id)
        {
            var item = DB.ShopProductCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailableShopProductCategories().FirstOrDefault(o => o.Id == item.ShopProductCategoryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.ShopProductCategoryLocalizations, item, mainModel);
        }


        #endregion

        #region Заказы

        [HttpGet, Route("GetOrders")]
        [ShopSectionAccess(2)]
        public async Task<IEnumerable<ShopOrderDTO>> GetOrders(int offset, int count = 20)
        {
            return new ShopOrderDTO().CreateDTOs(GetAvailableOrders(offset, count)).Cast<ShopOrderDTO>();
        }

        [HttpGet, Route("GetLastOrder")]
        [ShopSectionAccess(2)]
        public async Task<ShopOrderDTO> GetLastOrder()
        {
            return (ShopOrderDTO)new ShopOrderDTO().CreateDTO(GetAvailableOrders().FirstOrDefault());
        }

        [HttpGet, Route("GetOrder")]
        [ShopSectionAccess(2)]
        public async Task<ShopOrderDTO> GetOrder(int id)
        {
            return (ShopOrderDTO)DbService.TryGetOne(GetAvailableOrders(), id, new ShopOrderDTO());
        }

        [HttpPut, Route("UpdateOrderData")]
        [ShopSectionAccess(3)]
        public async Task UpdateOrderData(EditOrderAdminModel model)
        {
            var item = GetAvailableOrders().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                throw new Exception404("Запись по данному id не найдена");
            }

            if (model.Status == ShopOrderStatus.Basket
                || model.Status == ShopOrderStatus.Unpaid
                || model.Status == ShopOrderStatus.Canceled
                || model.Status == ShopOrderStatus.ReturnedByCustomer
                || model.Status == ShopOrderStatus.ReturnedByDeliveryService)
            {
                throw new Exception400("Неправильный статус");
            }

            DbService.UpdateEntity(DB.ShopOrders, model, item);
        }

        [HttpPut, Route("CancelOrder")]
        [ShopSectionAccess(4)]
        public async Task CancelOrder(int orderId, ShopOrderStatus status, ShopOrderReturn returnInfo)
        {
            var item = GetAvailableOrders().FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            if (item == null)
            {
                throw new Exception404("Запись по данному id не найдена");
            }

            if (status != ShopOrderStatus.Canceled 
                && status != ShopOrderStatus.ReturnedByCustomer
                && status != ShopOrderStatus.ReturnedByDeliveryService)
            {
                throw new Exception400("Неправильный статус");
            }

            item.Return = returnInfo;
            item.Status = status;
            DbService.UpdateEntity(DB.ShopOrders, item);
        }


        #endregion

        #region Промокоды

        [HttpGet, Route("GetPromocodes")]
        [ShopSectionAccess(1)]
        public async Task<IEnumerable<PromocodeDTO>> GetPromocodes(int offset, int count = 20)
        {
            return new PromocodeDTO().CreateDTOs(GetAvailablePromocodes().Skip(offset).Take(20)).Cast<PromocodeDTO>();
        }

        [HttpGet, Route("GetPromocode")]
        [ShopSectionAccess(1)]
        public async Task<PromocodeDTO> GetPromocode(int id)
        {
            return (PromocodeDTO)DbService.TryGetOne(GetAvailablePromocodes(), id, new PromocodeDTO());
        }



        [HttpPost, Route("CreatePromocode")]
        [ShopSectionAccess(8)]
        public async Task<PromocodeDTO> CreatePromocode(PromocodeDTO model)
        {
            return (PromocodeDTO)DbService.TryCreateAvailabilityEntity(DB.Promocodes, model, this.Session);
        }



        [HttpPut, Route("UpdatePromocode")]
        [ShopSectionAccess(5)]
        public async Task<PromocodeDTO> UpdatePromocode(PromocodeDTO model)
        {
            var item = GetAvailablePromocodes().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PromocodeDTO)DbService.TryUpdateEntity(DB.Promocodes, model, item);
        }



        [HttpDelete, Route("DeletePromocode")]
        [ShopSectionAccess(9)]
        public async Task DeletePromocode(int id)
        {
            var item = GetAvailablePromocodes().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Promocodes, item);
        }

        #endregion




        #region Матрицы цен
        [HttpPut, Route("UpdatePricingMatrix")]
        [ShopSectionAccess(7)]
        public async Task<PricingMatrixDTO> UpdatePricingMatrix(PricingMatrixDTO model)
        {
            var matrix = DB.GetIncludedPricingMatrix(model.Id);
            return (PricingMatrixDTO)DbService.TryUpdateEntity(DB.PricingMatrices, model, matrix);
        }

        [HttpPut, Route("SetDefaultProductPricingMatrix")]
        [ShopSectionAccess(8)]
        public async Task<PricingMatrixDTO> SetDefaultProductPricingMatrix(int productId)
        {
            var product = GetAvailableShopProducts().FirstOrDefault(o => o.Id == productId);
            if (product is null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }

            product.BasePricing = CreateDefaultPricingMatrix();
            DbService.UpdateEntity(DB.ShopProducts, product);

            return (PricingMatrixDTO)new PricingMatrixDTO().CreateDTO(product.BasePricing);
        }
    
        [HttpPut, Route("SetDefaultProductModifierItemPricingMatrix")]
        [ShopSectionAccess(8)]
        public async Task<PricingMatrixDTO> SetDefaultProductModifierItemPricingMatrix(int optionId)
        {
            var option = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == optionId);
            CheckFromProductModifierOption(optionId);

            option.Pricing = CreateDefaultPricingMatrix();
            DbService.UpdateEntity(DB.ProductModifierItems, option);

            return (PricingMatrixDTO)new PricingMatrixDTO().CreateDTO(option.Pricing);
        }
        #endregion

        [HttpPut, Route("UpdateAvailability")]
        [ShopSectionAccess(5)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            var admin = this.Session.User;

            hasThisModel |= DbService.GetAvailableModels(admin, DB.ShopProducts.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DbService.GetAvailableModels(admin, DB.ShopProductCategories.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }







        #region Private get available methods
        private IEnumerable<ShopProduct> GetAvailableShopProducts()
        {
            return DbService.GetAvailableModels(this.Session.User, GetProductsFullIncludedList()).Cast<ShopProduct>();
        }
        private IEnumerable<ShopProductCategory> GetAvailableShopProductCategories()
        {
            return DbService.GetAvailableModels(this.Session.User, GetProductCategoriesList()).Cast<ShopProductCategory>();
        }
        private IEnumerable<Promocode> GetAvailablePromocodes()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPromocodesList()).Cast<Promocode>();
        }


        private List<ShopOrder> GetAvailableOrders(int offset, int count = 20)
        {
            return GetAvailableOrders().Skip(offset).Take(count).ToList();
        }
        private List<ShopOrder> GetAvailableOrders()
        {
            var user = this.Session.User;

            var allOrders = GetOrdersList();
            var availableOrders = new List<ShopOrder>();

            if (user.RoleModel.Role == UserRole.Owner)
            {
                return allOrders.ToList();
            }

            foreach (var order in allOrders)
            {
                if (user.RoleModel.IsAllCountriesAccess)
                {
                    bool isForbidden = false;

                    foreach (var country in user.RoleModel.ForbiddenCountries)
                    {
                        if (order.CountryId == country.Id)
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

        private void CheckFromProductModifierOption(int? optionId)
        {
            var option = GetProductModifiersItemsList().FirstOrDefault(o => o.Id == optionId && !o.IsDeleted);
            if (optionId == null || option == null)
            {
                throw new Exception500("Внутренняя ошибка");
            }

            CheckFromProductModifier(option.ProductModifierId);
        }
        private void CheckFromProductModifier(int? modifierId)
        {
            var modifier = GetProductModifiersList().FirstOrDefault(o => o.Id == modifierId);
            if (modifierId == null || modifier == null)
            {
                throw new Exception500("Внутренняя ошибка");
            }

            CheckFromProduct(modifier.ShopProductId);
        }
        private void CheckFromProduct(int? productId)
        {
            var product = GetProductsFullIncludedList().FirstOrDefault(o => o.Id == productId && !o.IsDeleted);
            if (productId == null || product == null)
            {
                throw new Exception500("Внутренняя ошибка");
            }
        }

        #endregion 

        #region Private prepare model methods


        private void HandleProduct(ShopProduct entity, DBModelFillMode mode)
        {
            const string formFilename = "mainImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
               || mode == DBModelFillMode.Create)
            {
                if(entity.MainImage == null)
                {
                    entity.MainImage = new ShopProductImage();
                }

                entity.MainImage.ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }
        }
        private void HandleProductLocalization(ShopProductLocalization entity, DBModelFillMode mode)
        {
            const string formFilename = "mainImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
               || mode == DBModelFillMode.Create)
            {
                if (entity.MainImage == null)
                {
                    entity.MainImage = new ShopProductImage();
                }

                entity.MainImage.ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }
        }



        private void HandleProductAddPhoto(ShopProduct entity)
        {
            const string formFilename = "mainImg";

            entity.Images.Add(new ShopProductImage
            {
                ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image),
            });
        }
        private void HandleProductLocalizationAddPhoto(ShopProductLocalization entity)
        {
            const string formFilename = "mainImg";

            entity.Images.Add(new ShopProductImage
            {
                ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image),
            });
        }


        #endregion

        #region Private get included methods


        private IEnumerable<ShopProduct> GetProductsList()
        {
            return DB.ShopProducts.IncludeAvailability()
                                  .IncludePricing()
                                  .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                  .Include(o => o.MainImage)
                                  .Include(o => o.MainLanguage)
                                  .Where(o => !o.IsDeleted);
        }
        private IEnumerable<ShopProduct> GetProductsFullIncludedList()
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



        private IEnumerable<ProductModifier> GetProductModifiersList()
        {
            return DB.ProductModifiers.Include(o => o.Localizations)
                                      .Include(o => o.Options).ThenInclude(o => o.Localizations)
                                      .Include(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                      .Include(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                      .Where(o => !o.IsDeleted);
        }
        private IEnumerable<ProductModifierItem> GetProductModifiersItemsList()
        {
            return DB.ProductModifierItems.Include(o => o.Localizations)
                                          .Include(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                          .Include(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                          .Where(o => !o.IsDeleted);
        }


        private IEnumerable<ShopProductCategory> GetProductCategoriesList()
        {
            return DB.ShopProductCategories.IncludeAvailability()
                                           .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                           .Include(o => o.MainLanguage)
                                           .Where(o => !o.IsDeleted);
        }


        private IEnumerable<ShopOrder> GetOrdersList()
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



        private IEnumerable<Promocode> GetPromocodesList()
        {
            return DB.Promocodes.IncludeAvailability()
                                .Include(o => o.PriceFrom).ThenInclude(o => o.Costs)
                                .Include(o => o.PriceTo).ThenInclude(o => o.Costs)
                                .Where(o => !o.IsDeleted);
        }
        private IEnumerable<Promocode> GetPromocodesFullIncludedList()
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
