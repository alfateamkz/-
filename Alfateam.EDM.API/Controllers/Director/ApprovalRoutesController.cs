using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.Models.Enums;

namespace Alfateam.EDM.API.Controllers.Director
{
    [RequiredRole(UserRole.Owner)]
    public class ApprovalRoutesController : AbsAuthorizedController
    {
        public ApprovalRoutesController(ControllerParams @params) : base(@params)
        {
        }
    }
}
