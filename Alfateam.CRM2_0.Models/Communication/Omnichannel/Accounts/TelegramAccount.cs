using Alfateam.CRM2_0.Models.Abstractions.Communication.Omnichannel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Omnichannel.Accounts
{
    /// <summary>
    /// Модель телеграм аккаунта в системе омниканальности
    /// </summary>
    public class TelegramAccount : OmnichannelAccount
    {
        /// <summary>
        /// Номер телефона, привязанный к аккаунту
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Пароль аккуанта телеграм. Может отсутствовать
        /// </summary>
        public string? Password { get; set; }


        /// <summary>
        /// API Auth токен
        /// </summary>
        public string Token { get; set; }
    }
}
