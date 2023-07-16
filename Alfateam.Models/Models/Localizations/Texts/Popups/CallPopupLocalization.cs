using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.Popups
{
    [GeneratorMetadata("Оставьте номер телефона - попап")]
    public class CallPopupLocalization : LocalizationModel
    {
        [GeneratorField("Оставьте свой номер телефона и мы свяжемся с вами в ближайшее время")]
        public string Header { get; set; } = "Оставьте свой номер телефона и мы свяжемся с вами в ближайшее время";


        [GeneratorField("*нажимая кнопку отправить, вы соглашаетесь")]
        public string PolicyTextMain { get; set; } = "*нажимая кнопку отправить, вы соглашаетесь";
        [GeneratorField("с политикой конфиденциальности")]
        public string PolicyTextLink { get; set; } = "с политикой конфиденциальности";



        [GeneratorField("отправить")]
        public string Send { get; set; } = "отправить";
    }
}
