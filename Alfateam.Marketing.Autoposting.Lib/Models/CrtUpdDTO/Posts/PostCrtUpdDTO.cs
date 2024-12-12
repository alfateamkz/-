using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts
{
    public class PostCrtUpdDTO
    {
        public string? Content { get; set; }
        public List<PostAttachmentCrtUpdDTO> Attachments { get; set; } = new List<PostAttachmentCrtUpdDTO>();
    }
}
