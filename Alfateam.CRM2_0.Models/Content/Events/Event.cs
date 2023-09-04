using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Events
{
    /// <summary>
    /// Модель мероприятия
    /// </summary>
    public class Event : ContentModel
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
    }
}
