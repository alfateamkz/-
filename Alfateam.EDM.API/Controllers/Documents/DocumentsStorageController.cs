using Alfateam.EDM.Models.Enums;
using Alfateam.Core;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.API.Models.DTO.Documents.Templates;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Documents
{
    public class DocumentsStorageController : AbsAuthorizedController
    {
        public DocumentsStorageController(ControllerParams @params) : base(@params)
        {
        }

        #region Документы в хранилище (без документооборота)

        [HttpGet, Route("GetDocuments")]
        public async Task<ItemsWithTotalCount<DocumentStorageFileDTO>> GetDocuments([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<DocumentStorageFile, DocumentStorageFileDTO>(GetAvailableDocuments(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.ToString().Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetDocumentTemplate")]
        public async Task<DocumentStorageFileDTO> GetDocumentTemplate(int id)
        {
            return (DocumentStorageFileDTO)DBService.TryGetOne(GetAvailableDocuments(), id, new DocumentStorageFileDTO());
        }





        [HttpPost, Route("CreateDocument")]
        public async Task<DocumentStorageFileDTO> CreateDocument(DocumentStorageFileDTO model)
        {
            return (DocumentStorageFileDTO)DBService.TryCreateEntity(DB.DocumentStorageFiles, model, callback: (entity) =>
            {
                UploadedFilesService.ThrowIfFileNotAvailable(entity.FileId);
                entity.EDMSubjectId = (int)this.EDMSubjectId;
            },
            afterSuccessCallback: (entity) =>
            {
                UploadedFilesService.BindFileWithEntity(entity.FileId, UploadedFileRelatedEntity.DocumentStorageFile, entity.Id);
            });
        }

        [HttpPut, Route("UpdateDocument")]
        public async Task<DocumentStorageFileDTO> UpdateDocument(DocumentStorageFileDTO model)
        {
            var item = DBService.TryGetOne(GetAvailableDocuments(), model.Id);
            string oldFileName = item.FileId;
            UploadedFilesService.ThrowIfNewFileNotAvailable(oldFileName, model.FileId);

            return (DocumentStorageFileDTO)DBService.TryUpdateEntity(DB.DocumentStorageFiles, model, item, callback: (entity) =>
            {
                entity.SigningSides.Clear();
            },
            afterSuccessCallback: (entity) =>
            {
                UploadedFilesService.BindFileWithEntityIfChanged(oldFileName, entity.FileId, UploadedFileRelatedEntity.DocumentTemplate, entity.Id);
            });
        }

        [HttpDelete, Route("DeleteDocument")]
        public async Task DeleteDocument(int id)
        {
            var group = DBService.TryGetOne(GetAvailableDocuments(), id);

            DBService.TryDeleteEntity(DB.DocumentStorageFiles, group);
            UploadedFilesService.UnbindFile(group.File);
        }

        #endregion









        #region Private methods
        private IEnumerable<DocumentStorageFile> GetAvailableDocuments()
        {
            return DB.DocumentStorageFiles.Include(o => o.File)
                                          .Include(o => o.Type)
                                          .Include(o => o.SigningSides)
                                          .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
        }

        #endregion
    }
}
