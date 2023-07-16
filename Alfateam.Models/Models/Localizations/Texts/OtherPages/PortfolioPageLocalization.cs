using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.OtherPages
{
    [GeneratorMetadata("Страница с портфолио")]
    public class PortfolioPageLocalization : LocalizationModel
    {

        [GeneratorField("НАШИ РАБОТЫ")]
        public string Header { get; set; } = "НАШИ РАБОТЫ";
        [GeneratorField("Категории")]
        public string Categories { get; set; } = "Категории";
        [GeneratorField("Все категории")]
        public string AllCategories { get; set; } = "Все категории";
    }
}
