using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.Models.Tickets;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Tickets
{
    public class TicketDTO : DTOModelAbs<Ticket>
    {
        [ForClientOnly]
        public TicketCreatorDTO CreatedBy { get; set; }

        [ForClientOnly]
        public TicketStatus Status { get; set; }


        [ForClientOnly]
        public TicketCategoryDTO Category { get; set; }

        [DTOFieldFor(DTOFieldForType.CreationOnly), HiddenFromClient]
        public int CategoryId { get; set; }



        [ForClientOnly]
        public TicketPriorityDTO Priority { get; set; }
    }
}
