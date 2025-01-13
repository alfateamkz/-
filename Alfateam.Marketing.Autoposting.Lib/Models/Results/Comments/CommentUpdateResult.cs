using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Enums.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.Results.Comments
{
    public class CommentUpdateResult : AbsResult
    {
        public CommentUpdateResult(CommentUpdateResultType type, string message)
        {
            Type = type;
            ResponseText = message;
        }
        public CommentUpdateResultType Type { get; set; }
    }
}
