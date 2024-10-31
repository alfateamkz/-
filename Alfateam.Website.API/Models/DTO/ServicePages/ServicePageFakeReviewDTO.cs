using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ServicePages;

namespace Alfateam.Website.API.Models.DTO.ServicePages
{
    public class ServicePageFakeReviewDTO : DTOModel<ServicePageFakeReview>
    {
        public string CustomerTitle { get; set; }
        public string CustomerPosition { get; set; }
        [ForClientOnly]
        public string CustomerAvatarPath { get; set; }



        public string Text { get; set; }
    }
}
