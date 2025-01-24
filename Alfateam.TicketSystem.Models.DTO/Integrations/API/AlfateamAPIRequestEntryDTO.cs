using Alfateam.TicketSystem.Models.Integrations.API;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Integrations.API
{
    public class AlfateamAPIRequestEntryDTO : DTOModelAbs<AlfateamAPIRequestEntry>
    {
        public string URL { get; set; }
        public string HTTPMethod { get; set; }
        public string Headers { get; set; }
        public string? Response { get; set; }




        public string IP { get; set; }
        public string? UserAgent { get; set; }
    }
}
