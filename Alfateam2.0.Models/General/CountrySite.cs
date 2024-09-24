using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность раздела сайта по стране
    /// </summary>
    public class CountrySite : AbsModel
    {
        public Language MainLanguage { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();

        public Currency MainCurrency { get; set; }



    }
}
