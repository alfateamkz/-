using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Comments
{
    public class CommentCrtUpdDTO
    {
        public string? Text { get; set; }
        public List<CommentAttachmentCrtUpdDTO> Attachments { get; set; } = new List<CommentAttachmentCrtUpdDTO>();
    }
}
