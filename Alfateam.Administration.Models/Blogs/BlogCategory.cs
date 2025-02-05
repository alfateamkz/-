using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs
{
    public class BlogCategory : AbsModel
    {
        public string Title { get; set; }
        public string? ImagePath { get; set; }


        public BlogCategory? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BlogLanguageZoneId { get; set; }
    }
}
