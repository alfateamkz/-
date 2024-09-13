using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.Filters;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.HR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.Website.API.Controllers.Website
{
    public class HRController : AbsController
    {
        public HRController(WebsiteDBContext db) : base(db)
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
        public async Task<RequestResult> AddWatch(int id, string fingerprint)
        {
            var portfolio = DB.JobVacancies.FirstOrDefault(o => o.Id == id);
            if (portfolio != null)
            {
                int? userId = null;
                if (!string.IsNullOrEmpty(this.UserSessid))
                {
                    var session = DB.Sessions.Include(o => o.User)
                                             .FirstOrDefault(o => o.SessID == this.UserSessid);

                    var checkSessionRes = CheckSession(session);
                    if (!checkSessionRes.Success)
                    {
                        return checkSessionRes;
                    }
                    userId = session.User.Id;
                }


                portfolio.Watches++;
                portfolio.WatchesList.Add(new Watch
                {
                    WatchedByFingerprint = fingerprint,
                    WatchedById = userId
                });

                DB.JobVacancies.Update(portfolio);
                DB.SaveChanges();

                return RequestResult.AsSuccess();
            }
            else
            {
                return RequestResult.AsError(404, "Портфолио по данному id не найдено");
            }
        }



        [HttpGet, Route("GetSummary")]
        public async Task<RequestResult<JobSummary>> GetSummary(int vacancyId,string fingerprint)
        {
            var vacancy = DB.JobVacancies.Include(o => o.Summaries).FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            if (vacancy == null)
            {
                return RequestResult<JobSummary>.AsError(404, "Сушность с данным id не найдена");
            }

            return GetSummaryFromVacancy(vacancy,fingerprint);
        }

        [HttpPost, Route("CreateSummary")]
        public async Task<RequestResult> CreateSummary(int vacancyId,JobSummary summary)
        {
            var vacancy = DB.JobVacancies.FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(vacancy != null, 404,"Сушность с данным id не найдена"),
                () => RequestResult.FromBoolean(summary.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => PrepareSummaryBeforeCreate(summary).Result,
                () =>
                {
                    vacancy.Summaries.Add(summary);
                    DB.JobVacancies.Update(vacancy);
                    return RequestResult.AsSuccess();
                }
            });
        }

        [HttpPut, Route("UpdateSummary")]
        public async Task<RequestResult<JobSummary>> UpdateSummary(int vacancyId, JobSummaryDTO model)
        {
            var vacancy = DB.JobVacancies.FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            if (vacancy == null)
            {
                return RequestResult<JobSummary>.AsError(404, "Сушность с данным id не найдена");
            }
            var summaryGetResult = GetSummaryFromVacancy(vacancy, model.CreatedByFingerprint);
            if (!summaryGetResult.Success)
            {
                return summaryGetResult;
            }
            var summary = summaryGetResult.Value;

            return TryFinishAllRequestes<JobSummary>(new[]
            {
                () => RequestResult.FromBoolean(vacancy != null, 404,"Сушность с данным id не найдена"),
                () => RequestResult.FromBoolean(summary.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => PrepareSummaryBeforeUpdate(summary,model).Result,
                () =>
                {
                    DB.JobSummaries.Update(summary);
                    DB.SaveChanges();
                    return RequestResult<JobSummary>.AsSuccess(summary);
                }
            });
        }

        [HttpDelete, Route("RemoveSummary")]
        public async Task<RequestResult> RemoveSummary(int vacancyId, string fingerprint)
        {
            var vacancy = DB.JobVacancies.Include(o => o.Summaries).FirstOrDefault(o => o.Id == vacancyId && !o.IsDeleted);
            if (vacancy == null)
            {
                return RequestResult.AsError(404, "Сушность с данным id не найдена");
            }
            var summaryGetResult = GetSummaryFromVacancy(vacancy, fingerprint);
            if (!summaryGetResult.Success)
            {
                return summaryGetResult;
            }

            var summary = summaryGetResult.Value;
            summary.IsDeleted = true;
            DB.JobSummaries.Update(summary);
            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }

        #endregion





        #region Private methods
        private IQueryable<JobVacancy> GetVacancies()
        {
            return DB.JobVacancies.IncludeAvailability()
                                  .Include(o => o.Expierence)
                                  .Include(o => o.Currency)
                                  .Include(o => o.WatchesList)
                                  .Include(o => o.Localizations)
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
                Vacancy = JobVacancyDTO.CreateWithLocalization(vacancy, LanguageId) as JobVacancyDTO,
                WatchingNow = watchingNow,
            };
        }

        private RequestResult<JobSummary> GetSummaryFromVacancy(JobVacancy vacancy,string fingerprint)
        {
            int? userId = null;

            var session = DB.Sessions.Include(o => o.User).FirstOrDefault(o => o.SessID == this.UserSessid);
            if (session != null)
            {
                var checkSessionRes = CheckSession(session);
                if (!checkSessionRes.Success)
                {
                    return new RequestResult<JobSummary>().FillFromRequestResult(checkSessionRes);
                }
                userId = session.User.Id;
            }

            JobSummary summary = null;
            if (userId != null)
            {
                summary = vacancy.Summaries.FirstOrDefault(o => o.CreatedById == userId);
            }
            else
            {
                summary = vacancy.Summaries.FirstOrDefault(o => o.CreatedByFingerprint == fingerprint);
            }
            return RequestResult<JobSummary>.AsSuccess(summary);
        }
        private async Task<RequestResult> PrepareSummaryBeforeCreate(JobSummary summary)
        {
            var cvFile = Request.Form.Files.FirstOrDefault(o => o.Name == "cvFile");
            if (cvFile != null)
            {
                var uploadResult = await TryUploadFile(cvFile, Enums.FileType.Document);
                if (!uploadResult.Success)
                {
                    return uploadResult;
                }
                summary.CVPath = uploadResult.Value;
            }
            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> PrepareSummaryBeforeUpdate(JobSummary summary, JobSummaryDTO model)
        {
            var cvFile = Request.Form.Files.FirstOrDefault(o => o.Name == "cvFile");
            if (cvFile != null)
            {
                var uploadResult = await TryUploadFile(cvFile, Enums.FileType.Document);
                if (!uploadResult.Success)
                {
                    return uploadResult;
                }
                summary.CVPath = uploadResult.Value;
            }
            return RequestResult.AsSuccess();
        }

        #endregion
    }
}
