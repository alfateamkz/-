using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.CertificationCenter.Models.DTO.General.Biometric;
using Alfateam.CertificationCenter.Models.DTO.General.Documents;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.CertCenter.Owner
{
    [Route("CertCenter/Owner/[controller]")]
    public class CertCenterDocumentTypesController : AbsCertCenterController
    {
        public CertCenterDocumentTypesController(ControllerParams @params) : base(@params)
        {
        }

        #region Типы документов

        [HttpGet, Route("GetDocumentTypes")]
        public async Task<ItemsWithTotalCount<DocumentTypeDTO>> GetDocumentTypes(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<DocumentType, DocumentTypeDTO>(GetAvailableDocumentTypes(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetDocumentType")]
        public async Task<DocumentTypeDTO> GetDocumentType(int id)
        {
            return (DocumentTypeDTO)DBService.TryGetOne(GetAvailableDocumentTypes(), id, new DocumentTypeDTO());
        }






        [HttpPost, Route("CreateDocumentType")]
        public async Task<DocumentTypeDTO> CreateDocumentType(DocumentTypeDTO model)
        {
            return (DocumentTypeDTO)DBService.TryCreateEntity(CertCenterDb.DocumentTypes, model, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление типа документа", $"Добавлен тип документа {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateDocumentType")]
        public async Task<DocumentTypeDTO> UpdateDocumentType(DocumentTypeDTO model)
        {
            var item = GetAvailableDocumentTypes().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (DocumentTypeDTO)DBService.TryUpdateEntity(CertCenterDb.DocumentTypes, model, item, callback: (entity) =>
            {
                entity.Pages.Clear();
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование типа документа", $"Отредактирован тип документа с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteDocumentType")]
        public async Task DeleteDocumentType(int id)
        {
            var item = GetAvailableDocumentTypes().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(CertCenterDb.DocumentTypes, item);

            this.AddHistoryAction("Удаление типа документа", $"Удален тип документа {item.Title} с id={id}");
        }

        #endregion

        #region Страны документов

        [HttpGet, Route("GetDocumentCountries")]
        public async Task<ItemsWithTotalCount<DocumentCountryDTO>> GetDocumentCountries(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<DocumentCountry, DocumentCountryDTO>(GetAvailableDocumentCountries(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetDocumentCountry")]
        public async Task<DocumentCountryDTO> GetDocumentCountry(int id)
        {
            return (DocumentCountryDTO)DBService.TryGetOne(GetAvailableDocumentCountries(), id, new DocumentCountryDTO());
        }






        [HttpPost, Route("CreateDocumentCountry")]
        public async Task<DocumentCountryDTO> CreateDocumentCountry(DocumentCountryDTO model)
        {
            return (DocumentCountryDTO)DBService.TryCreateEntity(CertCenterDb.DocumentCountries, model, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление страны документа", $"Добавлена страна документа {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateDocumentCountry")]
        public async Task<DocumentCountryDTO> UpdateDocumentCountry(DocumentCountryDTO model)
        {
            var item = GetAvailableDocumentCountries().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (DocumentCountryDTO)DBService.TryUpdateEntity(CertCenterDb.DocumentCountries, model, item, callback: (entity) =>
            {
                entity.DocumentTypes.Clear();
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование страны документа", $"Отредактирована страна документа с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteDocumentCountry")]
        public async Task DeleteDocumentCountry(int id)
        {
            var item = GetAvailableDocumentCountries().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(CertCenterDb.DocumentCountries, item);

            this.AddHistoryAction("Удаление страны документа", $"Удалена страна документа {item.Title} с id={id}");
        }


        #endregion






        #region Private methods
        private IEnumerable<DocumentType> GetAvailableDocumentTypes()
        {
            return CertCenterDb.DocumentTypes.Include(o => o.Pages)
                                             .Where(o => !o.IsDeleted);
        }

        private IEnumerable<DocumentCountry> GetAvailableDocumentCountries()
        {
            return CertCenterDb.DocumentCountries.Include(o => o.DocumentTypes)
                                                 .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
