using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.ServicePages;

namespace Alfateam.Website.API.Models.DTO.ServicePages
{
    public class ServicePageDTO : AvailabilityDTOModel<ServicePage>
    {
        public string MainBlockHeader { get; set; }
        public string MainBlockShortText { get; set; }
        public string MainBlockImgPath { get; set; }


        [ForClientOnly]
        public List<ServicePageServiceRibbonItemDTO> ServiceRibbonItems { get; set; } = new List<ServicePageServiceRibbonItemDTO>();


        public string Block2Col1HTMLContent { get; set; }
        public string Block2Col2HTMLContent { get; set; }



        [ForClientOnly]
        public List<ServicePageStackIconDTO> StackIcons { get; set; } = new List<ServicePageStackIconDTO>();
        [ForClientOnly]
        public List<ServicePageFakeReviewDTO> Reviews { get; set; } = new List<ServicePageFakeReviewDTO>();
    }
}
