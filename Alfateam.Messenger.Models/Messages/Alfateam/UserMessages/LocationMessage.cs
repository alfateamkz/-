using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.UserMessages
{
    public class LocationMessage : AlfateamMessengerUserMessage
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
