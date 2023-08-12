using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.EditModels.Promocodes
{
    public class PricePromocodeEditModel : PromocodeEditModel
    {
        public override string Discriminator => "PricePromocode";

        public PricingMatrix Discount { get; set; }

   
    }
}
