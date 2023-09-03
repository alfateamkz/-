using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions
{
    /// <summary>
    /// Базовая сущность контента
    /// </summary>
    public abstract class ContentModel : AvailabilityModel
    {

        /// <summary>
        /// Автоматическое поле
        /// Указывает на сущность BusinessContent
        /// По нему уже можем определять Id бизнеса путем нехитрых манипуляций
        /// </summary>
        public int BusinessContentId { get; set; }
        public BusinessContent BusinessContent { get; set; }
    }
}
