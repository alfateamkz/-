using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Events;

namespace Alfateam.Website.API.Models.DTOLocalization.Events
{
    public class EventCategoryLocalizationDTO : LocalizationDTOModel<EventCategoryLocalization>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
