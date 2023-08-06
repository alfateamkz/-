using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.ClientModels.HR;
using Alfateam.Website.API.Models.Filters;
using Alfateam2._0.Models.HR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class HRController : AbsController
    {
        public HRController(WebsiteDBContext db) : base(db)
        {
        }

        [HttpGet, Route("GetJobVacancies")]
        public async Task<IEnumerable<JobVacancyCard>> GetJobVacancies(int offset, int count = 20)
        {
            var vacancies = DB.JobVacancies.Include(o => o.Expierence)
                                           .Include(o => o.Currency)
                                           .Include(o => o.WatchesList)
                                           .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                           .Skip(offset)
                                           .Take(count)
                                           .ToList();

            return MakeJobVacancyCards(vacancies);
        }


        [HttpGet, Route("GetJobVacanciesByFilter")]
        public async Task<IEnumerable<JobVacancyCard>> GetJobVacanciesByFilter(JobVacanciesFIlter filter)
        {
            var vacancies = DB.JobVacancies.Include(o => o.Expierence)
                                           .Include(o => o.Currency)
                                           .Include(o => o.WatchesList)
                                           .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));

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
            var vacancy = DB.JobVacancies.Include(o => o.Expierence)
                                         .Include(o => o.Currency)
                                         .Include(o => o.WatchesList)
                                         .Include(o => o.InnerContent).ThenInclude(o => o.Items)
                                         .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                         .FirstOrDefault(o => o.Id == id);

            return MakeJobVacancyCard(vacancy);
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
                Vacancy = JobVacancyClientModel.Create(vacancy,LanguageId),
                WatchingNow = watchingNow,
            };
        }
    }
}
