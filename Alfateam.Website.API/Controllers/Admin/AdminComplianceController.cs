using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization;
using Alfateam.Website.API.Models.DTOLocalization.Posts;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using Alfateam.Website.API.Filters.Access;

namespace Alfateam.Website.API.Controllers.Admin
{

    public class AdminComplianceController : AbsAdminController
    {
        public AdminComplianceController(ControllerParams @params) : base(@params)
        {
        }



        #region Комплаенс-документы

        [HttpGet, Route("GetComplianceDocuments")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 1)]
        public async Task<IEnumerable<ComplianceDocumentDTO>> GetComplianceDocuments(int offset, int count = 20)
        {
            var items = GetAvailableComplianceDocuments().Skip(offset).Take(count);
            return new ComplianceDocumentDTO().CreateDTOs(items).Cast<ComplianceDocumentDTO>();
        }

        [HttpGet, Route("GetComplianceDocumentsFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 1)]
        public async Task<IEnumerable<ComplianceDocumentDTO>> GetComplianceDocumentsFiltered([FromQuery]SearchFilter filter)
        {
            var items = filter.FilterBase(GetAvailableComplianceDocuments(), (item) => item.Title);
            return new ComplianceDocumentDTO().CreateDTOs(items).Cast<ComplianceDocumentDTO>();
        }




        [HttpGet, Route("GetComplianceDocument")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 1)]
        public async Task<ComplianceDocumentDTO> GetComplianceDocument(int id)
        {
            return (ComplianceDocumentDTO)DbService.TryGetOne(GetAvailableComplianceDocuments(), id, new ComplianceDocumentDTO());
        }




        [HttpGet, Route("GetComplianceDocumentLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 1)]
        public async Task<IEnumerable<ComplianceDocumentLocalizationDTO>> GetComplianceDocumentLocalizations(int id)
        {
            var localizations = DB.ComplianceDocumentLocalizations.Include(o => o.LanguageEntity).Where(o => o.ComplianceDocumentId == id && !o.IsDeleted);
            var mainEntity = GetAvailableComplianceDocuments().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new ComplianceDocumentLocalizationDTO()).Cast<ComplianceDocumentLocalizationDTO>();
        }

        [HttpGet, Route("GetComplianceDocumentLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 1)]
        public async Task<ComplianceDocumentLocalizationDTO> GetComplianceDocumentLocalization(int id)
        {
            var localization = DB.ComplianceDocumentLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableComplianceDocuments().FirstOrDefault(o => o.Id == localization?.ComplianceDocumentId && !o.IsDeleted);

            return (ComplianceDocumentLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new ComplianceDocumentLocalizationDTO());
        }






        [HttpPost, Route("CreateComplianceDocument")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 4)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем previewImg и документ с именем docFile")]
        public async Task<ComplianceDocumentDTO> CreateComplianceDocument([FromForm(Name = "model")] ComplianceDocumentDTO model)
        {
            return (ComplianceDocumentDTO)DbService.TryCreateAvailabilityEntity(DB.ComplianceDocuments, model, this.Session, async (entity) =>
            {
                await HandleComplianceDocument(entity, DBModelFillMode.Create);
            });
        }
     
        [HttpPost, Route("CreateComplianceDocumentLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем previewImg и документ с именем docFile")]
        public async Task<ComplianceDocumentLocalizationDTO> CreateComplianceDocumentLocalization(int itemId, [FromForm(Name = "localization")] ComplianceDocumentLocalizationDTO localization)
        {
            var mainEntity = GetAvailableComplianceDocuments().FirstOrDefault(o => o.Id == itemId);
            return (ComplianceDocumentLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.ComplianceDocuments, mainEntity, localization, async (entity) =>
            {
                await HandleComplianceDocumentLocalization(entity, DBModelFillMode.Create);
            });
        }





        [HttpPut, Route("UpdateComplianceDocumentMain")]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем previewImg и документ с именем docFile, если заливаем новый файл")]
        public async Task<ComplianceDocumentDTO> UpdateComplianceDocumentMain([FromForm(Name = "model")] ComplianceDocumentDTO model)
        {
            var item = GetAvailableComplianceDocuments().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ComplianceDocumentDTO)DbService.TryUpdateEntity(DB.ComplianceDocuments, model, item, async (entity) =>
            {
                await HandleComplianceDocument(entity, DBModelFillMode.Update);
            });
        }

        [HttpPut, Route("UpdateComplianceDocumentLocalization")]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем previewImg и документ с именем docFile, если заливаем новый файл")]
        public async Task<ComplianceDocumentLocalizationDTO> UpdateComplianceDocumentLocalization([FromForm(Name = "model")] ComplianceDocumentLocalizationDTO model)
        {
            var localization = DB.ComplianceDocumentLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableComplianceDocuments().FirstOrDefault(o => o.Id == localization.ComplianceDocumentId && !o.IsDeleted);

            return (ComplianceDocumentLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.ComplianceDocumentLocalizations, localization, model, mainEntity, async (entity) =>
            {
                await HandleComplianceDocumentLocalization(entity, DBModelFillMode.Update);
            });
        }






        [HttpDelete, Route("DeleteComplianceDocument")]
        public async Task DeleteComplianceDocument(int id)
        {
            var item = GetAvailableComplianceDocuments().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.ComplianceDocuments, item);
        }

        [HttpDelete, Route("DeleteComplianceDocumentLocalization")]
        public async Task DeleteComplianceDocumentLocalization(int id)
        {
            var item = DB.ComplianceDocumentLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.ComplianceDocuments.FirstOrDefault(o => o.Id == item.ComplianceDocumentId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.ComplianceDocumentLocalizations, item, mainModel);
        }
        #endregion

        [HttpPut, Route("UpdateAvailability")]
        [CheckContentAreaRights(ContentAccessModelType.Compliance, 2)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.ComplianceDocuments.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }









        #region Private get available methods

        private IEnumerable<ComplianceDocument> GetAvailableComplianceDocuments()
        {
            return DbService.GetAvailableModels(this.Session.User, ComplianceDocuments()).Cast<ComplianceDocument>();
        }

        #endregion

        #region Private prepare methods

        private async Task HandleComplianceDocument(ComplianceDocument entity, DBModelFillMode mode)
        {
            const string previewImgName = "previewImg";
            const string docFileName = "docFile";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(previewImgName))
              || mode == DBModelFillMode.Create)
            {
                entity.ImgPreviewPath = await FilesService.TryUploadFile(previewImgName, FileType.Image);
            }

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(docFileName))
              || mode == DBModelFillMode.Create)
            {
                entity.DocumentPath = await FilesService.TryUploadFile(docFileName, FileType.Document);
                entity.KBSize = FilesService.GetFileSizeInBytes(entity.DocumentPath) * 1024;
            }
        }
        private async Task HandleComplianceDocumentLocalization(ComplianceDocumentLocalization entity, DBModelFillMode mode)
        {
            const string previewImgName = "previewImg";
            const string docFileName = "docFile";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(previewImgName))
              || mode == DBModelFillMode.Create)
            {
                entity.ImgPreviewPath = await FilesService.TryUploadFile(previewImgName, FileType.Image);
            }

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(docFileName))
              || mode == DBModelFillMode.Create)
            {
                entity.DocumentPath = await FilesService.TryUploadFile(docFileName, FileType.Document);
                entity.KBSize = FilesService.GetFileSizeInBytes(entity.DocumentPath) * 1024;
            }
        }


        #endregion

        #region Private get included methods
        private IQueryable<ComplianceDocument> ComplianceDocuments()
        {
            return DB.ComplianceDocuments.IncludeAvailability()
                                         .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                         .Include(o => o.MainLanguage)
                                         .Where(o => !o.IsDeleted);
        }

    

        #endregion
    }
}
