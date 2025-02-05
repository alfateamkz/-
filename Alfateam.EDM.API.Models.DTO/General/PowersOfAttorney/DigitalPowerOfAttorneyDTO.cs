using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General.PowersOfAttorney
{
    public class DigitalPowerOfAttorneyDTO : PowerOfAttorneyDTO
    {
        public string IssuerInfo { get; set; }

        /// <summary>
        /// Содержимое файла МЧД
        /// </summary>
        public string FileContent { get; set; }
    }
}
