using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.ClientModels.Shop;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels;
using Alfateam.Website.API.Models.EditModels.General;
using Alfateam.Website.API.Models.LocalizationEditModels;
using Alfateam.Website.API.Models.LocalizationEditModels.Posts;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPartnersController : AbsAdminController
    {
        public AdminPartnersController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {

        }

        #region Партнеры

        [HttpGet, Route("GetPartners")]
        public async Task<RequestResult<IEnumerable<PartnerClientModel>>> GetPartners(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PartnerClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Partners, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPartnersIncluded(), offset, count);
                    var models = PartnerClientModel.CreateItems(items.Cast<Partner>(), LanguageId);
                    return RequestResult<IEnumerable<PartnerClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPartner")]
        public async Task<RequestResult<Partner>> GetPartner(int id)
        {
            var item = GetPartnersIncluded().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Partner>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, item, ContentAccessModelType.Partners, 1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(session.User, item),403, "У данного пользователя нет доступа к записи"),
                () => RequestResult<Partner>.AsSuccess(item)
            });
        }

        [HttpGet, Route("GetPartnerLocalization")]
        public async Task<RequestResult<PartnerLocalization>> GetPartnerLocalization(int id)
        {
            var localization = DB.PartnerLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<PartnerLocalization>.AsError(404, "Сущность с данным id не найдена");

            var partner = GetPartnersIncluded().FirstOrDefault(o => o.Id == localization.PartnerId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<PartnerLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(partner != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, partner, ContentAccessModelType.Partners, 1),
                () => RequestResult<PartnerLocalization>.AsSuccess(localization)
            });
        }








        [HttpPost, Route("CreatePartner")]
        public async Task<RequestResult<Partner>> CreatePartner(Partner item)
        {
            return await TryCreate(DB.Partners, item, ContentAccessModelType.Partners, () => PreparePartnerBeforeCreate(item));
        }

        [HttpPost, Route("CreatePartnerLocalization")]
        public async Task<RequestResult<PartnerLocalization>> CreatePartnerLocalization(int itemId, PartnerLocalization localization)
        {
            var mainEntity = GetPartnersIncluded().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<PartnerLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Partners),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    return UpdateModel(DB.Partners,mainEntity);
                }
            });
        }






        [HttpPut, Route("UpdatePartnerMain")]
        public async Task<RequestResult<Partner>> UpdatePostCategoryMain(PartnerMainEditModel model)
        {
            var item = GetPartnersIncluded().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<Partner>(new[]
            {
                () => CheckMainModelBeforeUpdate(item, model,ContentAccessModelType.Partners),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => PreparePartnerBeforeUpdate(item).Result,
                () => UpdateModel(DB.Partners, model, item)
            });
        }

        [HttpPut, Route("UpdatePartnerLocalization")]
        public async Task<RequestResult<PartnerLocalization>> UpdatePartnerLocalization(PartnerLocalizationEditModel model)
        {
            var localization = DB.PartnerLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PartnerLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPartnersIncluded(), model, localization.PartnerId, ContentAccessModelType.Partners),
                () => UpdateModel(DB.PartnerLocalizations, model, localization)
            });
        }




        [HttpDelete, Route("DeletePartner")]
        public async Task<RequestResult> DeletePartner(int id)
        {
            var item = GetPartnersIncluded().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null, 404, "Запись по данному id не найдена"),
                () => TryDelete(DB.Partners, item, ContentAccessModelType.Partners)
            });
        }
        [HttpDelete, Route("DeletePartnerLocalization")]
        public async Task<RequestResult> DeletePartnerLocalization(int id)
        {
            var item = DB.PartnerLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPartnersIncluded(), item.PartnerId, ContentAccessModelType.Partners),
                () => DeleteModel(DB.PartnerLocalizations, item, false)
            });
        }

        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.Partners.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Partners);
        }





        #region Private prepare methods

        private async Task<RequestResult> PreparePartnerBeforeCreate(Partner partner)
        {
            //Загрузка главной картинки
            var mainFileUploadResult = await TryUploadFile($"mainImg", FileType.Image);
            if (!mainFileUploadResult.Success)
            {
                return mainFileUploadResult;
            }
            partner.LogoPath = mainFileUploadResult.Value;
            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> PreparePartnerBeforeUpdate(Partner partner)
        {
            if(Request.Form.Files.Any(o => o.Name == "mainImg"))
            {
                //Загрузка главной картинки
                var mainFileUploadResult = await TryUploadFile($"mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }
                partner.LogoPath = mainFileUploadResult.Value;
            }
            return RequestResult.AsSuccess();
        }

        #endregion

        #region Private get included methods

        public IQueryable<Partner> GetPartnersIncluded()
        {
            return DB.Partners.IncludeAvailability()
                              .Include(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.Language)
                              .Include(o => o.MainLanguage)
                              .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
