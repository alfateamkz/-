using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Events;
using Alfateam.Website.API.Models.ClientModels.Portfolios;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels.Portfolios;
using Alfateam.Website.API.Models.LocalizationEditModels.Events;
using Alfateam.Website.API.Models.LocalizationEditModels.Portfolios;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using Alfateam2._0.Models.Portfolios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPortfolioController : AbsAdminController
    {
        public AdminPortfolioController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
            //TODO: реализовать контроллер
        }

        #region Портфолио

        [HttpGet, Route("GetPortfolios")]
        public async Task<RequestResult<IEnumerable<PortfolioClientModel>>> GetPortfolios(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PortfolioClientModel>>();

            var tryGetManyResponse = TryGetMany(GetPortfoliosList(), ContentAccessModelType.Portfolio, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = PortfolioClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetPortfolio")]
        public async Task<RequestResult<Portfolio>> GetPortfolio(int id)
        {
            return TryGetOne(GetPortfoliosFullIncludedList(), id, ContentAccessModelType.Portfolio);
        }









        [HttpDelete, Route("DeletePortfolio")]
        public async Task<RequestResult> DeletePortfolio(int id)
        {
            var res = new RequestResult();

            var item = GetPortfoliosList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.Portfolios, item, ContentAccessModelType.Portfolio);
        }

        [HttpDelete, Route("DeletePortfolioLocalization")]
        public async Task<RequestResult> DeletePortfolioLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.PortfolioLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetPortfoliosList(), item.PortfolioId, ContentAccessModelType.Portfolio);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.PortfolioLocalizations, item, false);
        }



        #endregion

        #region Категории портфолио

        [HttpGet, Route("GetPortfolioCategories")]
        public async Task<RequestResult<IEnumerable<PortfolioCategoryClientModel>>> GetPortfolioCategories(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PortfolioCategoryClientModel>>();

            var tryGetManyResponse = TryGetMany(GetPortfolioCategoriesList(), ContentAccessModelType.Portfolio, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = PortfolioCategoryClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetPortfolioCategory")]
        public async Task<RequestResult<PortfolioCategory>> GetPortfolioCategory(int id)
        {
            return TryGetOne(GetPortfolioCategoriesList(), id, ContentAccessModelType.Portfolio);
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

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Portfolio);
            if (!checkResult.Success)
            {
                return new RequestResult<PortfolioCategoryLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.PortfolioCategories.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<PortfolioCategoryLocalization>().SetSuccess(localization);
        }





        [HttpPut, Route("UpdatePortfolioCategoryMain")]
        public async Task<RequestResult<PortfolioCategory>> UpdatePortfolioCategoryMain(PortfolioCategoryMainEditModel model)
        {
            var res = new RequestResult<PortfolioCategory>();

            var baseCheckResult = CheckMainModelBeforeUpdate(GetPortfolioCategoriesList(), model, ContentAccessModelType.Portfolio);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                return UpdateModel(DB.PortfolioCategories, model, item);
            }
        }
       
        [HttpPut, Route("UpdatePortfolioCategoryLocalization")]
        public async Task<RequestResult<PortfolioCategoryLocalization>> UpdatePortfolioCategoryLocalization(PortfolioCategoryLocalizationEditModel model)
        {
            var res = new RequestResult<PortfolioCategoryLocalization>();

            var localization = DB.PortfolioCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetPortfolioCategoriesList(), model, localization.PortfolioCategoryId, ContentAccessModelType.Portfolio);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.PortfolioCategoryLocalizations, model, localization);
        }






        [HttpDelete, Route("DeletePortfolioCategory")]
        public async Task<RequestResult> DeletePortfolioCategory(int id)
        {
            var res = new RequestResult();

            var item = GetPortfolioCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.PortfolioCategories, item, ContentAccessModelType.Portfolio);
        }

        [HttpDelete, Route("DeletePortfolioCategoryLocalization")]
        public async Task<RequestResult> DeletePortfolioCategoryLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.PortfolioCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetPortfolioCategoriesList(), item.PortfolioCategoryId, ContentAccessModelType.Portfolio);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.PortfolioCategoryLocalizations, item, false);
        }

        #endregion

        #region Индустрии портфолио

        [HttpGet, Route("GetPortfolioIndustries")]
        public async Task<RequestResult<IEnumerable<PortfolioIndustryClientModel>>> GetPortfolioIndustries(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PortfolioIndustryClientModel>>();

            var tryGetManyResponse = TryGetMany(GetPortfolioIndustriesList(), ContentAccessModelType.Portfolio, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = PortfolioIndustryClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetPortfolioIndustry")]
        public async Task<RequestResult<PortfolioIndustry>> GetPortfolioIndustry(int id)
        {
            return TryGetOne(GetPortfolioIndustriesList(), id, ContentAccessModelType.Portfolio);
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

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Portfolio);
            if (!checkResult.Success)
            {
                return new RequestResult<PortfolioIndustryLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.PortfolioIndustries.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<PortfolioIndustryLocalization>().SetSuccess(localization);
        }






        [HttpPut, Route("UpdatePortfolioIndustryMain")]
        public async Task<RequestResult<PortfolioIndustry>> UpdatePortfolioIndustryMain(PortfolioIndustryMainEditModel model)
        {
            var res = new RequestResult<PortfolioIndustry>();

            var baseCheckResult = CheckMainModelBeforeUpdate(GetPortfolioIndustriesList(), model, ContentAccessModelType.Portfolio);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                return UpdateModel(DB.PortfolioIndustries, model, item);
            }
        }
        
        [HttpPut, Route("UpdatePortfolioIndustryLocalization")]
        public async Task<RequestResult<PortfolioIndustryLocalization>> UpdatePortfolioIndustryLocalization(PortfolioIndustryLocalizationEditModel model)
        {
            var res = new RequestResult<PortfolioIndustryLocalization>();

            var localization = DB.PortfolioIndustryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetPortfolioCategoriesList(), model, localization.PortfolioIndustryId, ContentAccessModelType.Portfolio);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.PortfolioIndustryLocalizations, model, localization);
        }






        [HttpDelete, Route("DeletePortfolioIndustry")]
        public async Task<RequestResult> DeletePortfolioIndustry(int id)
        {
            var res = new RequestResult();

            var item = GetPortfolioIndustriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.PortfolioIndustries, item, ContentAccessModelType.Portfolio);
        }

        [HttpDelete, Route("DeletePortfolioIndustryLocalization")]
        public async Task<RequestResult> DeletePortfolioIndustryLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.PortfolioIndustryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetPortfolioIndustriesList(), item.PortfolioIndustryId, ContentAccessModelType.Portfolio);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.PortfolioIndustryLocalizations, item, false);
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
