using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.OtherPages
{
    [GeneratorMetadata("Страница политики конфедициальности")]
    public class PrivacyPageLocalization : LocalizationModel
    {
        [GeneratorField("ПОЛИТИКА КОНФЕДИЦИАЛЬНОСТИ")]
        public string Header { get; set; } = "ПОЛИТИКА КОНФЕДИЦИАЛЬНОСТИ";
        [GeneratorField("ПОЛИТИКА КОНФЕДИЦИАЛЬНОСТИ - текст")]
        public string Content { get; set; } = "Обещаю не брать в рот";
    }
}
