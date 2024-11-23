using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.API.Models.DTO.Customers.Categories;
using Alfateam.Sales.API.Models.DTO.Customers.Other;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Customers
{
    public class CompanyDTO : AbsCanBeCustomerDTO<Company>
    {
        public CompanyInfoDTO Info { get; set; }
        public CompanyDetailsDTO Details { get; set; }





        [ForClientOnly]
        public CompanyCategoryDTO Category { get; set; }
      
        [HiddenFromClient]
        public int CategoryId { get; set; }







        [ForClientOnly]
        public CompanyFieldOfActivityDTO FieldOfActivity { get; set; }
     
        [HiddenFromClient]
        public int FieldOfActivityId { get; set; }
    }
}
