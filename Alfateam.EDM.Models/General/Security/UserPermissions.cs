using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General.Security
{
    public class UserPermissions : AbsModel
    {
        public bool CanCreateAndEditDocumentsAndDrafts { get; set; } = true;
        public bool CanSignDocuments { get; set; } = true;
        public bool CanApproveDocuments { get; set; } = true;
        public bool CanRedirectToApproveAndSign { get; set; } = true;
        public bool CanSeeCounterpartiesList { get; set; } = true;
        public bool CanAdministrateOrganization { get; set; } = true;


        public UserChatContactAvailabilityType ContactAvailability { get; set; } = UserChatContactAvailabilityType.CanContactWithUserFirst;
    }
}
