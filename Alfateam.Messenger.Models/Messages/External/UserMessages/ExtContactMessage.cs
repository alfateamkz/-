using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.External.UserMessages
{
    public class ExtContactMessage : ExternalMessengerUserMessage
    {
        /// <summary>
        /// ID или сам контакт
        /// </summary>
        public string Contact { get; set; }
    }
}
