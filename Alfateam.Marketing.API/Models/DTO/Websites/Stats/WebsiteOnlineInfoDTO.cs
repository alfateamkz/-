using Alfateam.Marketing.Models.Websites.Stats;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.Stats
{
    public class WebsiteOnlineInfoDTO : DTOModelAbs<WebsiteOnlineInfo>
    {
        public DateTime PingedAt { get; set; }
        public bool IsOnline { get; set; }


        public TimeSpan ResponseDuration { get; set; }
    }
}
