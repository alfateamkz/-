using Alfateam.Core;
using Alfateam.Messenger.Models.General.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Chats
{
    public class Chat : AbsModel
    {
        public List<ChatPersonalSettings> PersonalSettings { get; set; } = new List<ChatPersonalSettings>();
    }
}
