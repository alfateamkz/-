using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Enums.Comments
{
    public enum CommentUpdateResultType
    {
        Success = 1,
        NotFound = 2,
        UnableToUpdate = 3,
        NoAccess = 4,
        InvalidData = 5,
    }
}
