using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Customers
{
    public class Company : AbsCanBeCustomer
    {

        public CompanyInfo Info { get; set; }
        public CompanyDetails Details { get; set; }



        public CompanyCategory Category { get; set; }
        public int CategoryId { get; set; }


        public CompanyFieldOfActivity FieldOfActivity { get; set; }
        public int FieldOfActivityId { get; set; }

    }
}
