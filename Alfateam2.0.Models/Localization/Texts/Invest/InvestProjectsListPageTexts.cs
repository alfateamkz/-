using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Invest
{
    public class InvestProjectsListPageTexts : LocalizableModel
    {
        public string MainBlockHeader { get; set; } = "ГРАМОТНЫЕ ИНВЕСТИЦИИ С ALFATEAM";
        public string MainBlockColumn1 { get; set; } = "Колонка 1. Заполнить из админки";
        public string MainBlockColumn2 { get; set; } = "Колонка 2. Заполнить из админки";
        public string MainBlockColumn3 { get; set; } = "Колонка 3. Заполнить из админки";




        public string MetricYearsOfWork { get; set; } = "Года работы";
        public string MetricProjectsCount { get; set; } = "Проектов";
        public string MetricCountriesCount { get; set; } = "Стран";
        public string MetricOfficesCount { get; set; } = "Офиса";
        public string MetricCompanyProductsCount { get; set; } = "Продуктов";
        public string MetricCompanyEmployeesCount { get; set; } = "Сотрудников";




        public string InvestProjectsHeader { get; set; } = "Инвестиционные проекты";
        public string OurPartnersHeader { get; set; } = "Наши партнеры";



        public string PrinciplesOfWorkHeader { get; set; } = "ИНСТРУМЕНТЫ И ПРИНЦИПЫ РАБОТЫ";

        public string PrinciplesOfWork_Header1 { get; set; } = "Принцип работы 1(заголовок). Заполнить из админки";
        public string PrinciplesOfWork_Text1 { get; set; } = "Принцип работы 1(описание). Заполнить из админки";

        public string PrinciplesOfWork_Header2 { get; set; } = "Принцип работы 2(заголовок). Заполнить из админки";
        public string PrinciplesOfWork_Text2 { get; set; } = "Принцип работы 2(описание). Заполнить из админки";

        public string PrinciplesOfWork_Header3 { get; set; } = "Принцип работы 3(заголовок). Заполнить из админки";
        public string PrinciplesOfWork_Text3 { get; set; } = "Принцип работы 3(описание). Заполнить из админки";




        public string OurInvestorsReviewsHeader { get; set; } = "Отзывы наших инвесторов";







        public string ContactWithUsFormHeader { get; set; } = "Свяжитесь с нами";

        public string ContactWithUsFormInputNameTitle { get; set; } = "Ваше имя";
        public string ContactWithUsFormInputNamePlaceholder { get; set; } = "Введите ваше имя";


        public string ContactWithUsFormInputPhoneTitle { get; set; } = "Ваш номер телефона";
        public string ContactWithUsFormInputPhonePlaceholder { get; set; } = "+77051234567";

        public string ContactWithUsFormInputTextTitle { get; set; } = "Оставьте ваше сообщение";
        public string ContactWithUsFormInputTextPlaceholder { get; set; } = "Введите здесь ваш вопрос или предожение";

        public string ContactWithUsFormSendBtn { get; set; } = "Отправить";




        public string ContactWithUsFormErrorValidation { get; set; } = "Заполните все необходимые поля";
        public string ContactWithUsFormErrorPhoneValidation { get; set; } = "Введите номер телефона в правильном формате";
        public string ContactWithUsFormSuccess { get; set; } = "Ваше обращение принято. Мы скоро свяжемся с вами";
    }

}
