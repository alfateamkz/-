using Alfateam.CRM2_0.Models.Abstractions.Communication.Omnichannel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Omnichannel.Accounts
{
    /// <summary>
    /// Модель аккаунта WhatsApp в системе омниканальности
    /// </summary>
    public class WhatsAppAccount : OmnichannelAccount
    {
        /// <summary>
        /// Номер телефона, привязанный к аккаунту
        /// </summary>
        public string Phone { get; set; }



        /// <summary>
        /// API Auth токен
        /// </summary>
        public string Token { get; set; }
    }
}
