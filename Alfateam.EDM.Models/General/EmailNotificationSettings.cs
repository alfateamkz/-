using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class EmailNotificationSettings : AbsModel
    {
        public bool CounterpartyInvitations { get; set; }
        public bool CounterpartyOurInvitationsAnswer { get; set; }



        public bool NewIncomingDocuments { get; set; }

        public bool SigningResultNegative{ get; set; }
        public bool SigningResultPositive { get; set; }

        public bool TransferredMeToSignOrApprove { get; set; }
        public bool DocumentApprovalResult { get; set; }



        public bool ServiceInfoNews { get; set; }
        public bool NewChatMessages { get; set; }
    }
}
