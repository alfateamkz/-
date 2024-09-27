using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class EmailNotificationSettingsDTO : DTOModelAbs<EmailNotificationSettings>
    {
        public bool CounterpartyInvitations { get; set; }
        public bool CounterpartyOurInvitationsAnswer { get; set; }



        public bool NewIncomingDocuments { get; set; }

        public bool SigningResultNegative { get; set; }
        public bool SigningResultPositive { get; set; }

        public bool TransferredMeToSignOrApprove { get; set; }
        public bool DocumentApprovalResult { get; set; }



        public bool ServiceInfoNews { get; set; }
        public bool NewChatMessages { get; set; }
    }
}
