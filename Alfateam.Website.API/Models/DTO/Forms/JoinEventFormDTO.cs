using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Events;

namespace Alfateam.Website.API.Models.DTO.Forms
{
    public class JoinEventFormDTO : SentFromWebsiteFormDTO
    {
        [ForClientOnly]
        public EventDTO Event { get; set; }

        [HiddenFromClient]
        public int EventId { get; set; }




        public string Name { get; set; }
        public string Contact { get; set; }
        public string Message { get; set; }
    }
}
