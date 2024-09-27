using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General.Security
{
    public class UserPermissionsDTO : DTOModelAbs<UserPermissions>
    {
        public bool CanCreateAndEditDocumentsAndDrafts { get; set; }
        public bool CanSignDocuments { get; set; } 
        public bool CanApproveDocuments { get; set; } 
        public bool CanRedirectToApproveAndSign { get; set; } 
        public bool CanSeeCounterpartiesList { get; set; }
        public bool CanAdministrateOrganization { get; set; } 


        public UserChatContactAvailabilityType ContactAvailability { get; set; }
    }
}
