using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.Alfateam.UserMessages
{
    public class LocationMessageDTO : AlfateamMessengerUserMessageDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
