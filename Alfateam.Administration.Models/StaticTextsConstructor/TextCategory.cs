using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.StaticTextsConstructor
{
    public class TextCategory : AbsModel
    {
        public string Title { get; set; }
        public string ProductIdentifier { get; set; }


        public TextCategory? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }



        public List<TextCategory> Subcategories { get; set; } = new List<TextCategory>();
    }
}
