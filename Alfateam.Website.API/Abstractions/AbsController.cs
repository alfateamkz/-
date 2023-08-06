using Alfateam.DB;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbsController : ControllerBase
    {
        protected WebsiteDBContext DB { get; set; }
        protected IWebHostEnvironment AppEnvironment { get; set; }

        protected string UserSessid => Request.Headers["Sessid"];
        protected int? CountryId => ParseIntValueFromHeader("CountryId");
        protected int? CurrencyId => ParseIntValueFromHeader("CurrencyId");
        protected int? LanguageId => ParseIntValueFromHeader("LanguageId");

        public AbsController(WebsiteDBContext db, IWebHostEnvironment appEnv)
        {
            DB = db;
            AppEnvironment = appEnv;
        }

        protected AbsController(WebsiteDBContext db)
        {
            DB = db;
        }

        [NonAction]
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
        protected RequestResult CheckSession(Session session)
        {
            RequestResult res = new RequestResult();

            if (session == null)
            {
                res.Code = 404;
                res.Error = "Токен в системе не найден";
            }
            else if (session.IsExpired)
            {
                res.Code = 401;
                res.Error = "Вышел срок действия токена";
            }
            else
            {
                res.Success = true;
            }

            return res;
        }


        [NonAction]
        protected RequestResult CheckImageFile(IFormFile file)
        {
            var res = new RequestResult();

            if (file == null)
            {
                res.Code = 400;
                res.Error = "Необходимо загрузить аватар";
            }
            else if (file.Length == 0)
            {
                res.Code = 400;
                res.Error = "Пустой файл";
            }
            else if (!this.IsImageFileExtension(file.FileName))
            {
                res.Code = 400;
                res.Error = "Неподдерживаемый формат файла";
            }
            else
            {
                res.Success = true;
            }

            return res;
        }
        [NonAction]
        protected bool IsImageFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp";
        }

        #region UploadFile

        [NonAction]
        protected async Task<string> UploadFile(int index = 0)
        {
            var attachment = Request.Form.Files.Skip(index).FirstOrDefault();
            var filePath = "/uploads/" + Guid.NewGuid().ToString();

            if (attachment != null && attachment.Length > 0)
            {
                string path = filePath + attachment.FileName;
                using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await attachment.CopyToAsync(fileStream);
                }
                return path;
            }
            return "";
        }
        [NonAction]
        protected async Task<string> UploadFile(IFormFile file)
        {
            var filePath = "/uploads/" + Guid.NewGuid().ToString();

            if (file != null && file.Length > 0)
            {
                string path = filePath + file.FileName;
                using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return path;
            }
            return "";
        }

        [NonAction]
        protected async Task<string> UploadFile(string formFileName)
        {
            var attachment = Request.Form.Files.FirstOrDefault(o => o.Name == formFileName);
            var filePath = "/uploads/" + Guid.NewGuid().ToString();

            if (attachment != null && attachment.Length > 0)
            {
                string path = filePath + attachment.FileName;
                using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await attachment.CopyToAsync(fileStream);
                }
                return path;
            }
            return "";
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
