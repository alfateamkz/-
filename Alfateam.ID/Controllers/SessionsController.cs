using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.ID.Abstractions;
using Alfateam.ID.API.Abstractions;
using Alfateam.ID.API.Filters;
using Alfateam.ID.Models;
using Alfateam.ID.Models.DTO.Security;
using Alfateam.ID.Models.Security;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Alfateam.ID.API.Controllers
{
    [AuthorizedUser]
    public class SessionsController : AbsController
    {
        public SessionsController(ControllerParams @params) : base(@params)
        {
        }



        [HttpGet, Route("GetCurrentSession")]
        public async Task<SessionDTO> GetCurrentSession()
        {
            return (SessionDTO)new SessionDTO().CreateDTO(this.Session);
        }

        [HttpGet, Route("GetOtherActiveSessions")]
        public async Task<ItemsWithTotalCount<SessionDTO>> GetOtherActiveSessions(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Session, SessionDTO>(GetOtherActiveSessionsPrivate(), filter.Offset, filter.Count);
        }






        [HttpPut, Route("DeactivateSession")]
        public async Task DeactivateSession(string sessId)
        {
            var session = GetOtherActiveSessionsPrivate().FirstOrDefault(o => o.SessID == sessId);
            if(session == null)
            {
                throw new Exception404("Сессия не найдена");
            }

            session.IsDeactivated = true;
            DBService.UpdateEntity(DB.Sessions, session);
        }

        [HttpPut, Route("DeactivateOtherActiveSessions")]
        public async Task DeactivateOtherActiveSessions()
        {
            var sessions = GetOtherActiveSessionsPrivate();
            foreach(var session in sessions)
            {
                session.IsDeactivated = true;
            }
            DBService.UpdateEntities(DB.Sessions, sessions);
        }

        [HttpPut, Route("Logout")]
        public async Task Logout()
        {
            var session = this.Session;
            session.IsDeactivated = true;
            DBService.UpdateEntity(DB.Sessions, session);
        }









        #region Private methods
        private IEnumerable<Session> GetOtherActiveSessionsPrivate()
        {
            var currentSession = this.Session;
            return DB.Sessions.Where(o => o.UserId == currentSession.UserId && o.SessID != currentSession.SessID && o.IsActive);
        }


        #endregion
    }
}
