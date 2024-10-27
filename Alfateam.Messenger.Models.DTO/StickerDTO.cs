using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO
{
    public class StickerDTO : DTOModelAbs<Sticker>
    {
        public string CorrespondingEmoji { get; set; }
        public string Filepath { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int StickersSetId { get; set; }
    }
}
