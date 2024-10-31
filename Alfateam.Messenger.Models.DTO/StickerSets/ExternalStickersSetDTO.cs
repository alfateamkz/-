using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Stickers.External;
using Alfateam.Messenger.Models.Stickers.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.StickerSets
{
    public class ExternalStickersSetDTO : AbsStickerSetDTO
    {
        public string Title { get; set; }
        public List<ExternalStickerDTO> Stickers { get; set; } = new List<ExternalStickerDTO>();
    }
}
