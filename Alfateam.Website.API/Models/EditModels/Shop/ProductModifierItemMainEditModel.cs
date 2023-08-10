using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.EditModels.Shop
{
    public class ProductModifierItemMainEditModel : EditModel<ProductModifierItem>
    {
        public string Title { get; set; }
        public PricingMatrix Pricing { get; set; }


        public int MainLanguageId { get; set; }

    }
}
