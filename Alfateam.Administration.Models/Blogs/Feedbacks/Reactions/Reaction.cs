using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Reactions
{
    public class Reaction : AbsModel
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BlogId { get; set; }
    }
}
