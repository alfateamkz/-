using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Enums;

namespace Alfateam.EDM.API.Services
{
    public class UploadedFilesService
    {
        public readonly EDMDbContext DB;
        public readonly AbsDBService DBService;
        public UploadedFilesService(EDMDbContext db, AbsDBService dbService)
        {
            DB = db;
            DBService = dbService;
        }


        public bool AreAllFilesAvailable(IEnumerable<string> fileIds)
        {
            return fileIds.All(o => IsFileAvailable(o));
        }
        public bool IsFileAvailable(string fileId)
        {
            var file = DBService.TryGetOne(DB.UploadedFiles, fileId);
            return !file.IsUsed;
        }





        public void ThrowIfAnyFileNotAvailable(IEnumerable<string> fileIds)
        {
            if (!AreAllFilesAvailable(fileIds))
            {
                throw new Exception400("Файл(ы) уже используется(ются) в другой сущности");
            }
        }
        public void ThrowIfFileNotAvailable(string fileId)
        {
            if (!IsFileAvailable(fileId))
            {
                throw new Exception400("Файл уже используется в другой сущности");
            }
        }



        public void ThrowIfNewFileNotAvailable(string fileIdFromDBEntity, string fileIdFromRequestBody)
        {
            if(fileIdFromDBEntity != fileIdFromRequestBody)
            {
                ThrowIfFileNotAvailable(fileIdFromRequestBody);
            }
        }



        public void TryBindFileWithEntity(string fileId, UploadedFileRelatedEntity entityType, int entityId)
        {
            var file = DBService.TryGetOne(DB.UploadedFiles, fileId);
            if (file.IsUsed)
            {
                throw new Exception403("Файл уже используется в другой сущности");
            }
            file.RelatedEntityType = entityType;
            file.RelatedEntityId = entityId;
            DBService.UpdateEntity(DB.UploadedFiles, file);
        }

        public void BindFileWithEntity(string fileId, UploadedFileRelatedEntity entityType, int entityId)
        {
            var file = DBService.TryGetOne(DB.UploadedFiles, fileId);
            file.RelatedEntityType = entityType;
            file.RelatedEntityId = entityId;

            DBService.UpdateEntity(DB.UploadedFiles, file);
        }

        public void BindFileWithEntityIfChanged(string oldFileId, string newFileId, UploadedFileRelatedEntity entityType, int entityId)
        {
            if (oldFileId != newFileId)
            {
                var oldFile = DBService.TryGetOne(DB.UploadedFiles, oldFileId);
                var newFile = DBService.TryGetOne(DB.UploadedFiles, newFileId);

                oldFile.RelatedEntityId = null;
                oldFile.RelatedEntityType = null;

                newFile.RelatedEntityType = entityType;
                newFile.RelatedEntityId = entityId;

                DBService.UpdateEntity(DB.UploadedFiles, oldFile);
                DBService.UpdateEntity(DB.UploadedFiles, newFile);
            }
        }



        public void UnbindFile(UploadedFile file)
        {
            file.RelatedEntityId = null;
            file.RelatedEntityType = null;

            DBService.UpdateEntity(DB.UploadedFiles, file);
        }
    }
}
