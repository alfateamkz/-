using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Reactions
{
    public class ReactionCounter : AbsModel
    {
        public Reaction Reaction { get; set; }
        public int ReactionId { get; set; }

        public int Count { get; set; }
        public List<SetReaction> SetReactions { get; set; } = new List<SetReaction>();



        public bool ToggleReaction(string createdByIdentifier)
        {
            var found = SetReactions.FirstOrDefault(o => o.CreatedByIdentifier == createdByIdentifier);
            if (found != null)
            {
                SetReactions.Remove(found);
                Count--;

                return false;
            }
            else
            {
                SetReactions.Add(new SetReaction
                {
                    ReactionId = this.ReactionId,
                    CreatedByIdentifier = createdByIdentifier
                });
                Count++;

                return true;
            }
        }
    }
}
