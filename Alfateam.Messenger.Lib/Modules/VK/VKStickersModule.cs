﻿using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.VK
{
    public class VKStickersModule : StickersModule
    {
        private VkMessenger Messenger;
        public VKStickersModule(VkMessenger messenger)
        {
            Messenger = messenger;
        }

        public override async Task<Sticker> GetSticker(string stickerId)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Sticker>> GetStickers(string query, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}