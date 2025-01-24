using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Comments
{
    public class CommentsCounterDTO : DTOModelAbs<CommentsCounter>
    {
        [ForClientOnly]
        public int Count { get; set; }
    }
}
