using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop.Modifiers;

namespace Alfateam.Website.API.Models.CreateModels.Shop
{
    public class ProductModifierCreateModel : CreateModel<ProductModifier>
    {
        public string Title { get; set; }


        public ProductModifierType Type { get; set; } = ProductModifierType.Combobox;
        public bool IsRequired { get; set; }
        public bool AllowMultipleSelection { get; set; }


        public int MainLanguageId { get; set; }
    }
}
