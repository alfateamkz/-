using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Exceptions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;

namespace Alfateam.Website.API.Services
{
    public class FilesService
    {
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IHttpContextAccessor HttpContextAccessor;
        private HttpRequest Request => HttpContextAccessor.HttpContext.Request;

        public FilesService (IWebHostEnvironment appEnv, IHttpContextAccessor httpContextAccessor)
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

        #region Upload content media

        public async Task UpdateContentMedia(Content oldContent, Content newContent)
        {
            var oldContentItems = GetAllContentItems(oldContent);
            var newContentItems = GetAllContentItems(oldContent);


            var deletedContentItems = new List<ContentItem>();
            var newCreatedContentItems = new List<ContentItem>();

            foreach (var oldItem in oldContentItems)
            {
                if(!newContentItems.Any(o => o.Guid == oldItem.Guid))
                {
                    deletedContentItems.Add(oldItem);
                }
            }

            foreach (var newItem in newContentItems)
            {
                if (!oldContentItems.Any(o => o.Guid == newItem.Guid))
                {
                    newCreatedContentItems.Add(newItem);
                }
            }


            foreach (var item in deletedContentItems)
            {
                if (item is AudioContentItem audio)
                {
                    File.Delete(Path.Combine(AppEnvironment.WebRootPath, audio.AudioPath));
                }
                else if (item is ImageContentItem image)
                {
                    File.Delete(Path.Combine(AppEnvironment.WebRootPath, image.ImgPath));
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        File.Delete(Path.Combine(AppEnvironment.WebRootPath, img.ImgPath));
                    }
                }
                else if (item is VideoContentItem video)
                {
                    File.Delete(Path.Combine(AppEnvironment.WebRootPath, video.VideoPath));
                }
            }

            foreach (var item in newCreatedContentItems)
            {
                if (item is AudioContentItem audio)
                {
                    audio.AudioPath = await TryUploadFile(item.Guid, FileType.Audio);
                }
                else if (item is ImageContentItem image)
                {
                    image.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        img.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                    }
                }
                else if (item is VideoContentItem video)
                {
                    video.VideoPath = await TryUploadFile(item.Guid, FileType.Video);
                }
            }
        }
        public async Task UploadContentMedia(Content content)
        {
            foreach (var item in content.Items)
            {
                if (item is AudioContentItem audio)
                {
                    audio.AudioPath = await TryUploadFile(item.Guid, FileType.Audio);
                }
                else if (item is ImageContentItem image)
                {
                    image.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach (var img in slider.Images)
                    {
                        img.ImgPath = await TryUploadFile(item.Guid, FileType.Image);
                    }
                }
                else if (item is VideoContentItem video)
                {
                    video.VideoPath = await TryUploadFile(item.Guid, FileType.Video);
                }
            }
        }



        private IEnumerable<ContentItem> GetAllContentItems(Content content)
        {
            var contentItems = content.Items;

            foreach(var item in content.Items.Where(o => o is ImageSliderContentItem).Cast<ImageSliderContentItem>())
            {
                contentItems.AddRange(item.Images);
            }

            return contentItems;
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
