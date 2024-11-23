using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Sales.API.Models.DTO.Customers
{
    public class PersonContactDTO : AbsCanBeCustomerDTO<PersonContact>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        [ForClientOnly]
        public string FIO => $"{Surname} {Name} {Patronymic}";





        [ForClientOnly]
        public PersonContactCategory Category { get; set; }

        [HiddenFromClient]
        public int CategoryId { get; set; }
    }
}
