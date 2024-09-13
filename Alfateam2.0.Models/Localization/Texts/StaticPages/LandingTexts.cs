using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages
{
    public class LandingTexts : LocalizableModel
    {
        public string MainBlockHeader { get; set; } = "СОЗДАЕМ\r\nСОВРЕМЕННОЕ";
        public string MainBlockShortText { get; set; } = "ПЕРЕЙДИ НА НОВЫЙ\r\nУРОВЕНЬ БИЗНЕСА";
        public string MainBlockStartProjectBtn { get; set; } = "ЗАПУСИТЬ ПРОЕКТ";




        public string OurProjectsBlockHeader { get; set; } = "Наши кейсы";
        public string OurProjectsBlockShortText { get; set; } = "Готовы показать все то, что мы делали раньше :)";
        public string OurProjectsBlockMoreBtn { get; set; } = "Еще";



        public string ProjectDevelopmentStagesHeader { get; set; } = "Этапы создания проекта";
        public string ProjectDevelopmentStagesShortText { get; set; } = "Наши клиенты доверяют нам своим проекты и делятся впечатлениями о нашей компании";
        public string ProjectDevelopmentStage1 { get; set; } = "Утверждение ТЗ";
        public string ProjectDevelopmentStage2 { get; set; } = "Создание прототипа";
        public string ProjectDevelopmentStage3 { get; set; } = "Разработка";
        public string ProjectDevelopmentStage4 { get; set; } = "Верстка";
        public string ProjectDevelopmentStage5 { get; set; } = "Оптимизация";






        public string OurContactsBlockTitle { get; set; } = "Наши контакты";
        public string OurContactsBlockShortText { get; set; } = "Связывайся с нами как удобно - лично или онлайн!";



        public string OurContactsBlockOurAddresses { get; set; } = "Наш адрес";
        public string OurContactsBlockAddress { get; set; } = "Казахстан, г. Астана, ул. Александр Затаевича, д. 10, кв. 24" +
            "\r\n\r\nРоссийская Федерация, Воронежская обл., г. Борисоглебск, ул. Терешкова, д. 11";


        public string OurContactsBlockOurEmails { get; set; } = "Электронная почта";
        public string OurContactsBlockEmails { get; set; } = "sales@alfateam.co";


        public string OurContactsBlockOurPhones { get; set; } = "Номер телефона";
        public string OurContactsBlockPhones { get; set; } = "wa: +7 (951) 854-97-17 \r\n tel: +7 (705) 741-74-83";






        public string ContactMeFormInputNameTitle { get; set; } = "Ваше имя";
        public string ContactMeFormInputNamePlaceholder { get; set; } = "Ваше имя";


        public string ContactMeFormInputPhoneTitle { get; set; } = "Ваш номер телефона";
        public string ContactMeFormInputPhonePlaceholder { get; set; } = "Ваш номер";


        public string ContactMeFormInputTextTitle { get; set; } = "Оставьте ваше сообщение";
        public string ContactMeFormInputTextPlaceholder { get; set; } = "Введите обращение";


        public string ContactMeFormSendBtn { get; set; } = "Отправить";



        public string ContactMeFormErrorValidation { get; set; } = "Заполните все необходимые поля";
        public string ContactMeFormErrorPhone { get; set; } = "Проверьте корректность заполнения номера телефона";
    }
}
