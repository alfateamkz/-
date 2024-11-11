using Alfateam.Sales.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO
{
    public class CustomerCategoryDTO : DTOModelAbs<CustomerCategory>
    {
        public string Title { get; set; }
    }
}
