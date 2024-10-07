using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.Models.General.Subjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [AuthorizedUser]
    [CheckCompanyAccess]
    public abstract class AbsAuthorizedController : AbsController
    {
        public AbsAuthorizedController(ControllerParams @params) : base(@params)
        {
        }


        public virtual Alfateam.EDM.Models.General.User? AuthorizedUser
        {
            get
            {
                var users = DB.Users.Include(o => o.Permissions)
                                    .Include(o => o.DocumentsAccess)
                                    .Include(o => o.NotificationSettings)
                                    .Include(o => o.TrustedUserIPs);

                if (EDMSubject is Company)
                {
                    return users.FirstOrDefault(o => !o.IsDeleted && o.AlfateamID == this.AlfateamSession.User.Guid && o.CompanyId == this.EDMSubjectId);
                }
                else if(EDMSubject is Individual)
                {
                    return users.FirstOrDefault(o => !o.IsDeleted && o.AlfateamID == this.AlfateamSession.User.Guid && o.IndividualId == this.EDMSubjectId);
                }
                return null;
            }
        }
        public int? AuthorizedUserId
        {
            get
            {
                if (EDMSubject is Company)
                {
                    return DB.Users.FirstOrDefault(o => !o.IsDeleted && o.AlfateamID == this.AlfateamSession.User.Guid && o.CompanyId == this.EDMSubjectId)?.Id;
                }
                else if (EDMSubject is Individual)
                {
                    return DB.Users.FirstOrDefault(o => !o.IsDeleted && o.AlfateamID == this.AlfateamSession.User.Guid && o.IndividualId == this.EDMSubjectId)?.Id;
                }
                return null;
            }
        }

    }
}
