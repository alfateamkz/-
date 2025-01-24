using Alfateam.Administration.Models.Enums;
using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters
{
    public class ProductsSearchFilter : SearchFilter
    {
        public ProductType ProductType { get; set; }
    }
}
