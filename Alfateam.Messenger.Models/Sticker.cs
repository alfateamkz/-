using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models
{
    public class Sticker : AbsModel
    {
        public string StickerId { get; set; }
        public string CorrespondingEmoji { get; set; }
        public string Filepath { get; set; }
    }
}
