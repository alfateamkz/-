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
    public class AlfateamEDS : AbsModel
    {
        public string EDSSerialNumber { get; set; }

        /// <summary>
        /// Пользователь-владелец, кому выдана ЭЦП
        /// </summary>
        public string OwnerAlfateamID { get; set; }



        /// <summary>
        /// Для кого ЭЦП (Individual - физ.лицо\самозанятый, Business - ИП/ООО/прочее)
        /// </summary>
        public EDSFor For { get; set; }


        /// <summary>
        /// Текстовое название издателя ЭЦП
        /// </summary>
        public string IssuerStringInfo { get; set; }
        /// <summary>
        /// Текстовое название владельца ЭЦП
        /// </summary>
        public string OwnerStringInfo { get; set; }


        /// <summary>
        /// Уникальный публичный ключ ЭЦП
        /// </summary>
        public string PublicKey { get; set; }





        [NotMapped]
        public bool IsActive => ValidFrom > DateTime.UtcNow && ValidBefore < DateTime.UtcNow && !IsRevoked;
        [NotMapped]
        public bool IsRevoked => RevokedAt != null;




        public DateTime ValidFrom { get; set; }
        public DateTime ValidBefore { get; set; }
        public DateTime? RevokedAt { get; set; }
    }
}
