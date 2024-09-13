using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Enums;

namespace Alfateam.CRM2_0.Abstractions.Services
{
    public abstract class AbsUploadFileService
    {

        public abstract Task<RequestResult<string>> TryUploadFile(string formFileName, FileType fileType);
        public abstract Task<RequestResult<string>> TryUploadFile(IFormFile file, FileType fileType);


        public abstract Task<string> UploadFile(int index = 0);
        public abstract Task<string> UploadFile(IFormFile file);
        public abstract Task<string> UploadFile(string formFileName);



        protected abstract void DeleteFiles(List<string> paths);
        protected abstract void DeleteFile(string path);


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
    }
}
