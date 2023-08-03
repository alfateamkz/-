using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Модель часового пояса
    /// </summary>
    public class TimeZone : AbsModel
    {
        /// <summary>
        /// Название. Например: Москва
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Отступ времени от Гринвича 
        /// </summary>
        public TimeSpan Offset { get; set; }
    }
}
