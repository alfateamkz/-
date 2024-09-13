using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Modifiers;

namespace Alfateam.Website.API.Models.DTO.Shop
{
    public class ProductModifierItemDTO : DTOModel<ProductModifierItem>
    {
        public string Title { get; set; }
        public List<CostDTO> Costs { get; set; } = new List<CostDTO>();


        [HiddenFromClient]
        public PricingMatrix Pricing { get; set; }


        public int MainLanguageId { get; set; }


        public static ProductModifierItemDTO Create(ProductModifierItem item, int? langId, int? countryId)
        {

            var model = new ProductModifierItemDTO();

            model.Id = item.Id;
            model.Title = item.Title;

            var costs = GetLocalCosts(item.Pricing, countryId);
            model.Costs = CostDTO.CreateItemsWithLocalization(costs, langId) as List<CostDTO>;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            return model;
        }
        public static List<ProductModifierItemDTO> CreateItems(List<ProductModifierItem> items, int? langId, int? countryId)
        {
            var models = new List<ProductModifierItemDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
