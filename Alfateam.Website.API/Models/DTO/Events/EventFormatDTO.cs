using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.DTO.Events
{
    public class EventFormatDTO : DTOModel<EventFormat>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);

        [HiddenFromClient]
        public int MainLanguageId { get; set; }
    }
}
