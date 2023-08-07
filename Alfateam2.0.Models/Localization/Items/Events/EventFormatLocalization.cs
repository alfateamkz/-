using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Events
{
    public class EventFormatLocalization : LocalizableModel
    {
        public string Title { get; set; }

        /// <summary>
        /// Автоматическое свойство
        /// Указывает на главный объект (формат события)
        /// </summary>
        public int EventFormatId { get; set; }
    }
}
