using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.General;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs
{
    public class Blog : AbsModel
    {
        public string Title { get; set; }
        public BlogType Type { get; set; }


        public Product Product { get; set; }
        public int ProductId { get; set; }



        public List<Reaction> PossibleReactions { get; set; } = new List<Reaction>();
        public List<BlogLanguageZone> BlogLanguageZones { get; set; } = new List<BlogLanguageZone>();
    }
}
