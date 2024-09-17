using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop.Modifiers;

namespace Alfateam.Website.API.Models.DTO.Shop
{
    public class ProductModifierDTO : DTOModel<ProductModifier>
    {
        public string Title { get; set; }



        /// <summary>
        /// Если Type == Color, то все Options должны быть типа ColorModifierItem
        /// </summary>
        public ProductModifierType Type { get; set; } = ProductModifierType.Combobox;
        public bool IsRequired { get; set; }
        public bool AllowMultipleSelection { get; set; }

        public List<ProductModifierItemDTO> Options { get; set; } = new List<ProductModifierItemDTO>();




        public int MainLanguageId { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int ShopProductId { get; set; }


        public static ProductModifierDTO Create(ProductModifier item, int? langId, int? countryId)
        {

            var model = new ProductModifierDTO();

            model.Id = item.Id;
            model.Title = item.Title;

            model.Type = item.Type;
            model.IsRequired = item.IsRequired;
            model.AllowMultipleSelection = item.AllowMultipleSelection;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            model.Options = ProductModifierItemDTO.CreateItems(item.Options, langId, countryId);

            return model;
        }
        public static List<ProductModifierDTO> CreateItems(List<ProductModifier> items, int? langId, int? countryId)
        {
            var models = new List<ProductModifierDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
