using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Customers.Categories
{
    public class PersonContactCategoryDTO : DTOModelAbs<PersonContactCategory>
    {
        public string Title { get; set; }
    }
}
