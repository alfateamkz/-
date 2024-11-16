using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Enums.Analytics;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.Analytics.Invoices;
using Alfateam.Sales.API.Models.DTO;
using Alfateam.Sales.API.Models.SearchFilters.Analytics;
using Alfateam.Sales.Models.Invoices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.Analytics
{
    public class AnalyticsInvoicesController : AbsController
    {
        public AnalyticsInvoicesController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetInvoicesSumStats")]
        public async Task<InvoicesSumStats> GetInvoicesSumStats(AnalyticsInvoicesFilter filter)
        {
            return InvoicesSumStats.Create(GetAvailableInvoicesByFilter(filter));
        }

        [HttpGet, Route("GetInvoicesTopByEmployees")]
        public async Task<InvoicesTopByEmployees> GetInvoicesTopByEmployees(AnalyticsInvoicesTopByEmployeesFilter filter)
        {
            var invoices = GetAvailableInvoicesByFilter(filter);
            invoices = GetAvailableInvoicesByStatusType(invoices, filter.Type);

            var stats = new InvoicesTopByEmployees
            {
                Currency = DBService.TryGetOne(DB.Currencies, filter.CurrencyId),
                ParameterType = filter.ParameterType,
                Type = filter.Type
            };
            return stats.Fill(invoices, this.AuthorizedUser.Id);
        }

        [HttpGet, Route("GetInvoicesByManagersStats")]
        public async Task<InvoicesByManagersStats> GetInvoicesByManagersStats(InvoicesByManagersStatsFilter filter)
        {
            var invoices = GetAvailableInvoicesByFilter(filter);

            var stats = new InvoicesByManagersStats
            {
                Currency = DBService.TryGetOne(DB.Currencies, filter.CurrencyId),
                ParameterType = filter.ParameterType,
            };
            return stats.Fill(invoices);
        }

        





        #region Private GetAvailableInvoices Methods

        private IEnumerable<Invoice> GetAvailableInvoices()
        {
            return DB.Invoices.Where(o => !o.IsDeleted && o.Customer.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<Invoice> GetAvailableInvoicesByFilter(AnalyticsInvoicesFilter filter)
        {
            var invoices = GetAvailableInvoices();

            invoices = GetAvailableInvoicesByPeriod(invoices, filter.DateFilter);
            invoices = GetAvailableInvoicesByEmployees(invoices, filter.ByEmployeesFilter);

            return invoices;
        }


        private IEnumerable<Invoice> GetAvailableInvoicesByPeriod(IEnumerable<Invoice> invoices, DateFilterModel filter)
        {
            var period = filter.GetPeriod();
            return invoices.Where(o => o.CreatedAt.Date >= period.From && o.CreatedAt.Date <= period.To);
        }
        private IEnumerable<Invoice> GetAvailableInvoicesByEmployees(IEnumerable<Invoice> invoices, ByEmployeesFilter filter)
        {
            var allUsers = DB.Users.Where(o => o.BusinessCompanyId == this.CompanyId && !o.IsDeleted);

            var employees = filter.GetEmployees(allUsers);
            return invoices.Where(o => allUsers.Any(i => i.Id == o.CreatedById));
        }
        private IEnumerable<Invoice> GetAvailableInvoicesByStatusType(IEnumerable<Invoice> invoices, InvoiceStatusType type)
        {
            switch (type)
            {
                case InvoiceStatusType.Paid:
                    return invoices.Where(o => o.PaidInfoId != null);
                case InvoiceStatusType.Unpaid:
                    return invoices.Where(o => o.PaidInfoId == null);
                case InvoiceStatusType.Rejected:
                    return invoices.Where(o => o.RejectedInfoId == null);
                case InvoiceStatusType.Overdue:
                    return invoices.Where(o => o.IsOverdue);
            }
            throw new NotImplementedException();
        }


        #endregion
    }
}
