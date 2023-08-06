using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Events
{
    /// <summary>
    /// Модель категории мероприятия
    /// </summary>
    public class EventCategory : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<EventCategoryLocalization> Localizations { get; set; } = new List<EventCategoryLocalization>();
    }
}
