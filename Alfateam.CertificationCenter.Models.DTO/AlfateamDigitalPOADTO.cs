using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.CertificationCenter.Models.DTO
{
    public class AlfateamDigitalPOADTO : DTOModelAbs<AlfateamDigitalPOA>
    {

        [Description("Кем выдана доверенность  - код страны")]
        [ForClientOnly]
        public string IssuerCountryCode { get; set; }

        [Description("Кем выдана доверенность - ID номер (например, ИНН в РФ, ИИН\\БИН в РК и т.д.)")]
        [ForClientOnly]
        public string IssuerIdentificationNumber { get; set; }





        [Description("Кому выдана доверенность - код страны")]
        [ForClientOnly]
        public string OwnerCountryCode { get; set; }

        [Description("Кому выдана доверенность - ID номер (например, ИНН в РФ, ИИН\\БИН в РК и т.д.)")]
        [ForClientOnly]
        public string OwnerIdentificationNumber { get; set; }





        [Description("Текстовое название издателя доверенности")]
        [ForClientOnly]
        public string IssuerStringInfo { get; set; }

        [Description("Текстовое название кому выдана доверенность")]
        [ForClientOnly]
        public string OwnerStringInfo { get; set; }




        [ForClientOnly]
        public string Powers { get; set; }



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
