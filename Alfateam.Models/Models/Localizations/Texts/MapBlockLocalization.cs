using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts
{
    [GeneratorMetadata("Блок с картой")]
    public class MapBlockLocalization : LocalizationModel
    {
        [GeneratorField("КОНТАКТЫ")]
        public string MapContacts { get; set; } = "КОНТАКТЫ";
        [GeneratorField("Наш адрес:")]
        public string MapOurAddress { get; set; } = "Наш адрес:";
        [GeneratorField("Адрес офиса в Казахстане")]
        public string MapOffice1Address { get; set; } = "Офис 1: РК, г.Астана, ул. Александра Затаевича, д.10, кв.24";
        [GeneratorField("Адрес офиса в РФ")]
        public string MapOffice2Address { get; set; } = "Офис 2: РФ, Воронежская обл., г.Борисоглебск, ул. Терешковой, д.11";


        [GeneratorField("Наша почта:")]
        public string MapOurEmail { get; set; } = "Наша почта:";
        [GeneratorField("Телефон:")]
        public string MapOurPhone { get; set; } = "Телефон:";


        [GeneratorField("заказать звонок")]
        public string MapRequestCall { get; set; } = "заказать звонок";
    }
}
