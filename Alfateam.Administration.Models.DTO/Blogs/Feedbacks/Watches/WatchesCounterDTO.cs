using Alfateam.Administration.Models.Blogs.Feedbacks.Watches;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Watches
{
    public class WatchesCounterDTO : DTOModelAbs<WatchesCounter>
    {
        [ForClientOnly]
        public int Counter { get; set; }
    }
}
