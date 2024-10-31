using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class ChatNotificationSettings : AbsModel
    {

        public ChatNotificationSound Sound { get; set; }
        public int SoundId { get; set; }



        [NotMapped]
        public bool IsMuted => MutedBefore == null || MutedBefore < DateTime.UtcNow;
        public DateTime? MutedBefore { get; set; }
    }
}
