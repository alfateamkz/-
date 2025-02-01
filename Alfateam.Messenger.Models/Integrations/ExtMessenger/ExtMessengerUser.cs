using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Integrations.ExtMessenger
{
    public class ExtMessengerUser : AbsModel
    {
        public string UniqueId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ExtMessengerIntegrationId { get; set; }
    }
}
