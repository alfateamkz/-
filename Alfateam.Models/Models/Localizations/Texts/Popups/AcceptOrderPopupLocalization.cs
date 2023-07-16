using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.Popups
{
    [GeneratorMetadata("Заявка принята - попап")]
    public class AcceptOrderPopupLocalization : LocalizationModel
    {
        [GeneratorField("Ваша заявка принята!")]
        public string Header { get; set; } = "Ваша заявка принята!";
        [GeneratorField("Мы ответим Вам в самое ближайшее время.")]
        public string Text { get; set; } = "Мы ответим Вам в самое ближайшее время.";
        [GeneratorField("закрыть")]
        public string Close { get; set; } = "закрыть";
    }
}
