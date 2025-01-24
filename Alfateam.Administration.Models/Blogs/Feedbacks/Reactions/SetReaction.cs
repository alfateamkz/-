using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Reactions
{
    public class SetReaction : AbsModel
    {
        public Reaction Reaction { get; set; }
        public int ReactionId { get; set; }


        public string CreatedByIdentifier { get; set; }
    }
}
