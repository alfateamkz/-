using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Modifiers;

namespace Alfateam.Website.API.Models.ClientModels.Shop
{
    public class ProductModifierClientModel : ClientModel
    {
        public string Title { get; set; }

        /// <summary>
        /// Если Type == Color, то все Options должны быть типа ColorModifierItem
        /// </summary>
        public ProductModifierType Type { get; set; } = ProductModifierType.Combobox;
        public bool IsRequired { get; set; }
        public bool AllowMultipleSelection { get; set; }

        public List<ProductModifierItemClientModel> Options { get; set; } = new List<ProductModifierItemClientModel>();


        public static ProductModifierClientModel Create(ProductModifier item, int? langId,int? countryId)
        {

            var model = new ProductModifierClientModel();

            model.Id = item.Id;
            model.Title = item.Title;

            model.Type = item.Type;
            model.IsRequired = item.IsRequired;
            model.AllowMultipleSelection = item.AllowMultipleSelection;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            model.Options = ProductModifierItemClientModel.CreateItems(item.Options, langId,countryId);

            return model;
        }
        public static List<ProductModifierClientModel> CreateItems(List<ProductModifier> items, int? langId, int? countryId)
        {
            var models = new List<ProductModifierClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
