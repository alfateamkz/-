using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions
{
    public class ReactionDTO : DTOModelAbs<Reaction>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string ImagePath { get; set; }
    }
}
