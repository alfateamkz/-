using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Chats
{
    public class GroupChat : Chat
    {
        public string Title { get; set; }
        public string? AdminId { get; set; }


        public string? ChatPhotoPath { get; set; }
    }
}
