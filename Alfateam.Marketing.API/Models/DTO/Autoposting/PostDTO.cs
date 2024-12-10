using Alfateam.Marketing.Models.Autoposting;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Autoposting
{
    public class PostDTO : DTOModelAbs<Post>
    {
        public string Content { get; set; }
        public List<PostAttachmentDTO> Attachments { get; set; } = new List<PostAttachmentDTO>();


        public DateTime PublishAt { get; set; }
        public DateTime? PublishedAt { get; set; }




        public TimeSpan? DeleteIn { get; set; }
    }
}
