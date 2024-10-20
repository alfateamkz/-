using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models
{
    public class CounterpartyInvitation : AbsModel
    {
        public CounterpartyInvitationStatus Status { get; set; } = CounterpartyInvitationStatus.Waiting;

        public EDMSubject From { get; set; }
        public int FromId { get; set; }
        public EDMSubject To { get; set; }
        public int ToId { get; set; }

        
        public string? Comment { get; set; }
    }
}
