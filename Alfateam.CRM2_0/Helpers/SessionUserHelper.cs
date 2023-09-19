using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Security;
using Alfateam.DB;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Helpers
{
	public class SessionUserHelper
	{
		public static User? GetAuthorizedUser(CRMDBContext db, string sessId)
		{
			if (string.IsNullOrWhiteSpace(sessId))
			{
				return null;
			}

			var session = GetCurrentSession(db, sessId);
			if (!CheckSession(session))
			{
				return null;
			}

			return session.User;
		}
		public static Session? GetCurrentSession(CRMDBContext db, string sessId)
		{
			var session = db.Sessions.Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
									 .FirstOrDefault(o => o.SessID == sessId);
			return session;
		}


		public static bool CheckSession(Session session)
		{
			if (session == null) return false;
			if (session.IsExpired) return false;
			if (session.IsDeactivated) return false;

			return true;
		}
		public static RequestResult CheckSessionAsRequestResult(Session session)
		{
			if (session == null) return RequestResult.AsError(404, "Сессия с данным ключом не найдена");
			if (session.IsExpired) return RequestResult.AsError(401, "Сессия уже просрочена");
			if (session.IsDeactivated) return RequestResult.AsError(401, "Сессия была деактивирована");

			return RequestResult.AsSuccess();
		}
	}
}
