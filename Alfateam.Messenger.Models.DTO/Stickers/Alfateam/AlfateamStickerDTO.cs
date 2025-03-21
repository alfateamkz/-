﻿using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Stickers.Alfateam
{
    public class AlfateamStickerDTO : AbsStickerDTO
    {
        public string CorrespondingEmoji { get; set; }
        public string Filepath { get; set; }



        [HiddenFromClient]
        public int? AlfateamStickersSetId { get; set; }

        [ForClientOnly]
        public int StickersSetId { get; set; }
    }
}
