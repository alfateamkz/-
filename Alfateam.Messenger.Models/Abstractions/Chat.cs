using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    public class Chat : AbsModel
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        public string ChatId { get; set; }
    }
}
