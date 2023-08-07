using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Events
{
    public class EventCategoryLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        /// <summary>
        /// Автоматическое свойство, указывающее на главный объект
        /// </summary>
        public int EventCategoryId { get; set; }
    }
}
