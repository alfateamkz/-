using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class ChatPersonalSettings : AbsModel
    {
        public Account User { get; set; }
        public int UserId { get; set; }



        public ChatFolder? Folder { get; set; }
        public int? FolderId { get; set; }



        public ChatBackground Background { get; set; }
        public int BackgroundId { get; set; }


        /// <summary>
        /// Порядок закрепления чата в списке чатов
        /// Если PinnedOrder -1, то чат не закреплен 
        /// </summary>
        public int PinnedOrder { get; set; } = -1;
        public ChatNotificationSettings Notifications { get; set; }

    }
}
