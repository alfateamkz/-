using Alfateam.Administration.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Comments
{
    public class CommentAttachment : AbsModel
    {
        public CommentAttachmentType Type { get; set; }
        public string URL { get; set; }
    }
}
