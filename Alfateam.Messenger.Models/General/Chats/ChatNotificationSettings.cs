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
        /// <summary>
        /// Звук уведомления. Если пусто, то звук проигрывается по умолчанию
        /// </summary>
        public string? SoundFilepath { get; set; }




        [NotMapped]
        public bool IsMuted => MutedBefore == null;
        public DateTime? MutedBefore { get; set; }
    }
}
