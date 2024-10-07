using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO
{
    public class BannedCounterpartyDTO : DTOModelAbs<BannedCounterparty>
    {
        [ForClientOnly]
        public CounterpartyDTO Counterparty { get; set; }
        public int CounterpartyId { get; set; }


        public string BanReason { get; set; }
    }
}
