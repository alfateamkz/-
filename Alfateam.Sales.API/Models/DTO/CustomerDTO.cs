using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO
{
    public class CustomerDTO : DTOModelAbs<Customer>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        [ForClientOnly]
        public CustomerCategory Category { get; set; }
        [HiddenFromClient]
        public int CategoryId { get; set; }



        public CompanyInfoDTO? CompanyInfo { get; set; }


        public string Comment { get; set; }

    }
}
