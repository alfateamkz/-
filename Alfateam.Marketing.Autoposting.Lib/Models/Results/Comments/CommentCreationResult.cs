using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Enums.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.Results.Comments
{
    public class CommentCreationResult : AbsResult
    {
        public CommentCreationResult(CommentCreationResultType type)
        {
            Type = type;
        }

        public CommentCreationResultType Type { get; set; }
        public Comment? Comment { get; set; }
    }
}
