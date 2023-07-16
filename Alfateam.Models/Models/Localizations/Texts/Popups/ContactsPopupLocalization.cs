using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.Popups
{
    [GeneratorMetadata("Контакты - попап")]
    public class ContactsPopupLocalization : LocalizationModel
    {

        [GeneratorField("Позвонить нам")]
        public string CallUs { get; set; } = "Позвонить нам";


        [GeneratorField("Заказать звонок")]
        public string RequestCall { get; set; } = "Заказать звонок";
        [GeneratorField("Написать на почту")]
        public string ToMail { get; set; } = "Написать на почту";
        [GeneratorField("Написать в WhatsApp")]
        public string ToWhatsApp { get; set; } = "Написать в WhatsApp";
        [GeneratorField("Написать в Telegram")]
        public string ToTelegram { get; set; } = "Написать в Telegram";



        [GeneratorField("отправить")]
        public string Send { get; set; } = "отправить";
    }
}
