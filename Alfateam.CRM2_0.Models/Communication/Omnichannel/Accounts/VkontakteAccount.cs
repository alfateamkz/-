using Alfateam.CRM2_0.Models.Abstractions.Communication.Omnichannel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Omnichannel.Accounts
{
    /// <summary>
    /// Модель аккаунта vk в системе омниканальности
    /// </summary>
    public class VkontakteAccount : OmnichannelAccount
    {
        public string Login { get; set; }
        public string Password { get; set; }


        /// <summary>
        /// API Auth токен
        /// </summary>
        public string Token { get; set; }
    }
}
