using Alfateam.Marketing.Lettering.Lib.Abstractions;
using Alfateam.Marketing.Lettering.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Lettering.Lib.Models.Responses
{
    public class AuthResponse : AbsResponse
    {
        public AuthResponseType Type { get; set; }
    }
}
