using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Social
{
    public class SocialMediaPostCrtUpdDTO : PostCrtUpdDTO
    {
        public string? Content { get; set; }
        public List<SocialMediaPostAttachmentCrtUpdDTO> Attachments { get; set; } = new List<SocialMediaPostAttachmentCrtUpdDTO>();
    }
}
