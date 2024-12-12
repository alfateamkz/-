using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Enums.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.Results.Posts
{
    public class PostDeletionResult : AbsResult
    {
        public PostDeletionResultType Type { get; set; }
    }
}
