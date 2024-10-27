using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO
{
    public class StickersSetDTO : DTOModelAbs<StickersSet>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public List<StickerDTO> Stickers { get; set; } = new List<StickerDTO>();
    }
}
