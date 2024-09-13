using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTOLocalization.HR;
using Alfateam.Website.API.Models.DTOLocalization.Shop;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.HR;
using Alfateam2._0.Models.Localization.Items.HR;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminHRController : AbsAdminController
    {
        public AdminHRController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
   
        }


        #region Вакансии

        [HttpGet, Route("GetJobVacancies")]
        public async Task<RequestResult<IEnumerable<JobVacancyDTO>>> GetJobVacancies(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<JobVacancyDTO>>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => {
                    var items = GetAvailableModels(GetSessionWithRoleInclude().User, GetVacanciesList(), offset, count);
                    var models = JobVacancyDTO.CreateItemsWithLocalization(items.Cast<JobVacancy>(), LanguageId) as IEnumerable<JobVacancyDTO>;
                    return RequestResult<IEnumerable<JobVacancyDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetJobVacancy")]
        public async Task<RequestResult<JobVacancy>> GetJobVacancy(int id)
        {
            var item = GetVacanciesFullIncludedList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<JobVacancy>(new[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item),403, "У данного пользователя нет доступа к записи"),
                () => RequestResult<JobVacancy>.AsSuccess(item)
            });
        }

        [HttpGet, Route("GetJobVacancyLocalization")]
        public async Task<RequestResult<JobVacancyLocalization>> GetJobVacancyLocalization(int id)
        {
            var localization = DB.JobVacancyLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<JobVacancyLocalization>.AsError(404, "Сущность с данным id не найдена");

            var vacancy = GetVacanciesList().FirstOrDefault(o => o.Id == localization.JobVacancyId);
            return TryFinishAllRequestes<JobVacancyLocalization>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(vacancy != null, 500, "Внутренняя ошибка"),
                () => RequestResult<JobVacancyLocalization>.AsSuccess(localization)
            });
        }






        [HttpPost, Route("CreateJobVacancy")]
        public async Task<RequestResult<JobVacancy>> CreateProduct(JobVacancy item)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<JobVacancy>(new[]
            {
                () => CheckSession(session),
                () => CheckAccess(6),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => CanSetAvailabilityCountries(session.User, item.Availability),
                () => PrepareVacancyBeforeCreate(item).Result,
                () => CreateModel(DB.JobVacancies,item)
             });
        }
      
        [HttpPost, Route("CreateJobVacancyLocalization")]
        public async Task<RequestResult<JobVacancyLocalization>> CreateJobVacancyLocalization(int itemId, JobVacancyLocalization localization)
        {
            var mainEntity = GetVacanciesList().FirstOrDefault(o => o.Id == itemId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<JobVacancyLocalization>(new[]
            {
                () => CheckAccess(6),
                () => RequestResult.FromBoolean(mainEntity != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => PrepareVacancyLocalizationBeforeCreate(localization).Result,
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.JobVacancies,mainEntity);
                    return RequestResult<JobVacancyLocalization>.AsSuccess(localization);
                }
            });     
        }





        [HttpPut, Route("UpdateJobVacancyMain")]
        public async Task<RequestResult<JobVacancy>> UpdateJobVacancyMain(JobVacancyDTO model)
        {
            var item = GetVacanciesFullIncludedList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<JobVacancy>(new[]
            {
                 () => CheckAccess(4),
                 () => RequestResult.FromBoolean(item != null, 404,  "Запись по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => PrepareVacancyMainBeforeUpdate(item,model).Result,
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.JobVacancies, model, item)
            });
        }
   
        [HttpPut, Route("UpdateJobVacancyLocalization")]
        public async Task<RequestResult<JobVacancyLocalization>> UpdateJobVacancyLocalization(JobVacancyLocalizationDTO model)
        {
            var localization = DB.JobVacancyLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null) return RequestResult<JobVacancyLocalization>.AsError(404, "Локализация с данным id не найдена");

            var mainEntity = GetVacanciesList().FirstOrDefault(o => o.Id == localization.JobVacancyId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<JobVacancyLocalization>(new[]
            {
                 () => CheckAccess(5),
                 () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => PrepareVacancyLocalizationBeforeUpdate(localization,model).Result,
                 () => UpdateModel(DB.JobVacancyLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeleteJobVacancy")]
        public async Task<RequestResult> DeleteJobVacancy(int id)
        {
            var item = GetVacanciesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(7),
                 () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, item), 403, "У данного пользователя нет доступа к записи"),
                 () => DeleteModel(DB.JobVacancies, item)
            });
        }

        [HttpDelete, Route("DeleteJobVacancyLocalization")]
        public async Task<RequestResult> DeleteJobVacancyLocalization(int id)
        {
            var localization = DB.JobVacancyLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult.AsError(404, "Запись по данному id не найдена");

            var mainEntity = DB.ShopProducts.FirstOrDefault(o => o.Id == localization.JobVacancyId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(7),
                 () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, mainEntity), 403, "У данного пользователя нет доступа к записи"),
                 () => DeleteModel(DB.JobVacancyLocalizations, localization, false)
            });
        }



        #endregion

        #region Резюме

        [HttpGet, Route("GetJobSummaries")]
        public async Task<RequestResult<IEnumerable<JobSummary>>> GetJobSummaries(int vacancyId, int offset, int count = 20)
        {
            var vacancy = GetVacanciesFullIncludedList().FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            var user = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes<IEnumerable<JobSummary>>(new[]
            {
                () => CheckAccess(2),
                () => RequestResult.FromBoolean(vacancy != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, vacancy),403, "У данного пользователя нет доступа к записи"),
                () => {
                    var summaries = GetSummariesList().Where(o => o.JobVacancyId == vacancyId).Skip(offset).Take(count);
                    return RequestResult<IEnumerable<JobSummary>>.AsSuccess(summaries);
                }
            });
        }

        [HttpGet, Route("GetJobSummary")]
        public async Task<RequestResult<JobSummary>> GetJobSummary(int id)
        {
            var summary = GetSummariesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (summary == null) return RequestResult<JobSummary>.AsError(404, "Сущность по данному id не найдена");

            var vacancy = GetVacanciesList().FirstOrDefault(o => o.Id == summary.JobVacancyId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<JobSummary>(new[]
            {
                () => CheckAccess(2),
                () => RequestResult.FromBoolean(vacancy != null, 500, "Внутренняя ошибка"),
                () => RequestResult.FromBoolean(this.CheckBasePermissions(user, vacancy),403, "У данного пользователя нет доступа к записи"),
                () => RequestResult<JobSummary>.AsSuccess(summary)
            });
        }



        [HttpPut, Route("UpdateJobSummaryInfo")]
        public async Task<RequestResult> UpdateJobSummaryInfo(EditJobSummaryAdminModel model)
        {
            var summary = GetSummariesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (summary == null) return RequestResult<JobSummary>.AsError(404, "Сущность по данному id не найдена");

            var vacancy = GetVacanciesList().FirstOrDefault(o => o.Id == summary.JobVacancyId);
            var user = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes(new[]
            {
                 () => CheckAccess(3),
                 () => RequestResult.FromBoolean(vacancy != null, 500, "Внутренняя ошибка"),
                 () => RequestResult.FromBoolean(this.CheckBasePermissions(user, vacancy),403, "У данного пользователя нет доступа к записи"),
                 () => RequestResult.FromBoolean(model.IsValid(),400,"Проверьте корректность заполнения данных"),
                 () => UpdateModel(DB.JobSummaries, model, summary)
            });
        }



        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.JobVacancies.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            var availability = DB.GetIncludedAvailability(model.Id);
            return TryFinishAllRequestes<Availability>(new[]
            {
                () => RequestResult.FromBoolean(availability != null, 404, "Запись по данному id не найдена"),
                () => CheckAccess(4),
                () => CanSetAvailabilityCountries(user, availability),
                () => UpdateModel(DB.Availabilities, model, availability)
            });
        }





        #region Private check access methods
        private RequestResult CheckAccess(int requiredLevel)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes(new Func<RequestResult>[]
            {
                () => CheckSession(session),
                () => CheckForBan(session.User,BanType.AdminPanel),
                () => RequestResult.FromBoolean(session.User.RoleModel.Role != UserRole.User,
                        403, "У данного пользователя нет доступа в администраторскую панель"),
                () => RequestResult.FromBoolean(session.User.RoleModel.HRAccess.AccessLevel >= requiredLevel || session.User.RoleModel.Role == UserRole.Owner,
                       403, "У данного пользователя нет прав на выполнение данного действия")
             });
        }

        #endregion

        #region Private prepare methods

        private async Task<RequestResult> PrepareVacancyBeforeCreate(JobVacancy item)
        {
            item.Watches = 0;
            item.WatchesList = new List<Watch>();

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(DB.Currencies.Any(o => o.Id == item.CurrencyId && !o.IsDeleted),400,"Валюта с таким id не найдена"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == item.MainLanguageId && !o.IsDeleted),400,"Язык с таким id не найден"),
                () => RequestResult.FromBoolean(item.Expierence != null,400,"Поле требуемый опыт должно быть заполнено"),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => UploadContentMedia(item.InnerContent).Result,
                () =>
                {
                    foreach(var localization in item.Localizations)
                    {
                        var res = PrepareVacancyLocalizationBeforeCreate(localization).Result;
                        if (!res.Success)
                        {
                            return res;
                        }
                    }
                    return RequestResult.AsSuccess();
                }
            });
        }
        private async Task<RequestResult> PrepareVacancyLocalizationBeforeCreate(JobVacancyLocalization item)
        {
            return await UploadContentMedia(item.InnerContent);
        }


        private async Task<RequestResult> PrepareVacancyMainBeforeUpdate(JobVacancy item,JobVacancyDTO model)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(DB.Currencies.Any(o => o.Id == item.CurrencyId && !o.IsDeleted),400,"Валюта с таким id не найдена"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == item.MainLanguageId && !o.IsDeleted),400,"Язык с таким id не найден"),
                () => RequestResult.FromBoolean(item.Expierence != null,400,"Поле требуемый опыт должно быть заполнено"),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    if (!item.InnerContent.AreSame(model.InnerContent))
                    {
                        item.InnerContent = model.InnerContent;
                        return UploadContentMedia(model.InnerContent).Result;
                    }
                    return RequestResult.AsSuccess();
                }
            });
        }
        private async Task<RequestResult> PrepareVacancyLocalizationBeforeUpdate(JobVacancyLocalization item, JobVacancyLocalizationDTO model)
        {
            if (!item.InnerContent.AreSame(model.InnerContent))
            {
                item.InnerContent = model.InnerContent;
                return await UploadContentMedia(model.InnerContent);
            }
            return RequestResult.AsSuccess();
        }


        #endregion

        #region Private get included methods

        private IQueryable<JobVacancy> GetVacanciesList()
        {
            return DB.JobVacancies.IncludeAvailability()
                                  .Include(o => o.Expierence)
                                  .Include(o => o.Currency)
                                  .Include(o => o.WatchesList)
                                  .Include(o => o.Localizations)
                                  .Where(o => !o.IsDeleted);
        }
        private IQueryable<JobVacancy> GetVacanciesFullIncludedList()
        {
            return DB.JobVacancies.IncludeAvailability()
                                  .Include(o => o.Expierence)
                                  .Include(o => o.Currency)
                                  .Include(o => o.WatchesList)
                                  .Include(o => o.InnerContent).ThenInclude(o => o.Items)
                                  .Include(o => o.MainLanguage)
                                  .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                  .Where(o => !o.IsDeleted);
        }

        private IQueryable<JobSummary> GetSummariesList()
        {
            return DB.JobSummaries.Include(o => o.CreatedBy).Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
