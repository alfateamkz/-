using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Tickets.Creators
{
    public class TicketAnonymCreator : TicketCreator
    {
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string Fingerprint { get; set; }
    }
}
