using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.CreateModels.Events
{
    public class EventFormatCreateModel : CreateModel<EventFormat>
    {
        public string Title { get; set; }


        public int MainLanguageId { get; set; }
    }
}
