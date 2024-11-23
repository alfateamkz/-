using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Customers.Other
{
    public class CompanyDetails : AbsModel
    {
        public CompanyEmployeesCountType? EmployeesCountType { get; set; }
        public CurrencyAndValue AnnualTurnover { get; set; }
        public UTMMark? UTMMark { get; set; }


        public List<BankAccountInfo> BankAccounts { get; set; } = new List<BankAccountInfo>();
    }
}
