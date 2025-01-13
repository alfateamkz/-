using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Enums.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.Results.Comments
{
    public class CommentDeletionResult : AbsResult
    {
        public CommentDeletionResultType Type { get; set; }

        public CommentDeletionResult(CommentDeletionResultType type)
        {
            Type = type;
        }
    }
}
