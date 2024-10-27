using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.General.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Chats.OfflineAutoTime
{
    public class OfflineAutoMessageSendByScheduleDTO : OfflineAutoMessageSendTimeDTO
    {
        public TimeSpan FromTime { get; set; }
        public TimeSpan TimeSpan { get; set; }



        public List<SendByScheduleDayOfWeekDTO> DaysOfWeek { get; set; } = new List<SendByScheduleDayOfWeekDTO>();
    }
}
