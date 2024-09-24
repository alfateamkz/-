using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning
{
    public class AfterDocSigningNotifyUsers : AfterDocSigningAction
    {
        public List<User> UsersToNotify { get; set; } = new List<User>();
    }
}
