using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Shop
{
    public class ShopDeliveryAddressPageTexts : LocalizableModel
    {
        public string MiddleBreadcrump { get; set; } = "Мерч";
        public string LastBreadcrump { get; set; } = "Корзина";

        public string Header { get; set; } = "АДРЕС ДОСТАВКИ";


        public string AddressFormInputCountry { get; set; } = "Страна";
        public string AddressFormInputCountryPlaceholder { get; set; } = "Казахстан";

        public string AddressFormInputCity { get; set; } = "Город";
        public string AddressFormInputCityPlaceholder { get; set; } = "Астана";

        public string AddressFormInputAddress { get; set; } = "Адрес";
        public string AddressFormInputAddressPlaceholder { get; set; } = "ул. Александра Затаевича, д.10, кв. 24";




        public string AddressFormInputZIP { get; set; } = "Индекс";
        public string AddressFormInputZIPPlaceholder { get; set; } = "010017";

        public string AddressFormInputPhone { get; set; } = "Номер телефона";
        public string AddressFormInputPhonePlaceholder { get; set; } = "+77777777777";




        public string AddressFormInputName { get; set; } = "Имя";
        public string AddressFormInputNamePlaceholder { get; set; } = "Артур";

        public string AddressFormInputSurname { get; set; } = "Фамилия";
        public string AddressFormInputSurnamePlaceholder { get; set; } = "Бондарев";

        public string AddressFormInputPatronymic { get; set; } = "Отчество";
        public string AddressFormInputPatronymicPlaceholder { get; set; } = "Александрович";
    }
}
