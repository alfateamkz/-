using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class SendByScheduleDayOfWeek : AbsModel
    {
        public DayOfWeek DayOfWeek { get; set; }
    }
}
