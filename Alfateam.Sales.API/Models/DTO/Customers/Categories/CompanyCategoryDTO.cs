using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Customers.Categories
{
    public class CompanyCategoryDTO : DTOModelAbs<CompanyCategory>
    {
        public string Title { get; set; }
    }
}
