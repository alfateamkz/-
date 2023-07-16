using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Info
{
    /// <summary>
    /// Модель списка социальных сетей
    /// </summary>
    public class SocialNetworksInfo : AbsModel
    {
        public string? Vkontakte { get; set; }
        public string? WhatsApp { get; set; }
        public string? Telegram { get; set; }
       

        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }

        public string? Threads { get; set; }
        public string? Odnoklassniki { get; set; }
        public string? Viber { get; set; }
    }
}
