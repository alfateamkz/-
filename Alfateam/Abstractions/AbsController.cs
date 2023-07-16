using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Alfateam.Abstractions
{
    public class AbsController : Controller
    {
        public DatabaseContext DB { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public AbsController(DatabaseContext db, IWebHostEnvironment appEnvironment)
        {
            DB = db;
            AppEnvironment = appEnvironment;
        }











        /// <summary>
        /// Сохраняем файл на сервер и возвращаем путь к нему
        /// </summary>
        /// <param name="oldFilePath">Используется, если не прикрепили файл в форме и чтобы не затереть старый путь</param>
        /// <returns></returns>
        [NonAction]
        public async Task<string> SetAttachmentIfHas(string oldFilePath,int index = 0)
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
            return oldFilePath;
        }

        /// <summary>
        /// Сохраняем файл на сервер и возвращаем путь к нему
        /// </summary>
        /// <param name="oldFilePath">Используется, если не прикрепили файл в форме и чтобы не затереть старый путь</param>
        /// <returns></returns>
        [NonAction]
        public async Task<string> SetAttachmentIfHas(string oldFilePath, IFormFile attachment)
        {
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
            return oldFilePath;
        }






        [NonAction]
        public List<Language> GetOtherLanguages()
        {
            return DB.Languages.Where(o => o.Code != "RU").ToList();
        }
        [NonAction]
        public Language GetCurrentLanguage()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Language lang = null;
                try
                {
                    if (Request.Cookies.ContainsKey("Language"))
                    {
                        int id = Convert.ToInt32(Request.Cookies["Language"]);
                        lang = db.Languages.FirstOrDefault(o => o.Id == id);
                    }
                    else
                    {
                        lang = db.Languages.FirstOrDefault(o => o.Code == "RU");
                    }
                }
                catch { }

                return lang;
            }
        }
        [NonAction]
        public Language GetCurrentAdminTagLanguage()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Language lang = null;
                try
                {
                    if (Request.Cookies.ContainsKey("Language_HUI"))
                    {
                        int id = Convert.ToInt32(Request.Cookies["Language_HUI"]);
                        lang = db.Languages.FirstOrDefault(o => o.Id == id);
                    }
                    else
                    {
                        lang = db.Languages.FirstOrDefault(o => o.Code == "RU");
                    }
                }
                catch { }

                return lang;
            }
        }

    }
}
