using Alfateam.Administration.Models.General;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs
{
    public class BlogLanguageZone : AbsModel
    {
        public Language Language { get; set; }
        public int LanguageId { get; set; }



        public List<BlogCategory> Categories { get; set; } = new List<BlogCategory>();
        public List<BlogPost> Posts { get; set; } = new List<BlogPost>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BlogId { get; set; }
    }
}
