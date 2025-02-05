using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Stickers.Alfateam;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.StickerSets
{
    public class AlfateamStickersSetDTO : AbsStickerSetDTO
    {
        public string Title { get; set; }

        [ForClientOnly]
        public List<AlfateamStickerDTO> Stickers { get; set; } = new List<AlfateamStickerDTO>();
    }
}
