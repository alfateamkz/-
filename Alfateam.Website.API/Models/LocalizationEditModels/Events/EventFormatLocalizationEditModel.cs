using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Events;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Events
{
    public class EventFormatLocalizationEditModel : LocalizationEditModel<EventFormatLocalization>
    {
        public string Title { get; set; }
    }
}
