using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.General;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.StaticTextsConstructor
{
    public class TextsSet : AbsModel
    {
        public string Title { get; set; }
        public string UniqueIdentifier { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }



        public List<TextsSetLanguageZone> TextsSetLanguageZones { get; set; } = new List<TextsSetLanguageZone>();
    }
}
