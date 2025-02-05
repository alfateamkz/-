using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Stickers.Alfateam
{
    public class AlfateamSticker : AbsSticker
    {
        public string Title { get; set; }
        public string CorrespondingEmoji { get; set; }
        public string Filepath { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? AlfateamStickersSetId { get; set; }

        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? StickersSetId { get; set; }
    }
}
