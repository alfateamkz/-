using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.DTO.Events
{
    public class EventCategoryDTO : AvailabilityDTOModel<EventCategory>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        [ForClientOnly]
        public string Slug => SlugHelper.GetLatynSlug(Title);
    }
}
