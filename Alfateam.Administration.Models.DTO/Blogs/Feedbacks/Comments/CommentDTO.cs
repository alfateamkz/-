using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Comments
{
    public class CommentDTO : DTOModelAbs<Comment>
    {
        public string CreatedByIdentifier { get; set; }

        public string Text { get; set; }
        public List<CommentAttachmentDTO> Attachments { get; set; } = new List<CommentAttachmentDTO>();
    }
}
