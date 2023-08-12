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
    /// Сущность валюты
    /// </summary>
    public class Currency : AbsModel
    {
        public string Title { get; set; }   
        public string Code { get; set; }
        public string Symbol { get; set; }


        /// <summary>
        /// Скрыта ли данная модель от пользователей сайта
        /// </summary>
        public bool IsHidden { get; set; }



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<CurrencyLocalization> Localizations { get; set; } = new List<CurrencyLocalization>();


        [JsonIgnore]
        public List<Country> CountryManyToManyRefs { get; set; } = new List<Country>();
    }
}
