using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral
{
    public class CCRefWithdrawalPageTexts : LocalizableModel
    {
        [Description("Заголовок: Вывод средств")]
        public string Header { get; set; } = "Вывод средств";

        [Description("Для физических лиц")]
        public string TabForIndividuals { get; set; } = "Для физических лиц";
        [Description("Для юридических лиц")]
        public string TabForLegalEntities { get; set; } = "Для юридических лиц";



        [Description("Счет")]
        public string AccountTitle { get; set; } = "Счет";
        [Description("Казахстанский тенге")]
        public string AccountPlaceholder { get; set; } = "Казахстанский тенге";


        [Description("Сумма")]
        public string SumTitle { get; set; } = "Сумма";
        [Description("100")]
        public string SumPlaceholder { get; set; } = "100";


        [Description("Номер карты")]
        public string PaymentInfoIndividualCardNumberTitle { get; set; } = "Номер карты";  
        [Description("1234 1234 1234 1234")]
        public string PaymentInfoIndividualCardNumberPlaceholder { get; set; } = "1234 1234 1234 1234";







        [Description("Наименование компании")]
        public string PaymentInfoLegalCompanyNameTitle { get; set; } = "Наименование компании";
        [Description("ТОО Альфатим ИТ")]
        public string PaymentInfoLegalCompanyNamePlaceholder { get; set; } = "ТОО Альфатим ИТ";


        [Description("Государство регистрации компании")]
        public string PaymentInfoLegalCountryTitle { get; set; } = "Государство регистрации компании";
        [Description("Казахстан")]
        public string PaymentInfoLegalCountryPlaceholder { get; set; } = "Казахстан";


        [Description("Регистрационный номер компании")]
        public string PaymentInfoLegalRegNumberTitle { get; set; } = "Регистрационный номер компании";
        [Description("0123456789012")]
        public string PaymentInfoLegalRegNumberPlaceholder { get; set; } = "0123456789012";


        [Description("Номер счета")]
        public string PaymentInfoLegalAccountNumberTitle { get; set; } = "Номер счета";
        [Description("12345678901234567890")]
        public string PaymentInfoLegalAccountNumberPlaceholder { get; set; } = "12345678901234567890";


        [Description("SWIFT номер")]
        public string PaymentInfoLegalSWIFTTitle { get; set; } = "SWIFT номер";
        [Description("AAAAKKKK")]
        public string PaymentInfoLegalSWIFTPlaceholder { get; set; } = "AAAAKKKK";





        [Description("На счете сумма меньше, чем указано к выводу")]
        public string ErrorInsufficientMoney { get; set; } = "На счете сумма меньше, чем указано к выводу";
        
        [Description("На доступная сумма к выводу меньше, чем указано к выводу")]
        public string ErrorNotAvailableMoney { get; set; } = "На доступная сумма к выводу меньше, чем указано к выводу";
    }
}
