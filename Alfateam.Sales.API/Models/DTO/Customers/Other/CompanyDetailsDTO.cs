using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Customers.Other
{
    public class CompanyDetailsDTO : DTOModelAbs<CompanyDetails>
    {
        public CompanyEmployeesCountType? EmployeesCountType { get; set; }
        public CurrencyAndValueDTO AnnualTurnover { get; set; }
        public UTMMarkDTO? UTMMark { get; set; }


        public List<BankAccountInfoDTO> BankAccounts { get; set; } = new List<BankAccountInfoDTO>();
    }
}
