using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO;
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

namespace Alfateam.Website.API.Controllers.Admin
{

    public class AdminComplianceController : AbsAdminController
    {
        public AdminComplianceController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
         
        }
       
   

        #region Комплаенс-документы

        [HttpGet, Route("GetComplianceDocuments")]
        public async Task<RequestResult<IEnumerable<ComplianceDocumentDTO>>> GetComplianceDocuments(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<ComplianceDocumentDTO>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Compliance, 1),
                () => {
                    var items = GetAvailableModels(session.User, ComplianceDocuments(), offset, count);
                    var models = ComplianceDocumentDTO.CreateItemsWithLocalization(items.Cast<ComplianceDocument>(), LanguageId) as IEnumerable<ComplianceDocumentDTO>;
                    return RequestResult<IEnumerable<ComplianceDocumentDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetComplianceDocument")]
        public async Task<RequestResult<ComplianceDocument>> GetComplianceDocument(int id)
        {
            return TryGetOne(ComplianceDocuments(), id, ContentAccessModelType.Compliance);
        }

        [HttpGet, Route("GetComplianceDocumentLocalization")]
        public async Task<RequestResult<ComplianceDocumentLocalization>> GetComplianceDocumentLocalization(int id)
        {
            var localization = DB.ComplianceDocumentLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<ComplianceDocumentLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = ComplianceDocuments().FirstOrDefault(o => o.Id == localization.ComplianceDocumentId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<ComplianceDocumentLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Compliance, 1),
                () => RequestResult<ComplianceDocumentLocalization>.AsSuccess(localization)
            });
        }






        [HttpPost, Route("CreateComplianceDocument")]
        public async Task<RequestResult<ComplianceDocument>> CreateComplianceDocument(ComplianceDocument item)
        {
            return await TryCreate(DB.ComplianceDocuments, item, ContentAccessModelType.Compliance, async () => await PrepareDocumentBeforeCreate(item));
        }
     
        [HttpPost, Route("CreateComplianceDocumentLocalization")]
        public async Task<RequestResult<ComplianceDocumentLocalization>> CreateComplianceDocumentLocalization(int itemId, ComplianceDocumentLocalization localization)
        {
            var mainEntity = ComplianceDocuments().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<ComplianceDocumentLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Posts),
                () => PrepareDocumentLocalizationBeforeCreate(localization).Result,
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.ComplianceDocuments,mainEntity);
                    return RequestResult<ComplianceDocumentLocalization>.AsSuccess(localization);
                }
            });
        }





        [HttpPut, Route("UpdateComplianceDocumentMain")]
        public async Task<RequestResult<ComplianceDocument>> UpdateComplianceDocumentMain(ComplianceDocumentDTO model)
        {
            var item = ComplianceDocuments().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<ComplianceDocument>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Сущность по данному id не найдена"),
                () => CheckContentAreaRights(session, item, ContentAccessModelType.Compliance, 2),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз"),
                () => PrepareDocumentBeforeUpdate(item).Result,
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => UpdateModel(DB.ComplianceDocuments, model, item)
            });
        }

        [HttpPut, Route("UpdateComplianceDocumentLocalization")]
        public async Task<RequestResult<ComplianceDocumentLocalization>> UpdateComplianceDocumentLocalization(ComplianceDocumentLocalizationDTO model)
        {
            var localization = DB.ComplianceDocumentLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<ComplianceDocumentLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(ComplianceDocuments(), model, localization.ComplianceDocumentId, ContentAccessModelType.Compliance),
                () => PrepareDocumentLocalizationBeforeUpdate(localization).Result,
                () => UpdateModel(DB.ComplianceDocumentLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeleteComplianceDocument")]
        public async Task<RequestResult> DeleteComplianceDocument(int id)
        {
            var item = ComplianceDocuments().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Категория по данному id не найдена"),
                () => TryDelete(DB.ComplianceDocuments, item, ContentAccessModelType.Compliance)
            });
        }

        [HttpDelete, Route("DeleteComplianceDocumentLocalization")]
        public async Task<RequestResult> DeleteComplianceDocumentLocalization(int id)
        {
            var item = DB.ComplianceDocumentLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(ComplianceDocuments(), item.ComplianceDocumentId, ContentAccessModelType.Compliance),
                () => DeleteModel(DB.ComplianceDocumentLocalizations, item, false)
            });
        }
        #endregion

        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.ComplianceDocuments.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Compliance);
        }



        #region Private prepare methods

        private async Task<RequestResult> PrepareDocumentBeforeCreate(ComplianceDocument item)
        {
            return await PrepareDocumentBefore(item, false);
        }
        private async Task<RequestResult> PrepareDocumentBeforeUpdate(ComplianceDocument item)
        {
            return await PrepareDocumentBefore(item, true);
        }


        private async Task<RequestResult> PrepareDocumentLocalizationBeforeCreate(ComplianceDocumentLocalization localization)
        {
            return await UploadComplianceDocLocalizaionFiles(localization, false);
        }
        private async Task<RequestResult> PrepareDocumentLocalizationBeforeUpdate(ComplianceDocumentLocalization localization)
        {
            return await UploadComplianceDocLocalizaionFiles(localization, true);
        }





        private async Task<RequestResult> PrepareDocumentBefore(ComplianceDocument item,bool isUpdate)
        {
            var res = new RequestResult();

            var uploadRes = await UploadComplianceDocMainFiles(item, isUpdate);
            if (!uploadRes.Success)
            {
                return res.FillFromRequestResult(uploadRes);
            }

            if (!isUpdate)
            {
                //Проходимся по локализациям
                foreach (var localization in item.Localizations)
                {
                    var uploadLocalizationRes = await UploadComplianceDocLocalizaionFiles(localization, isUpdate);
                    if (!uploadLocalizationRes.Success)
                    {
                        return res.FillFromRequestResult(uploadRes);
                    }
                }
            }    

            return res.SetSuccess();
        }
        private async Task<RequestResult> UploadComplianceDocMainFiles(ComplianceDocument item, bool isUpdate)
        {
            var res = new RequestResult();

            string previewFormFileName = $"previewImg";
            if (!isUpdate || (isUpdate && Request.Form.Files.Any(o => o.Name == previewFormFileName)))
            {
                //Загрузка превью
                var previewFile = Request.Form.Files.FirstOrDefault(o => o.Name == previewFormFileName);
                var previewFileCheckRes = this.CheckImageFile(previewFile);
                if (!previewFileCheckRes.Success)
                {
                    res.FillFromRequestResult(previewFileCheckRes);
                    res.Error += $"\r\nПроблема с файлом {previewFormFileName}";
                    return res;
                }

                item.ImgPreviewPath = await this.UploadFile(previewFile);
            }


            string documentFormFileName = $"docFile";
            if (!isUpdate || (isUpdate && Request.Form.Files.Any(o => o.Name == previewFormFileName)))
            {
                //Загрузка документа
                var docFile = Request.Form.Files.FirstOrDefault(o => o.Name == documentFormFileName);
                var docFileCheckRes = this.CheckDocumentFile(docFile);
                if (!docFileCheckRes.Success)
                {
                    res.FillFromRequestResult(docFileCheckRes);
                    res.Error += $"\r\nПроблема с файлом docFile";
                    return res;
                }

                item.DocumentPath = await this.UploadFile(docFile);
                item.KBSize = this.GetFileSizeInBytes(item.DocumentPath) * 1024;
            }
      
            return res.SetSuccess();
        }
        private async Task<RequestResult> UploadComplianceDocLocalizaionFiles(ComplianceDocumentLocalization localization,bool isUpdate)
        {

            var res = new RequestResult();

            string previewFormFileName = $"{localization.LanguageEntityId}_previewImg";
            if (!isUpdate || (isUpdate && Request.Form.Files.Any(o => o.Name == previewFormFileName)))
            {
                var localizationPreviewFile = Request.Form.Files.FirstOrDefault(o => o.Name == $"{localization.LanguageEntityId}_previewImg");
                var localizationPreviewFileCheckRes = this.CheckImageFile(localizationPreviewFile);

                if (!localizationPreviewFileCheckRes.Success)
                {
                    res.FillFromRequestResult(localizationPreviewFileCheckRes);
                    res.Error += $"\r\nПроблема с файлом {localization.LanguageEntityId}_previewImg";
                    return res;
                }
                localization.ImgPreviewPath = await this.UploadFile(localizationPreviewFile);
            }


            string documentFormFileName = $"{localization.LanguageEntityId}_doc";
            if (!isUpdate || (isUpdate && Request.Form.Files.Any(o => o.Name == previewFormFileName)))
            {
                var localizationDocFile = Request.Form.Files.FirstOrDefault(o => o.Name == documentFormFileName);
                var localizationDocFileCheckRes = this.CheckImageFile(localizationDocFile);

                if (!localizationDocFileCheckRes.Success)
                {
                    res.FillFromRequestResult(localizationDocFileCheckRes);
                    res.Error += $"\r\nПроблема с файлом {localization.LanguageEntityId}_doc";
                    return res;
                }

                localization.DocumentPath = await this.UploadFile(localizationDocFile);
                localization.KBSize = this.GetFileSizeInBytes(localization.DocumentPath) * 1024;
            }

            return res.SetSuccess();
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
