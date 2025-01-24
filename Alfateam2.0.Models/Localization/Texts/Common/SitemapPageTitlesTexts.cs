using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Common
{
    public class SitemapPageTitlesTexts : LocalizableModel
    {
        public SitemapPageTitlesTexts()
        {

        }
        public SitemapPageTitlesTexts(int languageId) : base(languageId)
        {

        }


        public string MainPage { get; set; } = "Главная страница";



        public string Compliance { get; set; } = "Комплаенс";
        public string Outstaff { get; set; } = "Аутстафф";
        public string Patners { get; set; } = "Партнеры";
        public string Reviews { get; set; } = "Отзывы";
        public string PrivacyPolicy { get; set; } = "Политика конфедициальности";
        public string Stats { get; set; } = "Статистика";
        public string Chronology { get; set; } = "Хронология";
        public string AgreementSearch { get; set; } = "Поиск договора";


        public string AboutUs { get; set; } = "О нас";
        public string Contacts { get; set; } = "Контакты";



        public string SignIn { get; set; } = "Вход";
        public string SignUp { get; set; } = "Регистрация";
        public string RestorePassword { get; set; } = "Восстановление пароля";



        public string Services { get; set; } = "Услуги";
        public string Team { get; set; } = "Команда";
        public string ProjectManagerJobLanding { get; set; } = "Работа менеджером";
        public string SalesManagerJobLanding { get; set; } = "Работа продажником";
        public string EmployeeJobLanding { get; set; } = "Работа разработчиком";
        public string JobVacancies { get; set; } = "Вакансии";
        public string Shop { get; set; } = "Магазин";
        public string Posts { get; set; } = "Новости";
        public string Events { get; set; } = "События";
        public string Portfolio { get; set; } = "Портфолио";
    }
}
