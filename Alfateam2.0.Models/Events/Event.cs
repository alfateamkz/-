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
    /// Модель мероприятия
    /// </summary>
    public class Event : AvailabilityModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }  
        

        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public General.TimeZone TimeZone { get; set; }
        public int TimeZoneId { get; set; }




        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }
        public EventFormat Format { get; set; }
        public int FormatId { get; set; }



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<EventLocalization> Localizations { get; set; } = new List<EventLocalization>();
    }
}
