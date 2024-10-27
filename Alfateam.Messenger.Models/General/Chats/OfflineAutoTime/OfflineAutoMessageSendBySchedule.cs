using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats.OfflineAutoTime
{
    public class OfflineAutoMessageSendBySchedule : OfflineAutoMessageSendTime
    {
        public TimeSpan FromTime { get; set; }
        public TimeSpan TimeSpan { get; set; }



        public List<SendByScheduleDayOfWeek> DaysOfWeek { get; set; } = new List<SendByScheduleDayOfWeek>();
    }
}
