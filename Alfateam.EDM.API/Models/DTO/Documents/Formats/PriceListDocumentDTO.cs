using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents.Types.Items;
using Alfateam.EDM.Models.Documents.Types.Items;

namespace Alfateam.EDM.API.Models.DTO.Documents.Types
{
    public class PriceListDocumentDTO : FormalizedElectronicDocumentDTO
    {
        public string SupplyAgreementNumber { get; set; }
        public DateTime SupplyAgreementDate { get; set; }


        public DateTime PricesStartsFrom { get; set; }
        public DateTime PricesActualBefore { get; set; }

        public List<PriceListItemDTO> Items { get; set; } = new List<PriceListItemDTO>();
    }
}
