using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.ServicePages;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.ServicePages;

namespace Alfateam.Website.API.Models.DTOLocalization
{
    public class ServicePageLocalizationDTO : LocalizationDTOModel<ServicePageLocalization>
    {
        public string MainBlockHeader { get; set; }
        public string MainBlockShortText { get; set; }

        public List<ServicePageServiceRibbonItemDTO> ServiceRibbonItems { get; set; } = new List<ServicePageServiceRibbonItemDTO>();


        public string Block2Col1HTMLContent { get; set; }
        public string Block2Col2HTMLContent { get; set; }


        public List<ServicePageFakeReviewDTO> Reviews { get; set; } = new List<ServicePageFakeReviewDTO>();
    }
}
