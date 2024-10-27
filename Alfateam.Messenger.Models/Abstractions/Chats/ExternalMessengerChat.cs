﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Chats
{
    public class ExternalMessengerChat : Chat
    {
        public string Title { get; set; }
        public string? ChatPhotoPath { get; set; }
        public string ChatId { get; set; }
    }
}