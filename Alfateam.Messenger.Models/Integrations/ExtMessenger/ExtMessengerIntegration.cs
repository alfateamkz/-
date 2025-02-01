using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Messenger.Models.Integrations.ExtMessenger
{
    public class ExtMessengerIntegration : AbsModel
    {
        public string Title { get; set; }
        public string UniqueIdentifier { get; set; }
        public string SecretToken { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime? PaidBefore { get; set; }
        public List<ExtMessengerUser> Users { get; set; } = new List<ExtMessengerUser>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessId { get; set; }
    }
}
