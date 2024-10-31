using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.External.UserMessages
{
    public class ExtLocationMessage : ExternalMessengerUserMessage
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
