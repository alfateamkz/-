using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Comments
{
    public class CommentAttachmentDTO : DTOModelAbs<CommentAttachment>
    {
        public CommentAttachmentType Type { get; set; }
        public string URL { get; set; }
    }
}
