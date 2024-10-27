using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class HelloAutoMessageSettings : AbsModel
    {
        public bool IsActive { get; set; }
        public string Message { get; set; }
    }
}
