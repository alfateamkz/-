using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
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
                var user = DB.Companies.Include(o => o.Users).ThenInclude(o => o.Permissions)
                                       .Include(o => o.Users).ThenInclude(o => o.DocumentsAccess)
                                       .Include(o => o.Users).ThenInclude(o => o.NotificationSettings)
                                       .Include(o => o.Users).ThenInclude(o => o.TrustedUserIPs)
                                       .FirstOrDefault(o => o.Id == this.CompanyId && o.BusinessId == this.BusinessId)
                                       ?.Users?.FirstOrDefault(o => !o.IsDeleted && o.AlfateamID == this.AlfateamSession.User.Guid);
                return user;
            }
        }
        public int? AuthorizedUserId
        {
            get
            {
                var user = DB.Companies.FirstOrDefault(o => o.Id == this.CompanyId && o.BusinessId == this.BusinessId)
                                      ?.Users?.FirstOrDefault(o => !o.IsDeleted && o.AlfateamID == this.AlfateamSession.User.Guid);
                return user?.Id;
            }
        }

    }
}
