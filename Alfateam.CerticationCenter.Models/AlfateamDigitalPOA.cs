using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models
{
    public class AlfateamDigitalPOA : AbsModel
    {
        /// <summary>
        /// Пользователь, который выпустил доверенность
        /// </summary>
        public string OwnerAlfateamID { get; set; }



        public string SerialNumber { get; set; } = Guid.NewGuid().ToString();



        /// <summary>
        /// Кем выдана доверенность - код страны
        /// </summary>
        public string IssuerCountryCode { get; set; }
        /// <summary>
        /// Кем выдана доверенность - ID номер (например, ИНН в РФ, ИИН\БИН в РК и т.д.)
        /// </summary>
        public string IssuerIdentificationNumber { get; set; }





        /// <summary>
        /// Кому выдана доверенность - код страны
        /// </summary>
        public string OwnerCountryCode { get; set; }
        /// <summary>
        /// Кому выдана доверенность - ID номер (например, ИНН в РФ, ИИН\БИН в РК и т.д.)
        /// </summary>
        public string OwnerIdentificationNumber { get; set; }





        /// <summary>
        /// Текстовое название издателя доверенности
        /// </summary>
        public string IssuerStringInfo { get; set; }
        /// <summary>
        /// Текстовое название кому выдана доверенность
        /// </summary>
        public string OwnerStringInfo { get; set; }





        public string Powers { get; set; }



        [NotMapped]
        public bool IsValid => ValidBefore > DateTime.UtcNow && !IsRevoked;
        [NotMapped]
        public bool IsRevoked => RevokedAt != null;


        public DateTime IssuedAt { get; set; }
        public DateTime ValidBefore { get; set; }
        public DateTime? RevokedAt { get; set; }
    }
}
