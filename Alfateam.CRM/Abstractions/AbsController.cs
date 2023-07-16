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
        public CRMDatabaseContext DB { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public AbsController(CRMDatabaseContext db, IWebHostEnvironment appEnvironment)
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
        public async Task<string> SetAttachmentIfHas(string oldFilePath, string inputFileName) {
            var attachment = Request.Form.Files.FirstOrDefault(o => o.Name == inputFileName);
            var filePath = "/uploads/" + Guid.NewGuid().ToString();

            if (attachment != null && attachment.Length > 0) {
                string path = filePath + attachment.FileName;
                using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create)) {
                    await attachment.CopyToAsync(fileStream);
                }
                return path;
            }
            return oldFilePath;
        }







    }
}
