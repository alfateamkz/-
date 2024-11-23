namespace Alfateam.Sales.API.Models.Analytics.Sales.Forgotten
{
    public class SalesForgottenOrdersStats
    {
        public int Count => Orders.Count;
        public List<SalesForgottenOrdersItem> Orders { get; set; } = new List<SalesForgottenOrdersItem>();
    }
}
