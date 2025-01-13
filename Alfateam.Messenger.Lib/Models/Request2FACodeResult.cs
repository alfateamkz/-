using Alfateam.Messenger.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Models
{
    public class Request2FACodeResult
    {
        public Request2FACodeResultType Type { get; set; }
        public string Message { get; set; }
    }
}
