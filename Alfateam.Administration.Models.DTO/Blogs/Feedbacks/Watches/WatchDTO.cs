using Alfateam.Administration.Models.Blogs.Feedbacks.Watches;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Watches
{
    public class WatchDTO : DTOModelAbs<Watch>
    {
        [ForClientOnly]
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string Fingerprint { get; set; }

        [ForClientOnly]
        public string? WatchedUserId { get; set; }



        public string? AdditionalInfo { get; set; }
    }
}
