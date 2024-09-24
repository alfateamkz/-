using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Alfateam.Core.Services
{
    public class AbsFilesService
    {
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IHttpContextAccessor HttpContextAccessor;
        public HttpRequest Request => HttpContextAccessor.HttpContext.Request;

        public AbsFilesService(IWebHostEnvironment appEnv, IHttpContextAccessor httpContextAccessor)
        {
            AppEnvironment = appEnv;
            HttpContextAccessor = httpContextAccessor;
        }


        public long GetFileSizeInBytes(string filepath)
        {
            return new FileInfo(AppEnvironment.WebRootPath + filepath).Length;
        }


        #region File check
        public void CheckImageFile(IFormFile file)
        {
            CheckFileBase(file);
            if (!this.IsImageFileExtension(file.FileName))
            {
                throw new Exception400("Неподдерживаемый формат файла");
            }
        }
        public void CheckDocumentFile(IFormFile file)
        {
            CheckFileBase(file);

            if (!this.IsDocumentFileExtension(file.FileName))
            {
                throw new Exception400("Неподдерживаемый формат файла");
            }
        }
        public void CheckAudioFile(IFormFile file)
        {
            CheckFileBase(file);

            if (!this.IsAudioFileExtension(file.FileName))
            {
                throw new Exception400("Неподдерживаемый формат файла");
            }
        }
        public void CheckVideoFile(IFormFile file)
        {
            CheckFileBase(file);

            if (!this.IsVideoFileExtension(file.FileName))
            {
                throw new Exception400("Неподдерживаемый формат файла");
            }
        }
        public void CheckFileBase(IFormFile file)
        {
            if (file == null)
            {
                throw new Exception400("Необходимо загрузить файл");
            }
            else if (file.Length == 0)
            {
                throw new Exception400("Пустой файл");
            }
        }



        public bool IsImageFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp";
        }
        public bool IsDocumentFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".pdf" || ext == ".docx" || ext == ".xls" || ext == ".xlsx" || ext == ".ort" || ext == ".rtf";
        }
        public bool IsAudioFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".mp3" || ext == ".wav" || ext == ".ogg";
        }
        public bool IsVideoFileExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            return ext == ".mp4" || ext == ".avi" || ext == ".mkv";
        }
        #endregion




        #region IsFileUploaded

        public bool IsFileUploaded(string formFileName)
        {
            return Request.Form.Files.Any(o => o.Name == formFileName);
        }

        #endregion

        #region UploadFile


        public async Task<string> TryUploadFile(string formFileName, FileType fileType)
        {
            var file = Request.Form.Files.FirstOrDefault(o => o.Name == formFileName);

            switch (fileType)
            {
                case FileType.Image:
                    this.CheckImageFile(file);
                    break;
                case FileType.Document:
                    this.CheckDocumentFile(file);
                    break;
                case FileType.Video:
                    this.CheckVideoFile(file);
                    break;
                case FileType.Audio:
                    this.CheckAudioFile(file);
                    break;
            }


            string filepath = await this.UploadFile(file);
            return filepath;
        }
        public async Task<string> TryUploadFile(IFormFile file, FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Image:
                    this.CheckImageFile(file);
                    break;
                case FileType.Document:
                    this.CheckDocumentFile(file);
                    break;
                case FileType.Video:
                    this.CheckVideoFile(file);
                    break;
                case FileType.Audio:
                    this.CheckAudioFile(file);
                    break;
            }

            string filepath = await this.UploadFile(file);
            return filepath;
        }

        public async Task<string> UploadFile(int index = 0)
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
        public async Task<string> UploadFile(IFormFile file)
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
        public async Task<string> UploadFile(string formFileName)
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
        public void DeleteFiles(List<string> paths)
        {
            foreach (var path in paths)
            {
                DeleteFile(path);
            }
        }
        public void DeleteFile(string path)
        {
            if (System.IO.File.Exists(AppEnvironment.WebRootPath + path))
            {
                System.IO.File.Delete(AppEnvironment.WebRootPath + path);
            }
        }


        #endregion



    }
}
