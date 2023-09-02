using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Events;
using Alfateam.Website.API.Models.ClientModels.Portfolios;
using Alfateam.Website.API.Models.EditModels.General;
using Alfateam.Website.API.Models.EditModels.Portfolios;
using Alfateam.Website.API.Models.LocalizationEditModels.Events;
using Alfateam.Website.API.Models.LocalizationEditModels.Portfolios;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Team;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPortfolioController : AbsAdminController
    {
        public AdminPortfolioController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        
        }

        #region Портфолио

        [HttpGet, Route("GetPortfolios")]
        public async Task<RequestResult<IEnumerable<PortfolioClientModel>>> GetPortfolios(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PortfolioClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Portfolio, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPortfoliosList(), offset, count);
                    var models = PortfolioClientModel.CreateItems(items.Cast<Portfolio>(), LanguageId);
                    return RequestResult<IEnumerable<PortfolioClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPortfolio")]
        public async Task<RequestResult<Portfolio>> GetPortfolio(int id)
        {
            return TryGetOne(GetPortfoliosFullIncludedList(), id, ContentAccessModelType.Portfolio);
        }

        [HttpGet, Route("GetPortfolioLocalization")]
        public async Task<RequestResult<PortfolioLocalization>> GetPortfolioLocalization(int id)
        {
            var localization = DB.PortfolioLocalizations.Include(o => o.Language)
                                                                .Include(o => o.Content).ThenInclude(o => o.Items)
                                                                .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<PortfolioLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetPortfolioCategoriesList().FirstOrDefault(o => o.Id == localization.PortfolioId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<PortfolioLocalization>(new[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Portfolio, 1),
                () => RequestResult<PortfolioLocalization>.AsSuccess(localization)
            });
        }




        [HttpPost, Route("CreatePortfolio")]
        public async Task<RequestResult<Portfolio>> CreatePortfolio(Portfolio item)
        {
            return await TryCreate(DB.Portfolios, item, ContentAccessModelType.Portfolio, () =>  PreparePortfolioBeforeCreate(item));
        }

        [HttpPost, Route("CreatePortfolioLocalization")]
        public async Task<RequestResult<PortfolioLocalization>> CreatePortfolioLocalization(int itemId, PortfolioLocalization localization)
        {
            var mainEntity = GetPortfoliosList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<PortfolioLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Portfolio),
                () => PreparePortfolioLocalizationBeforeCreate(localization).Result,
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.Portfolios,mainEntity);
                    return RequestResult<PortfolioLocalization>.AsSuccess(localization);
                }
            });


        }




        [HttpPut, Route("UpdatePortfolioMain")]
        public async Task<RequestResult<Portfolio>> UpdatePortfolioMain(PortfolioMainEditModel model)
        {
            var item = GetPortfoliosList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Portfolio>(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Сущность по данному id не найдена"),
                () => CheckContentAreaRights(session, item, ContentAccessModelType.Portfolio, 2),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),404, "Языка с данным id не существует"),
                () => PreparePortfolioBeforeUpdate(item, model).Result,
                () => UpdateModel(DB.Portfolios, item)
            });
        }

        [HttpPut, Route("UpdatePortfolioLocalization")]
        public async Task<RequestResult<PortfolioLocalization>> UpdatePortfolioLocalization(PortfolioLocalizationEditModel model)
        {
            var localization = DB.PortfolioLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PortfolioLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPortfoliosList(), model, localization.PortfolioId, ContentAccessModelType.Portfolio),
                () => PreparePortfolioLocalizationBeforeUpdate(localization, model).Result,
                () => UpdateModel(DB.PortfolioLocalizations, localization)
            });
        }






        [HttpDelete, Route("DeletePortfolio")]
        public async Task<RequestResult> DeletePortfolio(int id)
        {
            var item = GetPortfoliosList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null, 404, "Категория по данному id не найдена"),
                () => TryDelete(DB.Portfolios, item, ContentAccessModelType.Portfolio)
            });
        }

        [HttpDelete, Route("DeletePortfolioLocalization")]
        public async Task<RequestResult> DeletePortfolioLocalization(int id)
        {
            var item = DB.PortfolioLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPortfolioCategoriesList(), item.PortfolioId, ContentAccessModelType.Portfolio),
                () => DeleteModel(DB.PortfolioLocalizations, item, false)
            });
        }



        #endregion

        #region Категории портфолио

        [HttpGet, Route("GetPortfolioCategories")]
        public async Task<RequestResult<IEnumerable<PortfolioCategoryClientModel>>> GetPortfolioCategories(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PortfolioCategoryClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Portfolio, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPortfolioCategoriesList(), offset, count);
                    var models = PortfolioCategoryClientModel.CreateItems(items.Cast<PortfolioCategory>(), LanguageId);
                    return RequestResult<IEnumerable<PortfolioCategoryClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPortfolioCategory")]
        public async Task<RequestResult<PortfolioCategory>> GetPortfolioCategory(int id)
        {
            return TryGetOne(GetPortfolioCategoriesList(), id, ContentAccessModelType.Portfolio);
        }

        [HttpGet, Route("GetPortfolioCategoryLocalization")]
        public async Task<RequestResult<PortfolioCategoryLocalization>> GetPortfolioCategoryLocalization(int id)
        {
            var localization = DB.PortfolioCategoryLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<PortfolioCategoryLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetPortfolioCategoriesList().FirstOrDefault(o => o.Id == localization.PortfolioCategoryId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<PortfolioCategoryLocalization>(new[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Portfolio, 1),
                () => RequestResult<PortfolioCategoryLocalization>.AsSuccess(localization)
            });
        }

        




        [HttpPost, Route("CreatePortfolioCategory")]
        public async Task<RequestResult<PortfolioCategory>> CreatePortfolioCategory(PortfolioCategory item)
        {
            return TryCreate(DB.PortfolioCategories, item, ContentAccessModelType.Portfolio);
        }

        [HttpPost, Route("CreatePortfolioCategoryLocalization")]
        public async Task<RequestResult<PortfolioCategoryLocalization>> CreatePortfolioCategoryLocalization(int itemId, PortfolioCategoryLocalization localization)
        {
            var mainEntity = GetPortfolioCategoriesList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<PortfolioCategoryLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Portfolio),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.PortfolioCategories,mainEntity);
                    return RequestResult<PortfolioCategoryLocalization>.AsSuccess(localization);
                }
            });
        }





        [HttpPut, Route("UpdatePortfolioCategoryMain")]
        public async Task<RequestResult<PortfolioCategory>> UpdatePortfolioCategoryMain(PortfolioCategoryMainEditModel model)
        {
            var item = GetPortfolioCategoriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PortfolioCategory>(new[]
            {
                () => CheckMainModelBeforeUpdate(item, model,ContentAccessModelType.Portfolio),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => UpdateModel(DB.PortfolioCategories, model, item)
            });
        }
       
        [HttpPut, Route("UpdatePortfolioCategoryLocalization")]
        public async Task<RequestResult<PortfolioCategoryLocalization>> UpdatePortfolioCategoryLocalization(PortfolioCategoryLocalizationEditModel model)
        {
            var localization = DB.PortfolioCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PortfolioCategoryLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPortfolioCategoriesList(), model, localization.PortfolioCategoryId, ContentAccessModelType.Portfolio),
                () => UpdateModel(DB.PortfolioCategoryLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeletePortfolioCategory")]
        public async Task<RequestResult> DeletePortfolioCategory(int id)
        {
            var item = GetPortfolioCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null, 404, "Категория по данному id не найдена"),
                () => TryDelete(DB.PortfolioCategories, item, ContentAccessModelType.Portfolio)
            });
        }

        [HttpDelete, Route("DeletePortfolioCategoryLocalization")]
        public async Task<RequestResult> DeletePortfolioCategoryLocalization(int id)
        {
            var item = DB.PortfolioCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPortfolioCategoriesList(), item.PortfolioCategoryId, ContentAccessModelType.Portfolio),
                () => DeleteModel(DB.PortfolioCategoryLocalizations, item, false)
            });
        }

        #endregion

        #region Индустрии портфолио

        [HttpGet, Route("GetPortfolioIndustries")]
        public async Task<RequestResult<IEnumerable<PortfolioIndustryClientModel>>> GetPortfolioIndustries(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PortfolioIndustryClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Portfolio, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPortfolioIndustriesList(), offset, count);
                    var models = PortfolioIndustryClientModel.CreateItems(items.Cast<PortfolioIndustry>(), LanguageId);
                    return RequestResult<IEnumerable<PortfolioIndustryClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPortfolioIndustry")]
        public async Task<RequestResult<PortfolioIndustry>> GetPortfolioIndustry(int id)
        {
            return TryGetOne(GetPortfolioIndustriesList(), id, ContentAccessModelType.Portfolio);
        }

        [HttpGet, Route("GetPortfolioIndustryLocalization")]
        public async Task<RequestResult<PortfolioIndustryLocalization>> GetPortfolioIndustryLocalization(int id)
        {
            var localization = DB.PortfolioIndustryLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<PortfolioIndustryLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetPortfolioIndustriesList().FirstOrDefault(o => o.Id == localization.PortfolioIndustryId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<PortfolioIndustryLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Portfolio, 1),
                () => RequestResult<PortfolioIndustryLocalization>.AsSuccess(localization)
            });
        }




        [HttpPost, Route("CreatePortfolioIndustry")]
        public async Task<RequestResult<PortfolioIndustry>> CreatePortfolioIndustry(PortfolioIndustry item)
        {
            return TryCreate(DB.PortfolioIndustries, item, ContentAccessModelType.Portfolio);
        }

        [HttpPost, Route("CreatePortfolioIndustryLocalization")]
        public async Task<RequestResult<PortfolioIndustryLocalization>> CreatePortfolioIndustryLocalization(int itemId, PortfolioIndustryLocalization localization)
        {
            var mainEntity = GetPortfolioIndustriesList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<PortfolioIndustryLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Portfolio),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.PortfolioIndustries,mainEntity);
                    return RequestResult<PortfolioIndustryLocalization>.AsSuccess(localization);
                }
            });
        }






        [HttpPut, Route("UpdatePortfolioIndustryMain")]
        public async Task<RequestResult<PortfolioIndustry>> UpdatePortfolioIndustryMain(PortfolioIndustryMainEditModel model)
        {
            var item = GetPortfolioIndustriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PortfolioIndustry>(new[]
            {
                () => CheckMainModelBeforeUpdate(item, model,ContentAccessModelType.Portfolio),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => UpdateModel(DB.PortfolioIndustries, model, item)
            });
        }
        
        [HttpPut, Route("UpdatePortfolioIndustryLocalization")]
        public async Task<RequestResult<PortfolioIndustryLocalization>> UpdatePortfolioIndustryLocalization(PortfolioIndustryLocalizationEditModel model)
        {
            var localization = DB.PortfolioIndustryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PortfolioIndustryLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPortfolioIndustriesList(), model, localization.PortfolioIndustryId, ContentAccessModelType.Portfolio),
                () => UpdateModel(DB.PortfolioIndustryLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeletePortfolioIndustry")]
        public async Task<RequestResult> DeletePortfolioIndustry(int id)
        {
            var item = GetPortfolioIndustriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null, 404, "Категория по данному id не найдена"),
                () => TryDelete(DB.PortfolioIndustries, item, ContentAccessModelType.Portfolio)
            });
        }

        [HttpDelete, Route("DeletePortfolioIndustryLocalization")]
        public async Task<RequestResult> DeletePortfolioIndustryLocalization(int id)
        {
            var item = DB.PortfolioIndustryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPortfolioIndustriesList(), item.PortfolioIndustryId, ContentAccessModelType.Portfolio),
                () => DeleteModel(DB.PortfolioIndustryLocalizations, item, false)
            });
        }



        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.Portfolios.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= GetAvailableModels(user, DB.PortfolioCategories.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= GetAvailableModels(user, DB.PortfolioIndustries.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Portfolio);
        }





        #region Private methods
        
        private async Task<RequestResult> PreparePortfolioBeforeCreate(Portfolio item)
        {
            item.Category = null;
            item.Industry = null;
            item.WatchesList = new List<Watch>();
            item.LikesList = new List<RateVote>();

            var imgUploadResult = await TryUploadFile("mainImg", FileType.Image);
            if (!imgUploadResult.Success)
            {
                return imgUploadResult;
            }
            item.ImgPath = imgUploadResult.Value;


            var mainContentPageUploadRes = await this.UploadContentMedia(item.Content);
            if (!mainContentPageUploadRes.Success)
            {
                return mainContentPageUploadRes;
            }
            
            foreach(var localization in item.Localizations)
            {
                var localizationPrepareRes = await PreparePortfolioLocalizationBeforeCreate(localization);
                if (!localizationPrepareRes.Success)
                {
                    return localizationPrepareRes;
                }
            }

            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> PreparePortfolioBeforeUpdate(Portfolio item, PortfolioMainEditModel model)
        {

            if(Request.Form.Files.Any(o => o.Name == "mainImg"))
            {
                var imgUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!imgUploadResult.Success)
                {
                    return imgUploadResult;
                }
                item.ImgPath = imgUploadResult.Value;
            }

            if (!item.Content.AreSame(model.Content))
            {
                var contentPageUploadRes = await this.UploadContentMedia(item.Content);
                if (!contentPageUploadRes.Success)
                {
                    return contentPageUploadRes;
                }
                item.Content = model.Content;
            }

            return RequestResult.AsSuccess();
        }


        private async Task<RequestResult> PreparePortfolioLocalizationBeforeCreate(PortfolioLocalization item)
        {
            var imgUploadResult = await TryUploadFile($"{item.LanguageId}_localization_Img", FileType.Image);
            if (!imgUploadResult.Success)
            {
                return new RequestResult().FillFromRequestResult(imgUploadResult);
            }
            item.ImgPath = imgUploadResult.Value;


            var mainContentPageUploadRes = await this.UploadContentMedia(item.Content);
            if (!mainContentPageUploadRes.Success)
            {
                return new RequestResult().FillFromRequestResult(mainContentPageUploadRes);
            }

            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> PreparePortfolioLocalizationBeforeUpdate(PortfolioLocalization item, PortfolioLocalizationEditModel model)
        {
            string formFileName = $"{item.LanguageId}_localization_Img";
            if (Request.Form.Files.Any(o => o.Name == formFileName))
            {
                var imgUploadResult = await TryUploadFile(formFileName, FileType.Image);
                if (!imgUploadResult.Success)
                {
                    return imgUploadResult;
                }
                item.ImgPath = imgUploadResult.Value;
            }

            if (!item.Content.AreSame(model.Content))
            {
                var contentPageUploadRes = await this.UploadContentMedia(item.Content);
                if (!contentPageUploadRes.Success)
                {
                    return contentPageUploadRes;
                }
                item.Content = model.Content;
            }


            return RequestResult.AsSuccess();
        }

        #endregion

        #region Private get included methods
        private IQueryable<Portfolio> GetPortfoliosList()
        {
            return DB.Portfolios.IncludeAvailability()
                                .Include(o => o.Category).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Category).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                .Include(o => o.Industry).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Industry).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                .Include(o => o.MainLanguage)
                                .Where(o => !o.IsDeleted);
        }
        private IQueryable<Portfolio> GetPortfoliosFullIncludedList()
        {
            return DB.Portfolios.IncludeAvailability()
                                .Include(o => o.Category).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Category).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                .Include(o => o.Industry).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Industry).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                                .Include(o => o.Content).ThenInclude(o => o.Items)
                                .Include(o => o.MainLanguage)
                                .Where(o => !o.IsDeleted);
        }


        private IQueryable<PortfolioCategory> GetPortfolioCategoriesList()
        {
            return DB.PortfolioCategories.IncludeAvailability()
                                         .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                         .Include(o => o.MainLanguage)
                                         .Where(o => !o.IsDeleted);
        }
        private IQueryable<PortfolioIndustry> GetPortfolioIndustriesList()
        {
            return DB.PortfolioIndustries.IncludeAvailability()
                                         .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                         .Include(o => o.MainLanguage)
                                         .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
