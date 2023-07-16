using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts
{
    [GeneratorMetadata("Общие слова")]
    public class SharedLocalization : LocalizationModel
    {

        [GeneratorField("оставить заявку")]
        public string MakeOrder { get; set; } = "оставить заявку";


        [GeneratorField("НАШИ РАБОТЫ")]
        public string FooterOurWorks { get; set; } = "НАШИ РАБОТЫ";
        [GeneratorField("СТОИМОСТЬ УСЛУГ")]
        public string FooterCosts { get; set; } = "СТОИМОСТЬ УСЛУГ";
        [GeneratorField("НОВОСТИ")]
        public string FooterNews { get; set; } = "НОВОСТИ";
        [GeneratorField("ПОЛИТИКА КОНФЕДИЦИАЛЬНОСТИ")]
        public string FooterPrivacyPolicy { get; set; } = "ПОЛИТИКА КОНФЕДИЦИАЛЬНОСТИ";



        [GeneratorField("Реквизиты фирмы в Казахстане")]
        public string FooterLegalInfoKZ { get; set; } = "ТОО \"Alfateam\" БИН: 220640023065";
        [GeneratorField("Реквизиты фирмы в РФ")]
        public string FooterLegalInfoRF { get; set; } = "хуйхуйхухйхуйхуйхйу";
    }
}
