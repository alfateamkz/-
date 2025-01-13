using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.Results
{
    public class AuthResult : AbsResult
    {
        public AuthResult()
        {

        }

        public AuthResult(AuthResultType type)
        {
            Type = type;
        }

        public AuthResult(AuthResultType type, string message)
        {
            Type = type;
            ResponseText = message;
        }

        public AuthResultType Type { get; set; }
    }
}
