using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral
{
    public class CCRefWithdrawalPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Вывод средств";

        public string TabForIndividuals { get; set; } = "Для физических лиц";
        public string TabForLegalEntities { get; set; } = "Для юридических лиц";




        public string AccountTitle { get; set; } = "Счет";
        public string AccountPlaceholder { get; set; } = "Казахстанский тенге";

        public string SumTitle { get; set; } = "Сумма";
        public string SumPlaceholder { get; set; } = "100";



        public string PaymentInfoIndividualCardNumberTitle { get; set; } = "Номер карты";
        public string PaymentInfoIndividualCardNumberPlaceholder { get; set; } = "1234 1234 1234 1234";








        public string PaymentInfoLegalCompanyNameTitle { get; set; } = "Наименование компании";
        public string PaymentInfoLegalCompanyNamePlaceholder { get; set; } = "ТОО Альфатим ИТ";

        public string PaymentInfoLegalCountryTitle { get; set; } = "Государство регистрации компании";
        public string PaymentInfoLegalCountryPlaceholder { get; set; } = "Казахстан";

        public string PaymentInfoLegalRegNumberTitle { get; set; } = "Регистрационный номер компании";
        public string PaymentInfoLegalRegNumberPlaceholder { get; set; } = "0123456789012";


        public string PaymentInfoLegalAccountNumberTitle { get; set; } = "Номер счета";
        public string PaymentInfoLegalAccountNumberPlaceholder { get; set; } = "12345678901234567890";

        public string PaymentInfoLegalSWIFTTitle { get; set; } = "SWIFT номер";
        public string PaymentInfoLegalSWIFTPlaceholder { get; set; } = "AAAAKKKK";






        public string ErrorInsufficientMoney { get; set; } = "На счете сумма меньше, чем указано к выводу";
        public string ErrorNotAvailableMoney { get; set; } = "На доступная сумма к выводу меньше, чем указано к выводу";
    }
}
