using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Modifiers
{
    /// <summary>
    /// Сущность модификатора товара
    /// </summary>
    public class ProductModifier : AbsModel
    {
        public string Title { get; set; }

        /// <summary>
        /// Если Type == Color, то все Options должны быть типа ColorModifierItem
        /// </summary>
        public ProductModifierType Type { get; set; } = ProductModifierType.Combobox;
        public bool IsRequired { get; set; }
        public bool AllowMultipleSelection { get; set; }

        public List<ProductModifierItem> Options { get; set; } = new List<ProductModifierItem>();



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<ProductModifierLocalization> Localizations { get; set; } = new List<ProductModifierLocalization>();
    }
}
