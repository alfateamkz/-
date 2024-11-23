using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Customers.Other
{
    public class CompanyFieldOfActivityDTO : DTOModelAbs<CompanyFieldOfActivity>
    {
        public string Title { get; set; }
    }
}
