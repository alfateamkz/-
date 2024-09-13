using Alfateam.CRM2_0.Abstractions.Services;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Enums;

namespace Alfateam.CRM2_0.Services
{
    public class UploadFileService : AbsUploadFileService
    {
        private IWebHostEnvironment AppEnvironment;
        private HttpContext Context;
        public UploadFileService(IWebHostEnvironment appEnvironment, IHttpContextAccessor accessor)
        {
            AppEnvironment = appEnvironment;
            Context = accessor.HttpContext;
        }


        public async override Task<RequestResult<string>> TryUploadFile(string formFileName, FileType fileType)
        {
            var res = new RequestResult<string>();

            //Загрузка главной картинки
            var file = Context.Request.Form.Files.FirstOrDefault(o => o.Name == formFileName);

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
        public async override Task<RequestResult<string>> TryUploadFile(IFormFile file, FileType fileType)
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



        public override async Task<string> UploadFile(int index = 0)
        {
            var attachment = Context.Request.Form.Files.Skip(index).FirstOrDefault();
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
        public override async Task<string> UploadFile(IFormFile file)
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
        public override async Task<string> UploadFile(string formFileName)
        {
            var attachment = Context.Request.Form.Files.FirstOrDefault(o => o.Name == formFileName);
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



        protected override void DeleteFile(string path)
        {
            if (System.IO.File.Exists(AppEnvironment.WebRootPath + path))
            {
                System.IO.File.Delete(AppEnvironment.WebRootPath + path);
            }
        }
        protected override void DeleteFiles(List<string> paths)
        {
            foreach (var path in paths)
            {
                DeleteFile(path);
            }
        }
    }
}
