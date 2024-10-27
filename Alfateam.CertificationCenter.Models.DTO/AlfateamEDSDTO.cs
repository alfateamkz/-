using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.CertificationCenter.Models.DTO
{
    public class AlfateamEDSDTO : DTOModelAbs<AlfateamEDS>
    {

        [Description("Кому выдана ЭЦП - код страны")]
        [ForClientOnly]
        public string OwnerCountryCode { get; set; }


        [Description("Кому выдана ЭЦП - ID номер (например, ИНН в РФ, ИИН\\БИН в РК и т.д.)")]
        [ForClientOnly]
        public string OwnerIdentificationNumber { get; set; }

        [Description("Для кого ЭЦП (Individual - физ.лицо\\самозанятый, Business - ИП/ООО/прочее)")]
        [ForClientOnly]
        public EDSFor For { get; set; }



        [Description("Текстовое название издателя ЭЦП")]
        [ForClientOnly]
        public string IssuerStringInfo { get; set; } = "ТОО \"Альфатим ИТ (Alfateam)\", БИН 220640023065";

        [Description("Текстовое название владельца ЭЦП")]
        [ForClientOnly]
        public string OwnerStringInfo { get; set; }


        [Description("Уникальный публичный ключ ЭЦП")]
        [ForClientOnly]
        public string PublicKey { get; set; }




        [ForClientOnly]
        public bool IsValid => ValidBefore > DateTime.UtcNow && !IsRevoked;
        [ForClientOnly]
        public bool IsRevoked => RevokedAt != null;



        [ForClientOnly]
        public DateTime IssuedAt { get; set; }
        [ForClientOnly]
        public DateTime ValidBefore { get; set; }
        [ForClientOnly]
        public DateTime? RevokedAt { get; set; }
    }
}
