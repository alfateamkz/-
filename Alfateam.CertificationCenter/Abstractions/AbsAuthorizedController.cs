using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.API.Filters;
using Alfateam.CertificationCenter.Models;
using Alfateam.ID.Models.Security;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CertificationCenter.API.Abstractions
{
    [AuthorizedUser(mustBeVerified: true)]
    public abstract class AbsAuthorizedController : AbsController
    {
        protected AbsAuthorizedController(ControllerParams @params) : base(@params)
        {
        }

        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);
    }
}
