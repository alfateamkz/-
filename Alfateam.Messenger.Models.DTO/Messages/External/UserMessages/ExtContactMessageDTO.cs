using Alfateam.Messenger.Models.Abstractions.Messages.External;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.External.UserMessages
{
    public class ExtContactMessageDTO : ExternalMessengerUserMessageDTO
    {
        [Description("ID или сам контакт")]
        public string Contact { get; set; }
    }
}
