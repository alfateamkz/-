using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.Models.Documents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Documents
{
    public class DocumentTypesController : AbsAuthorizedController
    {
        public DocumentTypesController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetDocumentTypes")]
        public async Task<IEnumerable<DocumentTypeDTO>> GetDocumentTypes(DocumentTypesFilterType type)
        {
            List<DocumentType> types = DB.DocumentTypes.Where(o => o.IsDefaultType && !o.IsDeleted).ToList();

            switch (type)
            {
                case DocumentTypesFilterType.All:
                    types.AddRange(DB.DocumentTypes.Where(o => !o.IsDefaultType && !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId));
                    break;
                case DocumentTypesFilterType.CustomOnly:
                    types = DB.DocumentTypes.Where(o => !o.IsDefaultType && !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId).ToList();
                    break;
                case DocumentTypesFilterType.DefaultOnly:
                    break;
            }

            return new DocumentTypeDTO().CreateDTOs(types).Cast<DocumentTypeDTO>();
        }

        [HttpGet, Route("GetDocumentType")]
        public async Task<DocumentTypeDTO> GetDocumentType(int id)
        {
            IEnumerable<DocumentType> types = GetDefaultAndOurDocumentTypes();
            return (DocumentTypeDTO)DBService.TryGetOne(types, id, new DocumentTypeDTO());
        }

        [HttpPost, Route("CreateDocumentType")]
        public async Task<DocumentTypeDTO> CreateDocumentType(DocumentTypeDTO model)
        {
            return (DocumentTypeDTO)DBService.TryCreateEntity(DB.DocumentTypes, model, (entity) =>
            {
                if(model.Sides.Count == 0)
                {
                    throw new Exception404("Нужно задать как минимум одну сторону документа");
                }

                entity.EDMSubjectId = (int)this.EDMSubjectId;
                entity.IsDefaultType = false;
            });
        }

        [HttpPut, Route("UpdateDocumentType")]
        public async Task<DocumentTypeDTO> UpdateDocumentType(DocumentTypeDTO model)
        {
            IEnumerable<DocumentType> types = GetDefaultAndOurDocumentTypes();
            var type = DBService.TryGetOne(types, model.Id);

            return (DocumentTypeDTO)DBService.TryUpdateEntity(DB.DocumentTypes, model, type, (entity) =>
            {
                if (model.Sides.Count == 0)
                {
                    throw new Exception404("Нужно задать как минимум одну сторону документа");
                }
            });
        }

        [HttpDelete, Route("DeleteDocumentType")]
        public async Task DeleteDocumentType(int id)
        {
            IEnumerable<DocumentType> types = GetDefaultAndOurDocumentTypes();
            var type = DBService.TryGetOne(types, id);

            DBService.TryDeleteEntity(DB.DocumentTypes, type);
        }










        private IEnumerable<DocumentType> GetDefaultAndOurDocumentTypes()
        {
            List<DocumentType> types = DB.DocumentTypes.Where(o => o.IsDefaultType && !o.IsDeleted).ToList();
            types.AddRange(DB.DocumentTypes.Where(o => !o.IsDefaultType && !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId));

            return types;
        }


    }
}
