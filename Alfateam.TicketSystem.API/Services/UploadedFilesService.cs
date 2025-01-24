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
