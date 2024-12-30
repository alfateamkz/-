using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;
using Alfateam2._0.Models.Localization.Items.Events;

namespace Alfateam.Website.API.Models.DTOLocalization.Events
{
    public class EventLocalizationDTO : LocalizationDTOModel<EventLocalization>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [ForClientOnly]
        public string ImgPath { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }
    }
}
