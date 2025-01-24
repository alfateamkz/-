using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions
{
    public class ReactionCounterDTO : DTOModelAbs<ReactionCounter>
    {
        [ForClientOnly]
        public ReactionDTO Reaction { get; set; }

        [ForClientOnly]
        public int Count { get; set; }
    }
}
