using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Gateways.Models.Messages
{
    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string ToDisplayName { get; set; }


        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
