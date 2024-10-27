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

        /// <summary>
        /// Пользователь-владелец, кому выдана ЭЦП
        /// </summary>
        public string OwnerAlfateamID { get; set; }



        /// <summary>
        /// Кому выдана ЭЦП - код страны
        /// </summary>
        public string OwnerCountryCode { get; set; }
        /// <summary>
        /// Кому выдана ЭЦП - ID номер (например, ИНН в РФ, ИИН\БИН в РК и т.д.)
        /// </summary>
        public string OwnerIdentificationNumber { get; set; }
        /// <summary>
        /// Для кого ЭЦП (Individual - физ.лицо\самозанятый, Business - ИП/ООО/прочее)
        /// </summary>
        public EDSFor For { get; set; }


        /// <summary>
        /// Текстовое название издателя ЭЦП
        /// </summary>
        public string IssuerStringInfo { get; set; } = "ТОО \"Альфатим ИТ (Alfateam)\", БИН 220640023065";
        /// <summary>
        /// Текстовое название владельца ЭЦП
        /// </summary>
        public string OwnerStringInfo { get; set; }


        /// <summary>
        /// Уникальный публичный ключ ЭЦП
        /// </summary>
        public string PublicKey { get; set; }


        /// <summary>
        /// Пароль для авторизации ЭЦП
        /// </summary>
        public string Password { get; set; }



        [NotMapped]
        public bool IsValid => ValidBefore > DateTime.UtcNow && !IsRevoked;
        [NotMapped]
        public bool IsRevoked => RevokedAt != null;




        public DateTime IssuedAt { get; set; }
        public DateTime ValidBefore { get; set; }
        public DateTime? RevokedAt { get; set; }
    }
}
