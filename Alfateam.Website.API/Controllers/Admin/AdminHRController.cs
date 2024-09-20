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
using Alfateam.Website.API.Exceptions;
using Alfateam2._0.Models.ContentItems;

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
        public async Task<IEnumerable<JobVacancyDTO>> GetJobVacancies(int offset, int count = 20)
        {
            var items = GetAvailableJobVacancies().Skip(offset).Take(count);
            return new JobVacancyDTO().CreateDTOs(items).Cast<JobVacancyDTO>();
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
        public async Task<JobVacancyDTO> CreateJobVacancy(JobVacancyDTO model)
        {
            return (JobVacancyDTO)DbService.TryCreateAvailabilityEntity(DB.JobVacancies, model, this.Session, async (entity) =>
            {
                await HandleJobVacancy(entity, DBModelFillMode.Create, null);
            });
        }
      
        [HttpPost, Route("CreateJobVacancyLocalization")]
        [HRSectionAccess(6)]
        public async Task<JobVacancyLocalizationDTO> CreateJobVacancyLocalization(int itemId, JobVacancyLocalizationDTO localization)
        {
            var mainEntity = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == itemId);
            return (JobVacancyLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.JobVacancies, mainEntity, localization, async (entity) =>
            {
                await HandleJobVacancyLocalization(entity, DBModelFillMode.Create, null);
            });   
        }





        [HttpPut, Route("UpdateJobVacancyMain")]
        [HRSectionAccess(4)]
        public async Task<JobVacancyDTO> UpdateJobVacancyMain(JobVacancyDTO model)
        {
            var item = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (JobVacancyDTO)DbService.TryUpdateEntity(DB.JobVacancies, model, item, async (entity) =>
            {
                await HandleJobVacancy(entity, DBModelFillMode.Update, model.InnerContent);
            });
        }
   
        [HttpPut, Route("UpdateJobVacancyLocalization")]
        [HRSectionAccess(5)]
        public async Task<JobVacancyLocalizationDTO> UpdateJobVacancyLocalization(JobVacancyLocalizationDTO model)
        {
            var localization = DB.JobVacancyLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == localization.JobVacancyId && !o.IsDeleted);

            return (JobVacancyLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.JobVacancyLocalizations, localization, model, mainEntity, async (entity) =>
            {
                await HandleJobVacancyLocalization(entity, DBModelFillMode.Update, model.InnerContent);
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

        #region Резюме

        [HttpGet, Route("GetJobSummaries")]
        [HRSectionAccess(2)]
        public async Task<IEnumerable<JobSummaryDTO>> GetJobSummaries(int vacancyId, int offset, int count = 20)
        {
            var vacancy = GetAvailableJobVacancies().FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            if(vacancy is null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            var summaries = GetSummariesList().Where(o => o.JobVacancyId == vacancyId && !o.IsDeleted).Skip(offset).Take(count);
            return new JobSummaryDTO().CreateDTOs(summaries).Cast<JobSummaryDTO>();
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

        #endregion

        #region Private prepare methods

        private async Task HandleJobVacancy(JobVacancy entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            if(!DB.Currencies.Any(o => o.Id == entity.CurrencyId && !o.IsDeleted))
            {
                throw new Exception400("Валюта с таким id не найдена");
            }
            else if(!DB.Languages.Any(o => o.Id == entity.MainLanguageId && !o.IsDeleted))
            {
                throw new Exception400("Язык с таким id не найден");
            }
            else if (entity.Expierence == null)
            {
                throw new Exception400("Поле требуемый опыт должно быть заполнено");
            }

            if(mode == DBModelFillMode.Create)
            {
                await FilesService.UploadContentMedia(entity.InnerContent);
            }
            else if(mode == DBModelFillMode.Update && !entity.InnerContent.AreSame(newContentForUpdate))
            {
                await FilesService.UpdateContentMedia(entity.InnerContent, newContentForUpdate);
            }
            
        }       
        private async Task HandleJobVacancyLocalization(JobVacancyLocalization entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            if (mode == DBModelFillMode.Create)
            {
                await FilesService.UploadContentMedia(entity.InnerContent);
            }
            else if (mode == DBModelFillMode.Update && !entity.InnerContent.AreSame(newContentForUpdate))
            {
                await FilesService.UpdateContentMedia(entity.InnerContent, newContentForUpdate);
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
