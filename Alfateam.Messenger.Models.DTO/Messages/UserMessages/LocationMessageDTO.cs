using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.UserMessages
{
    public class LocationMessageDTO : UserMessageDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
