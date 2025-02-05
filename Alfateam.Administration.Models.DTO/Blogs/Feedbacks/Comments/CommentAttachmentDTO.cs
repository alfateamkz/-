using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Enums;
using Alfateam.Core.Attributes.DTO;
using Alfateam.SharedModels;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Comments
{
    public class CommentAttachmentDTO : DTOModelAbs<CommentAttachment>
    {
        public CommentAttachmentType Type { get; set; }


        [ForClientOnly]
        public UploadedFile File { get; set; }

        [HiddenFromClient]
        public string FileId { get; set; }
    }
}
