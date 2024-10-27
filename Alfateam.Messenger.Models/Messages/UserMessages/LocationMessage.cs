using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.UserMessages
{
    public class LocationMessage : UserMessage
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
