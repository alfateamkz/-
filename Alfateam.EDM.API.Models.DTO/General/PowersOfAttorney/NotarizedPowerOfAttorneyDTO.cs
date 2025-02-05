using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General.PowersOfAttorney
{
    public class NotarizedPowerOfAttorneyDTO : PowerOfAttorneyDTO
    {
        public string NotaryInfo { get; set; }
        public string Filepath { get; set; }
    }
}
