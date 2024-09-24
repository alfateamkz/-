using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.Filters;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.HR;
using Alfateam.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.Website.API.Controllers.Website
{
    public class HRController : AbsController
    {
        public HRController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение вакансий

        [HttpGet, Route("GetJobVacancies")]
        public async Task<IEnumerable<JobVacancyCard>> GetJobVacancies(int offset, int count = 20)
        {
            var vacancies = GetVacancies().Skip(offset).Take(count).ToList();

            return MakeJobVacancyCards(vacancies);
        }

        [HttpGet, Route("GetJobVacanciesByFilter")]
        public async Task<IEnumerable<JobVacancyCard>> GetJobVacanciesByFilter(JobVacanciesFIlter filter)
        {
            var vacancies = GetVacancies();

            if(filter.ExperienceYearsFrom != null)
            {
                vacancies = vacancies.Where(o => o.Expierence.YearsFrom >= filter.ExperienceYearsFrom);
            }
            if (filter.ExperienceYearsTo != null)
            {
                vacancies = vacancies.Where(o => o.Expierence.YearsTo <= filter.ExperienceYearsTo);
            }
            if (filter.SalaryFrom != null)
            {
                vacancies = vacancies.Where(o => o.SalaryFrom >= filter.SalaryFrom);
            }
            if (filter.SalaryTo != null)
            {
                vacancies = vacancies.Where(o => o.SalaryTo <= filter.SalaryTo);
            }

            vacancies = vacancies.Skip(filter.Offset).Take(filter.Count);
            return MakeJobVacancyCards(vacancies);
        }

        [HttpGet, Route("GetJobVacancy")]
        public async Task<JobVacancyCard> GetJobVacancy(int id)
        {
            var vacancy = DB.JobVacancies.IncludeAvailability()
                                         .Include(o => o.Expierence)
                                         .Include(o => o.Currency)
                                         .Include(o => o.WatchesList)
                                         .Include(o => o.InnerContent).ThenInclude(o => o.Items)
                                         .Include(o => o.MainLanguage)
                                         .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                         .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                         .FirstOrDefault(o => o.Id == id);

            return MakeJobVacancyCard(vacancy);
        }

        #endregion

        #region Взаимодействие с вакансиями

        [HttpPut, Route("AddWatch")]
        public async Task AddWatch(int id, string fingerprint)
        {
            var vacancy = DB.JobVacancies.FirstOrDefault(o => o.Id == id);
            if (vacancy == null)
            {
                throw new Exception404("Вакансия по данному id не найдена");
            }

            vacancy.Watches++;
            vacancy.WatchesList.Add(new Watch
            {
                WatchedByFingerprint = fingerprint,
                WatchedById = GetUserIdIfSessionValid()
            });

            DbService.UpdateEntity(DB.JobVacancies, vacancy);
        }



        [HttpGet, Route("GetSummary")]
        public async Task<JobSummaryDTO> GetSummary(int vacancyId,string fingerprint)
        {
            var vacancy = DB.JobVacancies.Include(o => o.Summaries).FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            return (JobSummaryDTO)new JobSummaryDTO().CreateDTO(GetSummaryFromVacancy(vacancy,fingerprint));
        }

        [HttpPost, Route("CreateSummary")]
        public async Task<JobSummaryDTO> CreateSummary(int vacancyId,JobSummaryDTO model)
        {
            var vacancy = DB.JobVacancies.FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            if (vacancy == null)
            {
                throw new Exception404("Вакансия по данному id не найдена");
            }

            return (JobSummaryDTO)DbService.TryCreateEntity(DB.JobSummaries, model, async (entity) =>
            {
                entity.JobVacancyId = vacancyId;
                await HandleSummary(entity);
            });
        }

        [HttpPut, Route("UpdateSummary")]
        public async Task<JobSummaryDTO> UpdateSummary(int vacancyId, JobSummaryDTO model)
        {
            var vacancy = DB.JobVacancies.FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            var summary = GetSummaryFromVacancy(vacancy, model.CreatedByFingerprint);

            return (JobSummaryDTO)DbService.TryUpdateEntity(DB.JobSummaries, model, summary, async (entity) =>
            {
                await HandleSummary(entity);
            });
        }

        [HttpDelete, Route("RemoveSummary")]
        public async Task RemoveSummary(int vacancyId, string fingerprint)
        {
            var vacancy = DB.JobVacancies.Include(o => o.Summaries).FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            var summary = GetSummaryFromVacancy(vacancy, fingerprint);

            DbService.TryDeleteEntity(DB.JobSummaries, summary);
        }

        #endregion





        #region Private methods
        private IEnumerable<JobVacancy> GetVacancies()
        {
            return DB.JobVacancies.IncludeAvailability()
                                  .Include(o => o.Expierence)
                                  .Include(o => o.Currency)
                                  .Include(o => o.WatchesList)
                                  .Include(o => o.Localizations)
                                  .ToList()
                                  .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }


        private List<JobVacancyCard> MakeJobVacancyCards(IEnumerable<JobVacancy> vacancies)
        {
            var items = new List<JobVacancyCard>();

            foreach (var vacancy in vacancies)
            {
                items.Add(MakeJobVacancyCard(vacancy));
            }

            return items;
        }
        private JobVacancyCard MakeJobVacancyCard(JobVacancy vacancy)
        {
            int watchingNow = vacancy.WatchesList.Count(o => o.WatchedAt.AddMinutes(5) > DateTime.UtcNow);

            vacancy.WatchesList.Clear();
            return new JobVacancyCard
            {
                Vacancy = (JobVacancyDTO)new JobVacancyDTO().CreateDTOWithLocalization(vacancy, LanguageId),
                WatchingNow = watchingNow,
            };
        }

        private JobSummary GetSummaryFromVacancy(JobVacancy vacancy,string fingerprint)
        {
            if(vacancy == null)
            {
                throw new Exception404("Вакансия с данным id не найдена");
            }

            int? userId = GetUserIdIfSessionValid();
            if (userId != null)
            {
                return vacancy.Summaries.FirstOrDefault(o => o.CreatedById == userId && !o.IsDeleted);
            }
            return vacancy.Summaries.FirstOrDefault(o => o.CreatedByFingerprint == fingerprint && !o.IsDeleted);
        }






        private async Task HandleSummary(JobSummary summary)
        {
            const string formFilename = "cvFile";

            if (FilesService.IsFileUploaded(formFilename))
            {
                summary.CVPath = await FilesService.TryUploadFile(formFilename, FileType.Document);
            }
        }

        #endregion
    }
}
