using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models
{
    public class ShopOrderItemEditModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public double Amount { get; set; }
    }
}
