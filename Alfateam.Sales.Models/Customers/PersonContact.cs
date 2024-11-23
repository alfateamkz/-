using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Customers
{
    public class PersonContact : AbsCanBeCustomer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        [NotMapped]
        public string FIO => $"{Surname} {Name} {Patronymic}";


        public PersonContactCategory Category { get; set; }
        public int CategoryId { get; set; }

    }
}
