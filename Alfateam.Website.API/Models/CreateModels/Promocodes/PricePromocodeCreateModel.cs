using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.CreateModels.Promocodes
{
    public class PricePromocodeCreateModel : PromocodeCreateModel
    {
        public override string Discriminator => "PricePromocode";

        public PricingMatrix Discount { get; set; }

   
    }
}
