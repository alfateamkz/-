using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class ChatFolder : AbsModel
    {
        public string Title { get; set; }
        public string LabelHexColor { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int AccountId { get; set; }
    }
}
