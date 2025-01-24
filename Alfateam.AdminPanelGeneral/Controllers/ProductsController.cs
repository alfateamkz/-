using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.General;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.General;
using Alfateam.AdminPanelGeneral.API.Models.Filters;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers
{
    public class ProductsController : AbsController
    {
        public ProductsController(ControllerParams @params) : base(@params)
        {
        }

        #region Продукты

        [HttpGet, Route("GetProducts")]
        public async Task<ItemsWithTotalCount<ProductDTO>> GetProducts(ProductsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Product, ProductDTO>(GetAvailableProducts(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition = entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.ProductType != null)
                {
                    condition = entity.Type == filter.ProductType;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetProduct")]
        public async Task<ProductDTO> GetProduct(int id)
        {
            return (ProductDTO)DBService.TryGetOne(GetAvailableProducts(), id, new ProductDTO());
        }






        [HttpPost, Route("CreateProduct")]
        public async Task<ProductDTO> CreateProduct(ProductDTO model)
        {
            return (ProductDTO)DBService.TryCreateEntity(AdmininstrationDb.Products, model,
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление продукта", $"Добавлен продукт {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateProduct")]
        public async Task<ProductDTO> UpdateProduct(ProductDTO model)
        {
            var item = GetAvailableProducts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ProductDTO)DBService.TryUpdateEntity(AdmininstrationDb.Products, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование продукта", $"Отредактирован продукт с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteProduct")]
        public async Task DeleteProduct(int id)
        {
            var item = GetAvailableProducts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.Products, item);

            this.AddHistoryAction("Удаление продукта", $"Удален продукт {item.Title} с id={id}");
        }



        #endregion


        #region Private methods
        private IEnumerable<Product> GetAvailableProducts()
        {
            return AdmininstrationDb.Products.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
