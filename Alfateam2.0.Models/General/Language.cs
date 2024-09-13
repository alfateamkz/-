using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность языка
    /// </summary>
    [Table("LanguageEntities")]
    public class Language : AbsModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public bool IsRightToLeft { get; set; }


        /// <summary>
        /// Скрыта ли данная модель от пользователей сайта
        /// </summary>
        public bool IsHidden { get; set; }



        /// <summary>
        /// Основной язык модели страны
        /// Язык будет здесь русский по идее, т.к. в разных языках название языка разные
        /// </summary>
        public Language? MainLanguage { get; set; }
        public int? MainLanguageId { get; set; }
        public List<LanguageLocalization> Localizations { get; set; } = new List<LanguageLocalization>();




        [JsonIgnore]
        public List<Country> CountryManyToManyRefs { get; set; } = new List<Country>();
    }
}
