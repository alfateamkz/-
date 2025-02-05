using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.MobileApps;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.MobileApps
{
    public class MobileAppDTO : DTOModelAbs<MobileApp>
    {
        public string Title { get; set; }


        [ForClientOnly]
        public MobileAppGroupDTO Group { get; set; }
        [HiddenFromClient]
        public int GroupId { get; set; }

    }
}
