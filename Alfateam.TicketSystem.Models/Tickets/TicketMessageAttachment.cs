using Alfateam.Core;
using Alfateam.TicketSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Tickets
{
    public class TicketMessageAttachment : AbsModel
    {
        public TicketMessageAttachmentType Type { get; set; }

        public UploadedFile File { get; set; }
        public string FileId { get; set; }
    }
}
