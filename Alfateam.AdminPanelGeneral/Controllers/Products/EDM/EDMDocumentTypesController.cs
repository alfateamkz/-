using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Documents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.EDM
{
    [Route("Products/EDM/[controller]")]
    public class EDMDocumentTypesController : AbsController
    {
        public EDMDocumentTypesController(ControllerParams @params) : base(@params)
        {
        }


        #region Типы документов

        [HttpGet, Route("GetDocumentTypes")]
        public async Task<ItemsWithTotalCount<DocumentTypeDTO>> GetDocumentTypes([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<DocumentType, DocumentTypeDTO>(GetAvailableTypes(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetDocumentType")]
        public async Task<DocumentTypeDTO> GetDocumentType(int id)
        {
            return (DocumentTypeDTO)DBService.TryGetOne(GetAvailableTypes(), id, new DocumentTypeDTO());
        }


        [HttpPost, Route("CreateDocumentType")]
        public async Task<DocumentTypeDTO> CreateDocumentType(DocumentTypeDTO model)
        {
            return (DocumentTypeDTO)DBService.TryCreateEntity(EDMDb.DocumentTypes, model, (entity) =>
            {
                entity.IsDefaultType = true;
            });
        }

        [HttpPut, Route("UpdateDocumentType")]
        public async Task<DocumentTypeDTO> UpdateDocumentType(DocumentTypeDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableTypes(), model.Id);
            return (DocumentTypeDTO)DBService.TryUpdateEntity(EDMDb.DocumentTypes, model, group, (entity) =>
            {
                entity.MetadataStructure.Fields.Clear();
            });
        }


        [HttpDelete, Route("DeleteDocumentType")]
        public async Task DeleteDocumentType(int id)
        {
            var group = DBService.TryGetOne(GetAvailableTypes(), id);
            DBService.TryDeleteEntity(EDMDb.DocumentTypes, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<DocumentType> GetAvailableTypes()
        {
            return EDMDb.DocumentTypes.Include(o => o.MetadataStructure).ThenInclude(o => o.Fields)
                                      .Where(o => !o.IsDeleted && o.EDMSubjectId == null && o.IsDefaultType);
        }


        #endregion


    }
}
