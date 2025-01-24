using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Enums;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.Customers
{
    public class ProductCustomersSearchFilter : SearchFilter
    {
        public PublicProductName ProductName { get; set; }
    }
}
