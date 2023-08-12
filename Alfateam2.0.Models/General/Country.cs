using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность страны
    /// </summary>
    public class Country : AbsModel
    {
        public string Title { get; set; }
        public string Code { get; set; }

        /// <summary>
        /// Скрыта ли данная модель от пользователей сайта
        /// </summary>
        public bool IsHidden { get; set; }


        /// <summary>
        /// Главный официальный язык страны
        /// </summary>
        public Language OfficialMainLanguage { get; set; }
        public int OfficialMainLanguageId { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();



        public Currency MainCurrency { get; set; }
        public int MainCurrencyId { get; set; }
        public List<Currency> Currencies { get; set; } = new List<Currency>();




        /// <summary>
        /// Основной язык модели страны
        /// </summary>
        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<CountryLocalization> Localizations { get; set; } = new List<CountryLocalization>();






     
    }
}
