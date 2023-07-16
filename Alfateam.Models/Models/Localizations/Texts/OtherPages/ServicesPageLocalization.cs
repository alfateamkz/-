using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.OtherPages
{
    [GeneratorMetadata("Страница услуг")]
    public class ServicesPageLocalization : LocalizationModel
    {
        [GeneratorField("СТОИМОСТЬ")]
        public string Header { get; set; } = "СТОИМОСТЬ";


        [GeneratorField("быстрый отлик на заказ")]
        public string Col1Text { get; set; } = "быстрый отлик на заказ";
        [GeneratorField("реализация в короткие сроки")]
        public string Col2Text { get; set; } = "реализация в короткие сроки";
        [GeneratorField("тестирование проекта")]
        public string Col3Text { get; set; } = "тестирование проекта";
        [GeneratorField("техническая поддержка")]
        public string Col4Text { get; set; } = "техническая поддержка";
    }
}
