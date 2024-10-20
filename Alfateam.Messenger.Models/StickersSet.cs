using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models
{
    public class StickersSet : AbsModel
    {
        public string Title { get; set; }
        public List<Sticker> Stickers { get; set; } = new List<Sticker>();
    }
}
