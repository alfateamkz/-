using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels;
using Alfateam.Website.API.Models.EditModels.General;
using Alfateam.Website.API.Models.LocalizationEditModels;
using Alfateam.Website.API.Models.LocalizationEditModels.Posts;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Posts;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<RequestResult<IEnumerable<ComplianceDocumentClientModel>>> GetComplianceDocuments(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<ComplianceDocumentClientModel>>();

            var tryGetManyResponse = TryGetMany(ComplianceDocuments(), ContentAccessModelType.Compliance, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = ComplianceDocumentClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetComplianceDocument")]
        public async Task<RequestResult<ComplianceDocument>> GetComplianceDocument(int id)
        {
            return TryGetOne(ComplianceDocuments(), id, ContentAccessModelType.Compliance);
        }

        [HttpGet, Route("GetComplianceDocumentLocalization")]
        public async Task<RequestResult<ComplianceDocumentLocalization>> GetComplianceDocumentLocalization(int id)
        {
            var localization = DB.ComplianceDocumentLocalizations.Include(o => o.Language)
                                                                 .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<ComplianceDocumentLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(ComplianceDocuments(), localization.ComplianceDocumentId, ContentAccessModelType.Compliance);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<ComplianceDocumentLocalization>().FillFromRequestResult(checkAccessResult);
            }

            return new RequestResult<ComplianceDocumentLocalization>().SetSuccess(localization);
        }






        [HttpPost, Route("CreateComplianceDocument")]
        public async Task<RequestResult<ComplianceDocument>> CreateComplianceDocument(ComplianceDocument item)
        {
            return await TryCreate(DB.ComplianceDocuments, item, ContentAccessModelType.Compliance, async () => await PrepareDocumentBeforeCreating(item));
        }
        [HttpPost, Route("CreateComplianceDocumentLocalization")]
        public async Task<RequestResult<ComplianceDocumentLocalization>> CreateComplianceDocumentLocalization(int itemId, ComplianceDocumentLocalization localization)
        {
            var mainEntity = ComplianceDocuments().FirstOrDefault(o => o.Id == itemId);

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Compliance);
            if (!checkResult.Success)
            {
                return new RequestResult<ComplianceDocumentLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.ComplianceDocuments.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<ComplianceDocumentLocalization>().SetSuccess(localization);
        }





        [HttpPut, Route("UpdateComplianceDocumentMain")]
        public async Task<RequestResult<ComplianceDocument>> UpdateComplianceDocumentMain(ComplianceDocumentMainEditModel model)
        {
            var res = new RequestResult<ComplianceDocument>();

            var baseCheckResult = CheckMainModelBeforeUpdate(ComplianceDocuments(), model, ContentAccessModelType.Compliance);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            var uploadRes = await UploadComplianceDocMainFiles(item);
            if (!uploadRes.Success)
            {
                return res.FillFromRequestResult(uploadRes);
            }


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                return UpdateModel(DB.ComplianceDocuments, model, item);
            }
        }

        [HttpPut, Route("UpdateComplianceDocumentLocalization")]
        public async Task<RequestResult<ComplianceDocumentLocalization>> UpdateComplianceDocumentLocalization(ComplianceDocumentLocalizationEditModel model)
        {
            var res = new RequestResult<ComplianceDocumentLocalization>();

            var localization = DB.ComplianceDocumentLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(ComplianceDocuments(), model, localization.ComplianceDocumentId, ContentAccessModelType.Compliance);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.ComplianceDocumentLocalizations, model, localization);
        }






        [HttpDelete, Route("DeleteComplianceDocument")]
        public async Task<RequestResult> DeleteComplianceDocument(int id)
        {
            var res = new RequestResult();

            var item = ComplianceDocuments().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.ComplianceDocuments, item, ContentAccessModelType.Compliance);
        }

        [HttpDelete, Route("DeleteComplianceDocumentLocalization")]
        public async Task<RequestResult> DeleteComplianceDocumentLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.ComplianceDocumentLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(ComplianceDocuments(), item.ComplianceDocumentId, ContentAccessModelType.Compliance);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.ComplianceDocumentLocalizations, item, false);
        }
        #endregion

        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;
            hasThisModel |= DB.ComplianceDocuments.Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Compliance);
        }


        #region Private methods
        private IQueryable<ComplianceDocument> ComplianceDocuments()
        {
            return DB.ComplianceDocuments.IncludeAvailability()
                                         .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                         .Include(o => o.MainLanguage)
                                         .Where(o => !o.IsDeleted);
        }

        private async Task<RequestResult> PrepareDocumentBeforeCreating(ComplianceDocument item)
        {
            var res = new RequestResult();

            var uploadRes = await UploadComplianceDocMainFiles(item);
            if (!uploadRes.Success)
            {
                return res.FillFromRequestResult(uploadRes);
            }


            //Проходимся по локализациям
            foreach (var localization in item.Localizations)
            {
                var uploadLocalizationRes = await UploadComplianceDocLocalizaionFiles(localization);
                if (!uploadLocalizationRes.Success)
                {
                    return res.FillFromRequestResult(uploadRes);
                }
            }

            return res.SetSuccess();
        }

 

        private async Task<RequestResult> UploadComplianceDocMainFiles(ComplianceDocument item)
        {

            var res = new RequestResult();

            //Загрузка превью
            var previewFile = Request.Form.Files.FirstOrDefault(o => o.Name == "previewImg");
            var previewFileCheckRes = this.CheckImageFile(previewFile);
            if (!previewFileCheckRes.Success)
            {
                res.FillFromRequestResult(previewFileCheckRes);
                res.Error += $"\r\nПроблема с файлом previewImg";
                return res;
            }

            item.ImgPreviewPath = await this.UploadFile(previewFile);



            //Загрузка документа
            var docFile = Request.Form.Files.FirstOrDefault(o => o.Name == "docFile");
            var docFileCheckRes = this.CheckDocumentFile(docFile);
            if (!previewFileCheckRes.Success)
            {
                res.FillFromRequestResult(previewFileCheckRes);
                res.Error += $"\r\nПроблема с файлом docFile";
                return res;
            }

            item.DocumentPath = await this.UploadFile(docFile);
            item.KBSize = this.GetFileSizeInBytes(item.DocumentPath) * 1024;



            return res.SetSuccess();
        }
        private async Task<RequestResult> UploadComplianceDocLocalizaionFiles(ComplianceDocumentLocalization localization)
        {

            var res = new RequestResult();

            var localizationPreviewFile = Request.Form.Files.FirstOrDefault(o => o.Name == $"{localization.LanguageId}_previewImg");
            var localizationPreviewFileCheckRes = this.CheckImageFile(localizationPreviewFile);

            if (!localizationPreviewFileCheckRes.Success)
            {
                res.FillFromRequestResult(localizationPreviewFileCheckRes);
                res.Error += $"\r\nПроблема с файлом {localization.LanguageId}_previewImg";
                return res;
            }

            localization.ImgPreviewPath = await this.UploadFile(localizationPreviewFile);


            var localizationDocFile = Request.Form.Files.FirstOrDefault(o => o.Name == $"{localization.LanguageId}_doc");
            var localizationDocFileCheckRes = this.CheckImageFile(localizationDocFile);

            if (!localizationDocFileCheckRes.Success)
            {
                res.FillFromRequestResult(localizationDocFileCheckRes);
                res.Error += $"\r\nПроблема с файлом {localization.LanguageId}_doc";
                return res;
            }

            localization.DocumentPath = await this.UploadFile(localizationDocFile);
            localization.KBSize = this.GetFileSizeInBytes(localization.DocumentPath) * 1024;



            return res.SetSuccess();
        }

        #endregion
    }
}
