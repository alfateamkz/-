using Alfateam.Telephony.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExtLines
{
    public class FromServerToServiceExtLine : ExtLine
    {
        public string Login { get; set; } 
        public string Password { get; set; }
    }
}
