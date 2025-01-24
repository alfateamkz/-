using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.ID.Models.Enums;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.Customers
{
    public class CustomerPaymentsSearchFilter : SearchFilter
    {
        public PaymentStatus? Status { get; set; }

        public string? CurrencyCode { get; set; }
        public decimal? SumFrom { get; set; }
        public decimal? SumTo { get; set; }



        public DateTime? PaidAtFrom { get; set; }
        public DateTime? PaidAtTo { get; set; }


        public string? ProductIdentifier { get; set; }
        public int? UserId { get; set; }
    }
}
