using Alfateam.Core.Filters;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Services;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Alfateam.Core;

namespace Alfateam.Website.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly IMailGateway MailGateway;
        public readonly WebsiteDBContext DB;
        public readonly DBService DbService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly FilesService FilesService;

        protected string UserSessid => Request.Headers["Sessid"];
        protected int? CountryId => ParseIntValueFromHeader("CountryId");
        protected int? CurrencyId => ParseIntValueFromHeader("CurrencyId");
        protected int? LanguageId => ParseIntValueFromHeader("LanguageId");

        public AbsController(ControllerParams @params)
        {
            DB = @params.DB;
            DbService = @params.DbService;
            FilesService = @params.FilesService;    
            AppEnvironment = @params.AppEnvironment;
            MailGateway = @params.MailGateway;
        }
        public virtual Session Session => GetUserSession();


        protected int? GetUserIdIfSessionValid()
        {
            var session = DB.Sessions.Include(o => o.User)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                return null;
            }
            return session.User.Id;
        }


       

        protected SessionUser GetUserBySessid()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                                     .Include(o => o.User).ThenInclude(o => o.Country)
                                     .Include(o => o.User).ThenInclude(o => o.Basket)
                                     .FirstOrDefault(o => o.SessID == UserSessid);

            return new SessionUser
            {
                Session = session,
                User = session?.User
            };
        }


        [NonAction]
        public Session GetUserSession()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.BanInfo)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);
            return session;
        }
        [NonAction]
        public RequestResult CheckSession(Session session)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(session != null, 404, "Токен в системе не найден"),
                () => RequestResult.FromBoolean(!session.IsExpired, 401, "Вышел срок действия токена"),
                () => RequestResult.FromBoolean(!session.IsDeactivated, 401, "Токен был деактивирован"),
            });
        }
        [NonAction]
        public RequestResult CheckForBan(User user, BanType type)
        {
            if(user.BanInfo?.Type == type || user.BanInfo?.Type == BanType.All)
            {
                var res = new RequestResult();
                res.Value = user.BanInfo;
                return res.SetError(403, "Пользователь забанен. Дополнительно в свойстве Value");
            }

            return RequestResult.AsSuccess(null);
        }





        #region TryFinishAllRequestes
        [NonAction]
        public RequestResult TryFinishAllRequestes(Func<RequestResult>[] funcs)
        {
            RequestResult successResult = null;

            foreach (var func in funcs)
            {
                var res = func.Invoke();
                if (!res.Success) return res;

                successResult = res;
            }

            return successResult;
        }
        [NonAction]
        public RequestResult TryFinishAllRequestes<T>(Func<RequestResult>[] funcs)
        {
            return (RequestResult)TryFinishAllRequestes(funcs);
        }
        [NonAction]
        public RequestResult TryFinishAllRequestes(RequestResult[] funcs)
        {
            RequestResult successResult = null;

            foreach (var res in funcs)
            {
                if (!res.Success) return res;
                successResult = res;
            }

            return successResult;
        }
        [NonAction]
        public RequestResult TryFinishAllRequestes<T>(RequestResult[] funcs)
        {
            return (RequestResult)TryFinishAllRequestes(funcs);
        }


        #endregion




     

        private int? ParseIntValueFromHeader(string key)
        {
            int? id = null;

            if (Request.Headers.ContainsKey(key))
            {
                var str = Request.Headers[key].ToString();
                if (str != null)
                {
                    int val = 0;
                    int.TryParse(str, out val);

                    if (val != 0)
                    {
                        id = val;
                    }
                }
            }

            return id;
        }
    }
}
