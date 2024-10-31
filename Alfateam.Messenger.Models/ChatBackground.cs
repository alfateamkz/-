using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models
{
    public class ChatBackground : AbsModel
    {
        public string Filepath { get; set; }

        /// <summary>
        /// Если AccountId == null, то фон встроенный
        /// Если AccountId != null, то фон загружен пользователем
        /// </summary>
        public int? AccountId { get; set; }
    }
}
