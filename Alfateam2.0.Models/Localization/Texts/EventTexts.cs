using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    /// <summary>
    /// Сущность перевода текста страницы мероприятия
    /// </summary>
    public class EventTexts :  LocalizableModel
    {
        public string LastBreadcrump { get; set; }
        public string Header { get; set; }


        public string Format { get; set; }
        public string Topic { get; set; }
        public string EventsSearch { get; set; }


        public string SearchBtn { get; set; }
    }
}
