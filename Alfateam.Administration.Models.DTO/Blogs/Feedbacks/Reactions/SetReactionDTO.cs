using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions
{
    public class SetReactionDTO : DTOModelAbs<SetReaction>
    {
        [ForClientOnly]
        public ReactionDTO Reaction { get; set; }

        [ForClientOnly]
        public string CreatedByIdentifier { get; set; }
    }
}
