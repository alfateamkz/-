using Alfateam.DB;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

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


        #region File check
        protected RequestResult CheckImageFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsImageFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        protected RequestResult CheckDocumentFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsDocumentFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        protected RequestResult CheckAudioFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsAudioFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        protected RequestResult CheckVideoFile(IFormFile file)
        {
            var baseCheckRes = CheckFileBase(file);
            if (!baseCheckRes.Success) return baseCheckRes;

            if (!this.IsVideoFileExtension(file.FileName))
            {
                return RequestResult.AsError(400, "Неподдерживаемый формат файла");
            }

            return RequestResult.AsSuccess();
        }
        private RequestResult CheckFileBase(IFormFile file)
        {
            if (file == null)
            {
                return RequestResult.AsError(400, "Необходимо загрузить файл");
            }
            else if (file.Length == 0)
            {
                return RequestResult.AsError(400, "Пустой файл");
            }
            return RequestResult.AsSuccess();
        }



        protected bool IsImageFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp";
        }
        protected bool IsDocumentFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".pdf" || ext == ".docx" || ext == ".xls" || ext == ".xlsx" || ext == ".ort" || ext == ".rtf";
        }
        protected bool IsAudioFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".mp3" || ext == ".wav" || ext == ".ogg";
        }
        protected bool IsVideoFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".mp4" || ext == ".avi" || ext == ".mkv";
        }
        #endregion

        #region UploadFile


        protected async Task<RequestResult<string>> TryUploadFile(string formFileName, FileType fileType)
        {
            var res = new RequestResult<string>();

            //Загрузка главной картинки
            var file = Request.Form.Files.FirstOrDefault(o => o.Name == formFileName);

            RequestResult fileCheckResult = null;
            switch (fileType)
            {
                case FileType.Image:
                    fileCheckResult = this.CheckImageFile(file);
                    break;
                case FileType.Document:
                    fileCheckResult = this.CheckDocumentFile(file);
                    break;
                case FileType.Video:
                    fileCheckResult = this.CheckVideoFile(file);
                    break;
                case FileType.Audio:
                    fileCheckResult = this.CheckAudioFile(file);
                    break;
            }



            if (!fileCheckResult.Success)
            {
                res.FillFromRequestResult(fileCheckResult);
                res.Error += $"\r\nПроблема с файлом {formFileName}";
                return res;
            }

            string filepath = await this.UploadFile(file);
            return res.SetSuccess(filepath);
        }
        protected async Task<RequestResult<string>> TryUploadFile(IFormFile file, FileType fileType)
        {
            var res = new RequestResult<string>();
  
            RequestResult fileCheckResult = null;
            switch (fileType)
            {
                case FileType.Image:
                    fileCheckResult = this.CheckImageFile(file);
                    break;
                case FileType.Document:
                    fileCheckResult = this.CheckDocumentFile(file);
                    break;
                case FileType.Video:
                    fileCheckResult = this.CheckVideoFile(file);
                    break;
                case FileType.Audio:
                    fileCheckResult = this.CheckAudioFile(file);
                    break;
            }



            if (!fileCheckResult.Success)
            {
                res.FillFromRequestResult(fileCheckResult);
                res.Error += $"\r\nПроблема с файлом {file.Name}";
                return res;
            }

            string filepath = await this.UploadFile(file);
            return res.SetSuccess(filepath);
        }

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

        #region Delete file
        protected void DeleteFiles(List<string> paths)
        {
            foreach (var path in paths)
            {
                DeleteFile(path);
            }
        }
        protected void DeleteFile(string path)
        {
            if(System.IO.File.Exists(AppEnvironment.WebRootPath + path))
            {
                System.IO.File.Delete(AppEnvironment.WebRootPath + path);
            }
        }


        #endregion





        #region TryFinishAllRequestes
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
        public RequestResult<T> TryFinishAllRequestes<T>(Func<RequestResult>[] funcs)
        {
            return (RequestResult<T>)TryFinishAllRequestes(funcs);
        }

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
        public RequestResult<T> TryFinishAllRequestes<T>(RequestResult[] funcs)
        {
            return (RequestResult<T>)TryFinishAllRequestes(funcs);
        }


        #endregion




        protected long GetFileSizeInBytes(string filepath)
        {
            return new FileInfo(AppEnvironment.WebRootPath + filepath).Length;
        }

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
