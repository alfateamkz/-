using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class ChatMessageDeletedInfo : AbsModel
    {
        public User DeletedBy { get; set; }
        public int DeletedById { get; set; }



        public DateTime DeletedAt { get; set; }
        public bool DeletedForAll { get; set; }
    }
}
