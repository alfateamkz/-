using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO.General;
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
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Core.Exceptions;
using Alfateam2._0.Models.ContentItems;
using Alfateam.Website.API.Models.Filters.Admin.AdminSearch;
using Alfateam.Core;
using Alfateam.Website.API.Models.DTO;
using Alfateam2._0.Models;
using Alfateam.Core.Helpers;
using Alfateam.Website.API.Helpers;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminHRController : AbsAdminController
    {
        public AdminHRController(ControllerParams @params) : base(@params)
        {
        }


        #region Вакансии



        [HttpGet, Route("GetJobVacancies")]
        [HRSectionAccess(1)]
        public async Task<ItemsWithTotalCount<JobVacancyDTO>> GetJobVacancies(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<JobVacancy, JobVacancyDTO>(GetAvailableJobVacancies(), offset, count);
        }
        [HttpGet, Route("GetJobVacanciesFiltered")]
        [HRSectionAccess(1)]
        public async Task<ItemsWithTotalCount<JobVacancyDTO>> GetJobVacanciesFiltered([FromQuery] JobVacanciesSearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<JobVacancy, JobVacancyDTO>(filter.Filter(GetAvailableJobVacancies()), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }

        [HttpGet, Route("GetJobVacancy")]
        [HRSectionAccess(1)]
        public async Task<JobVacancyDTO> GetJobVacancy(int id)
        {
            return (JobVacancyDTO)DbService.TryGetOne(GetAvailableJobVacancies(), id, new JobVacancyDTO());
        }


        [HttpGet, Route("GetJobVacancyLocalizations")]
        [HRSectionAccess(1)]
        public async Task<IEnumerable<JobVacancyLocalizationDTO>> GetJobVacancyLocalizations(int id)
        {
            var localizations = DB.JobVacancyLocalizations.Include(o => o.LanguageEntity).Where(o => o.JobVacancyId == id && !o.IsDeleted);
            var mainEntity = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new JobVacancyLocalizationDTO()).Cast<JobVacancyLocalizationDTO>();
        }

        [HttpGet, Route("GetJobVacancyLocalization")]
        [HRSectionAccess(1)]
        public async Task<JobVacancyLocalizationDTO> GetJobVacancyLocalization(int id)
        {
            var localization = DB.JobVacancyLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == localization?.JobVacancyId && !o.IsDeleted);

            return (JobVacancyLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new JobVacancyLocalizationDTO());
        }






        [HttpPost, Route("CreateJobVacancy")]
        [HRSectionAccess(6)]
        public async Task<JobVacancyDTO> CreateJobVacancy([FromForm(Name = "model")]JobVacancyDTO model)
        {         
            return (JobVacancyDTO)DbService.TryCreateAvailabilityEntity(DB.JobVacancies, model, this.Session, (entity) =>
            {
                HandleJobVacancy(entity, DBModelFillMode.Create, null);
            });
        }
      
        [HttpPost, Route("CreateJobVacancyLocalization")]
        [HRSectionAccess(6)]
        public async Task<JobVacancyLocalizationDTO> CreateJobVacancyLocalization(int itemId, JobVacancyLocalizationDTO localization)
        {
            var mainEntity = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == itemId);
            return (JobVacancyLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.JobVacancies, mainEntity, localization, (entity) =>
            {
                HandleJobVacancyLocalization(entity, DBModelFillMode.Create, null);
            });   
        }





        [HttpPut, Route("UpdateJobVacancyMain")]
        [HRSectionAccess(4)]
        public async Task<JobVacancyDTO> UpdateJobVacancyMain(JobVacancyDTO model)
        {
            var item = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (JobVacancyDTO)DbService.TryUpdateEntity(DB.JobVacancies, model, item, (entity) =>
            {
                HandleJobVacancy(entity, DBModelFillMode.Update, model.InnerContent.CreateDBModelFromDTO());
            });
        }
   
        [HttpPut, Route("UpdateJobVacancyLocalization")]
        [HRSectionAccess(5)]
        public async Task<JobVacancyLocalizationDTO> UpdateJobVacancyLocalization(JobVacancyLocalizationDTO model)
        {
            var localization = DB.JobVacancyLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == localization.JobVacancyId && !o.IsDeleted);

            return (JobVacancyLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.JobVacancyLocalizations, localization, model, mainEntity, (entity) =>
            {
                HandleJobVacancyLocalization(entity, DBModelFillMode.Update, model.InnerContent.CreateDBModelFromDTO());
            });
        }






        [HttpDelete, Route("DeleteJobVacancy")]
        [HRSectionAccess(7)]
        public async Task DeleteJobVacancy(int id)
        {
            var item = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.JobVacancies, item);
        }

        [HttpDelete, Route("DeleteJobVacancyLocalization")]
        [HRSectionAccess(7)]
        public async Task DeleteJobVacancyLocalization(int id)
        {
            var item = DB.JobVacancyLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.JobVacancies.FirstOrDefault(o => o.Id == item.JobVacancyId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.JobVacancyLocalizations, item, mainModel);
        }



        #endregion

        #region Категории вакансий


        [HttpGet, Route("GetJobVacancyCategories")]
        [HRSectionAccess(1)]
        public async Task<ItemsWithTotalCount<JobVacancyCategoryDTO>> GetJobVacancyCategories(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<JobVacancyCategory, JobVacancyCategoryDTO>(GetAvailableJobVacancyCategories(), offset, count);
        }
        [HttpGet, Route("GetJobVacancyCategoriesFiltered")]
        [HRSectionAccess(1)]
        public async Task<ItemsWithTotalCount<JobVacancyCategoryDTO>> GetJobVacancyCategoriesFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<JobVacancyCategory, JobVacancyCategoryDTO>(GetAvailableJobVacancyCategories(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }

        [HttpGet, Route("GetJobVacancyCategory")]
        [HRSectionAccess(1)]
        public async Task<JobVacancyCategoryDTO> GetJobVacancyCategory(int id)
        {
            return (JobVacancyCategoryDTO)DbService.TryGetOne(GetAvailableJobVacancyCategories(), id, new JobVacancyCategoryDTO());
        }


        [HttpGet, Route("GetJobVacancyCategoryLocalizations")]
        [HRSectionAccess(1)]
        public async Task<IEnumerable<JobVacancyCategoryLocalizationDTO>> GetJobVacancyCategoryLocalizations(int id)
        {
            var localizations = DB.JobVacancyCategoryLocalizations.Include(o => o.LanguageEntity).Where(o => o.JobVacancyCategoryId == id && !o.IsDeleted);
            var mainEntity = GetAvailableJobVacancyCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new JobVacancyCategoryLocalizationDTO()).Cast<JobVacancyCategoryLocalizationDTO>();
        }

        [HttpGet, Route("GetJobVacancyCategoryLocalization")]
        [HRSectionAccess(1)]
        public async Task<JobVacancyCategoryLocalizationDTO> GetJobVacancyCategoryLocalization(int id)
        {
            var localization = DB.JobVacancyCategoryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableJobVacancyCategories().FirstOrDefault(o => o.Id == localization?.JobVacancyCategoryId && !o.IsDeleted);

            return (JobVacancyCategoryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new JobVacancyCategoryLocalizationDTO());
        }






        [HttpPost, Route("CreateJobVacancyCategory")]
        [HRSectionAccess(6)]
        public async Task<JobVacancyCategoryDTO> CreateJobVacancyCategory(JobVacancyCategoryDTO model)
        {
            return (JobVacancyCategoryDTO)DbService.TryCreateEntity(DB.JobVacancyCategories, model);
        }

        [HttpPost, Route("CreateJobVacancyCategoryLocalization")]
        [HRSectionAccess(6)]
        public async Task<JobVacancyCategoryLocalizationDTO> CreateJobVacancyLocalization(int itemId, JobVacancyCategoryLocalizationDTO localization)
        {
            var mainEntity = GetAvailableJobVacancyCategories().FirstOrDefault(o => o.Id == itemId);
            return (JobVacancyCategoryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.JobVacancyCategories, mainEntity, localization);
        }





        [HttpPut, Route("UpdateJobVacancyCategory")]
        [HRSectionAccess(4)]
        public async Task<JobVacancyCategoryDTO> UpdateJobVacancyCategory(JobVacancyCategoryDTO model)
        {
            var item = GetAvailableJobVacancyCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (JobVacancyCategoryDTO)DbService.TryUpdateEntity(DB.JobVacancyCategories, model, item);
        }

        [HttpPut, Route("UpdateJobVacancyCategoryLocalization")]
        [HRSectionAccess(5)]
        public async Task<JobVacancyCategoryLocalizationDTO> UpdateJobVacancyCategoryLocalization(JobVacancyCategoryLocalizationDTO model)
        {
            var localization = DB.JobVacancyCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableJobVacancyCategories().FirstOrDefault(o => o.Id == localization.JobVacancyCategoryId && !o.IsDeleted);

            return (JobVacancyCategoryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.JobVacancyCategoryLocalizations, localization, model, mainEntity);
        }






        [HttpDelete, Route("DeleteJobVacancyCategory")]
        [HRSectionAccess(7)]
        public async Task DeleteJobVacancyCategory(int id)
        {
            var item = GetAvailableJobVacancyCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.JobVacancyCategories, item);
        }

        [HttpDelete, Route("DeleteJobVacancyCategoryLocalization")]
        [HRSectionAccess(7)]
        public async Task DeleteJobVacancyCategoryLocalization(int id)
        {
            var item = DB.JobVacancyCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.JobVacancyCategories.FirstOrDefault(o => o.Id == item.JobVacancyCategoryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.JobVacancyCategoryLocalizations, item, mainModel);
        }



        #endregion




        #region Резюме


        [HttpGet, Route("GetJobSummaries")]
        [HRSectionAccess(2)]
        public async Task<ItemsWithTotalCount<JobSummaryDTO>> GetJobSummaries(int vacancyId, int offset, int count = 20)
        {
            var vacancy = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            if(vacancy is null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            var summaries = GetSummariesList().Where(o => o.JobVacancyId == vacancyId && !o.IsDeleted);
            return DbService.GetManyWithTotalCount<JobSummary, JobSummaryDTO>(summaries, offset, count);
        }

        [HttpGet, Route("GetJobSummariesFiltered")]
        [HRSectionAccess(2)]
        public async Task<ItemsWithTotalCount<JobSummaryDTO>> GetJobSummariesFiltered(int vacancyId, [FromQuery] JobSummariesSearchFilter filter)
        {
            var vacancy = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            if (vacancy is null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            var summaries = GetSummariesList().Where(o => o.JobVacancyId == vacancyId && !o.IsDeleted);
            return DbService.GetManyWithTotalCount<JobSummary, JobSummaryDTO>(filter.Filter(summaries), filter.Offset, filter.Count, (entity) =>
            {
                return entity.AboutInfo.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }

        [HttpGet, Route("GetJobSummary")]
        [HRSectionAccess(2)]
        public async Task<JobSummaryDTO> GetJobSummary(int id)
        {
            var summary = GetSummariesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (summary == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            var vacancy = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == summary.JobVacancyId);
            if (vacancy is null)
            {
                throw new Exception500("Внутренняя ошибка");
            }

            return (JobSummaryDTO)new JobSummaryDTO().CreateDTOWithLocalization(summary, LanguageId);
        }



        [HttpPut, Route("UpdateJobSummaryInfo")]
        [HRSectionAccess(3)]
        public async Task<JobSummaryDTO> UpdateJobSummaryInfo(EditJobSummaryAdminModel model)
        {
            var summary = GetSummariesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (summary == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            var vacancy = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == summary.JobVacancyId);
            if (vacancy is null)
            {
                throw new Exception500("Внутренняя ошибка");
            }

            return (JobSummaryDTO)DbService.TryUpdateEntity(DB.JobSummaries, model, summary);
        }



        #endregion


        [HttpPut, Route("UpdateAvailability")]
        [HRSectionAccess(4)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.JobVacancies.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }





        #region Private get available methods
        private IEnumerable<JobVacancy> GetAvailableJobVacancies()
        {
            return DbService.GetAvailableModels(this.Session.User, GetVacanciesFullIncludedList()).Cast<JobVacancy>();
        }

        private IEnumerable<JobVacancyCategory> GetAvailableJobVacancyCategories()
        {
            return DB.JobVacancyCategories.Where(c => !c.IsDeleted);
        }

        #endregion

        #region Private prepare methods

        private void HandleJobVacancy(JobVacancy entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            if (!DB.Currencies.Any(o => o.Id == entity.CurrencyId && !o.IsDeleted))
            {
                throw new Exception400("Валюта с таким id не найдена");
            }
            else if (!DB.Languages.Any(o => o.Id == entity.MainLanguageId && !o.IsDeleted))
            {
                throw new Exception400("Язык с таким id не найден");
            }
            else if (entity.Expierence == null)
            {
                throw new Exception400("Поле требуемый опыт должно быть заполнено");
            }

            if (mode == DBModelFillMode.Create)
            {
                FilesService.UploadContentMedia(entity.InnerContent);
            }
            else if (mode == DBModelFillMode.Update /*&& !entity.InnerContent.AreSame(newContentForUpdate)*/)
            {
                FilesService.UpdateContentMedia(entity.InnerContent, newContentForUpdate);
            }
        }       
        private void HandleJobVacancyLocalization(JobVacancyLocalization entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            if (mode == DBModelFillMode.Create)
            {
                FilesService.UploadContentMedia(entity.InnerContent);
            }
            else if (mode == DBModelFillMode.Update /*&& !entity.InnerContent.AreSame(newContentForUpdate)*/)
            {
                FilesService.UpdateContentMedia(entity.InnerContent, newContentForUpdate);
            }
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
                                  .Include(o => o.Category)
                                  .Where(o => !o.IsDeleted);
        }
        private IEnumerable<JobVacancy> GetVacanciesFullIncludedList()
        {
            var items = DB.JobVacancies.IncludeAvailability()
                                       .Include(o => o.Expierence)
                                       .Include(o => o.Currency)
                                       .Include(o => o.WatchesList)
                                       .Include(o => o.InnerContent).ThenInclude(o => o.Items)
                                       .Include(o => o.MainLanguage)
                                       .Include(o => o.Category)
                                       .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                       .Include(o => o.Localizations).ThenInclude(o => o.InnerContent).ThenInclude(o => o.Items)
                                       .Where(o => !o.IsDeleted)
                                       .ToList();

            ContentIncludeHelper.IncludeHierarchy(DB, items.Select(o => o.InnerContent));
            ContentIncludeHelper.IncludeHierarchy(DB, items.SelectMany(o => o.Localizations).Select(o => o.InnerContent));
            return items;
        }

        private IQueryable<JobSummary> GetSummariesList()
        {
            return DB.JobSummaries.Include(o => o.CreatedBy).Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
