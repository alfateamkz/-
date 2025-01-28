using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.TicketSystem.Models.Enums;
using System.Net.Mail;

namespace Alfateam.TicketSystem.API.Services
{
    public class UploadedFilesService
    {
        public readonly TicketSystemDbContext DB;
        public readonly AbsDBService DBService;
        public UploadedFilesService(TicketSystemDbContext db, AbsDBService dbService)
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
    }
}
