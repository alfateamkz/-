using Alfateam.Administration.Models.DTO.General;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.General;
using Alfateam.Core;
using Alfateam.ForPubilcWebsites.API.Abstractions;
using Alfateam.ForPubilcWebsites.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.ForPubilcWebsites.API.Controllers
{
    public class CommonController : AbsController
    {
        public CommonController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetProducts")]
        public async Task<ItemsWithTotalCount<ProductDTO>> GetProducts(SearchFilter filter)
        {
            var products = AdmininstrationDb.Products.Where(o => !o.IsDeleted && o.Type == ProductType.Public);
            return DBService.GetManyWithTotalCount<Product, ProductDTO>(products, filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition = entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return condition;
            });
        }
    }
}
