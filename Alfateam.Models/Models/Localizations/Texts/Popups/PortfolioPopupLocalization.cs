using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.Popups
{
    [GeneratorMetadata("Карточка портфолио - попап")]
    public class PortfolioPopupLocalization : LocalizationModel
    {

        [GeneratorField("Дата добавления:")]
        public string AddedAt { get; set; } = "Дата добавления: ";
        [GeneratorField("Дата добавления - маска DateTime")]
        public string AddedAtDateMask { get; set; } = "dd.MM.yyyy";



        [GeneratorField("перейти на сайт")]
        public string GoToSite { get; set; } = "перейти на сайт";
        [GeneratorField("закрыть")]
        public string Close { get; set; } = "закрыть";
    }
}
