using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models
{
    public class ChatNotificationSound : AbsModel
    {
        public string Filepath { get; set; }

        /// <summary>
        /// Если AccountId == null, то звук встроенный
        /// Если AccountId != null, то звук загружен пользователем
        /// </summary>
        public int? AccountId { get; set; }
    }
}
