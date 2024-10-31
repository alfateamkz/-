using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Stickers.External
{
    public class ExternalSticker : AbsSticker
    {
        public string CorrespondingEmoji { get; set; }
        public string StickerId { get; set; }
        public string Filepath { get; set; }



        public string? StickersSetId { get; set; }
    }
}
