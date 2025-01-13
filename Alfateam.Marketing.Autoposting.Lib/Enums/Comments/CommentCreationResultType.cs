using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Enums.Comments
{
    public enum CommentCreationResultType
    {
        Success = 1,
        CommentsClosed = 2,
        NoAccess = 3,
        InvalidData = 4,
        PostNotFound = 5,
    }
}
