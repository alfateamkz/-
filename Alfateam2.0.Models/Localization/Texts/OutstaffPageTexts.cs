using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    public class OutstaffPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Аутстафф";
        public string Header { get; set; } = "АУТСТАФФ";
        public string ShortTextAfterHeader { get; set; } = "РАЗРАБОТЧИКИ - ДИХАЙНЕРЫ - АНАЛИТИКИ - ТЕСТЕРЫ";



        public string BtnLeaveRequest { get; set; } = "Оставить заявку";
        public string BtnFillBrief { get; set; } = "Заполнить бриф";



        public string AdvantagesBlockTitle { get; set; } = "Наши преимущества";
        public string AdvantagesBlockText1 { get; set; } = "Готовы к техническим собеседованиям";
        public string AdvantagesBlockText2 { get; set; } = "Многолетний опыт аутстаффа\r\nс различными компаниями";
        public string AdvantagesBlockText3 { get; set; } = "Широкий стек разработчиков";
        public string AdvantagesBlockText4 { get; set; } = "Оперативное усиление вашей команды";



        public string HowOutstaffWorksBlockTitle { get; set; } = "Как работает\r\nаутстафф";
        public string HowOutstaffWorksBlockHtmlContent1 { get; set; } = "Текст 1. Задать из админки";
        public string HowOutstaffWorksBlockHtmlContent2 { get; set; } = "Текст 2. Задать из админки";



        public string ReportsBlockTitle { get; set; } = "Отчетность";
        public string ReportsBlockHtmlContent1 { get; set; } = "Текст 1. Задать из админки";
        public string ReportsBlockHtmlContent2 { get; set; } = "Текст 2. Задать из админки";



        public string DevelopmentTypesBlockTitle { get; set; } = "Виды разработки";
        public string DevelopmentTypesBlockHtmlContent1 { get; set; } = "Текст 1. Задать из админки";
        public string DevelopmentTypesBlockHtmlContent2 { get; set; } = "Текст 2. Задать из админки";
    }
}
