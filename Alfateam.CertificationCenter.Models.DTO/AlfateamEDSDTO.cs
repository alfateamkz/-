using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.CertificationCenter.Models.DTO
{
    public class AlfateamEDSDTO : DTOModelAbs<AlfateamEDS>
    {
        [ForClientOnly]
        public string EDSSerialNumber { get; set; }

        [Description("Для кого ЭЦП (Individual - физ.лицо\\самозанятый, Business - ИП/ООО/прочее)")]
        [ForClientOnly]
        public EDSFor For { get; set; }



        [Description("Текстовое название издателя ЭЦП")]
        [ForClientOnly]
        public string IssuerStringInfo { get; set; } = "ТОО \"Альфатим ИТ (Alfateam)\", БИН 220640023065";

        [Description("Текстовое название владельца ЭЦП")]
        [ForClientOnly]
        public string OwnerStringInfo { get; set; }




        [ForClientOnly]
        public bool IsActive => ValidFrom > DateTime.UtcNow && ValidBefore < DateTime.UtcNow && !IsRevoked;

        [ForClientOnly]
        public bool IsRevoked => RevokedAt != null;



        [ForClientOnly]
        public DateTime ValidFrom { get; set; }
        [ForClientOnly]
        public DateTime ValidBefore { get; set; }
        [ForClientOnly]
        public DateTime? RevokedAt { get; set; }
    }
}
