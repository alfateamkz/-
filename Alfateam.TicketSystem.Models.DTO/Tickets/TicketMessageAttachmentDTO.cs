using Alfateam.Core.Attributes.DTO;
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
    public class TicketMessageAttachmentDTO : DTOModelAbs<TicketMessageAttachment>
    {
        public TicketMessageAttachmentType Type { get; set; }

        [ForClientOnly]
        public UploadedFileDTO File { get; set; }

        [HiddenFromClient]
        public string FileId { get; set; }
    }
}
