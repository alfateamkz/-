using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.DTO.Events
{
    public class EventFormatDTO : AvailabilityDTOModel<EventFormat>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);


    }
}
