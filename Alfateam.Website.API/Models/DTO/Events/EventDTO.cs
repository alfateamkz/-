using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.DTO.Events
{
    public class EventDTO : AvailabilityDTOModel<Event>
    {
    
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }




        public string Slug => SlugHelper.GetLatynSlug(Title);


        public EventCategoryDTO Category { get; set; }
        public EventFormatDTO Format { get; set; }
        public TimezoneDTO Timezone { get; set; }




        [HiddenFromClient]
        public int TimeZoneId { get; set; }



        [HiddenFromClient]
        public int CategoryId { get; set; }
        [HiddenFromClient]
        public int FormatId { get; set; }

        [HiddenFromClient]
        public int MainLanguageId { get; set; }

    }
}
