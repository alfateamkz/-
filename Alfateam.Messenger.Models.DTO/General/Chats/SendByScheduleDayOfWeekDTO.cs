using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Chats
{
    public class SendByScheduleDayOfWeekDTO : DTOModelAbs<SendByScheduleDayOfWeek>
    {
        public DayOfWeek DayOfWeek { get; set; }
    }
}
