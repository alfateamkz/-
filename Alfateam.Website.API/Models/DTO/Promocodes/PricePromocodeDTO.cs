using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;

namespace Alfateam.Website.API.Models.DTO.Promocodes
{
    public class PricePromocodeDTO : PromocodeDTO
    {
        public override string Discriminator => "PricePromocode";
        public PricingMatrix Discount { get; set; }
    }
}
