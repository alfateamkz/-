using Alfateam.CRM2_0.Models.Abstractions.Communication.Omnichannel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Omnichannel.Accounts
{
    /// <summary>
    /// Модель аккаунта почтового ящика в системе омниканальности
    /// </summary>
    public class EmailAccount : OmnichannelAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public string Host { get; set; }
        public int Port { get; set; } = 465;
    }
}
