using Alfateam.CRM2_0.Models.General;
using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam.Website.API.Models.Stats;
using Alfateam2._0.Models;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Portfolios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.Website.API.Controllers.Website
{
    public class PortfolioController : AbsController
    {
        public PortfolioController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение портфолио

        [HttpGet, Route("GetPortfolios")]
        public async Task<IEnumerable<PortfolioDTO>> GetPortfolios(int offset,int count = 20)
        {
            var items = GetPortfoliosList().Skip(offset).Take(count).ToList();
            return new PortfolioDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<PortfolioDTO>();
        }

        [HttpGet, Route("GetPortfoliosByFilter")]
        public async Task<IEnumerable<PortfolioDTO>> GetPortfoliosByFilter(int categoryId, int industryId, int offset, int count = 20)
        {
            var portfolios = GetPortfoliosList();
            if(categoryId > 0)
            {
                portfolios = portfolios.Where(o => o.CategoryId == categoryId);
            }
            if (industryId > 0)
            {
                portfolios = portfolios.Where(o => o.IndustryId == industryId);
            }

            portfolios = portfolios.Skip(offset).Take(count);
            return new PortfolioDTO().CreateDTOsWithLocalization(portfolios.ToList(), LanguageId).Cast<PortfolioDTO>();
        }


        [HttpGet, Route("GetPortfolio")]
        public async Task<PortfolioDTO> GetPortfolio(int id)
        {
            var portfolio = GetFullIncludedPortfoliosList().FirstOrDefault(o => o.Id == id);
            return (PortfolioDTO)new PortfolioDTO().CreateDTOWithLocalization(portfolio,LanguageId);
        }

        #endregion

        #region Взаимодействие с портфолио

        [HttpPut, Route("AddWatch")]
        public async Task AddWatch(int portfolioId,string fingerprint)
        {
            var portfolio = DB.Portfolios.FirstOrDefault(o => o.Id == portfolioId);
            if(portfolio == null)
            {
                throw new Exception404("Портфолио по данному id не найдено");
            }

            portfolio.Watches++;
            portfolio.WatchesList.Add(new Watch
            {
                WatchedByFingerprint = fingerprint,
                WatchedById = this.GetUserIdIfSessionValid()
            });

            DbService.UpdateEntity(DB.Portfolios, portfolio);
        }

        [HttpGet, Route("HasLike")]
        public async Task<bool> HasLike(int portfolioId, string fingerprint)
        {
            var portfolio = DB.Portfolios.Include(o => o.LikesList)
                                        .FirstOrDefault(o => o.Id == portfolioId);
            if (portfolio == null)
            {
                throw new Exception404("Портфолио по данному id не найдено");
            }

            return GetLike(portfolio, fingerprint) != null;
        }

        [HttpPut, Route("ToggleLike")]
        public async Task<bool> ToggleLike(int portfolioId, string fingerprint)
        {
            var portfolio = DB.Portfolios.Include(o => o.LikesList)
                                         .FirstOrDefault(o => o.Id == portfolioId);
            if (portfolio == null)
            {
                throw new Exception404("Портфолио по данному id не найдено");      
            }


            RateVote foundLike = GetLike(portfolio, fingerprint);
            if (foundLike == null)
            {
                portfolio.Likes++;
                portfolio.LikesList.Add(new RateVote
                {
                    SetByFingerprint = fingerprint,
                    SetById = GetUserIdIfSessionValid()
                });
            }
            else
            {
                portfolio.Likes--;
                portfolio.LikesList.Remove(foundLike);
            }


            DbService.UpdateEntity(DB.Portfolios, portfolio);
            return foundLike == null; //если лайка нет, то добавляем и он есть
        }
        #endregion

        #region Получение категорий и индустрии

        [HttpGet, Route("GetPortfolioCategories")]
        public async Task<IEnumerable<PortfolioCategoryDTO>> GetPortfolioCategories()
        {
            var items = DB.PortfolioCategories.IncludeAvailability()
                                              .Include(o => o.Localizations)
                                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                              .ToList();
            return new PortfolioCategoryDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<PortfolioCategoryDTO>();
        }
        [HttpGet, Route("GetPortfolioIndustries")]
        public async Task<IEnumerable<PortfolioIndustryDTO>> GetPortfolioIndustries()
        {
            var items = DB.PortfolioIndustries.IncludeAvailability()
                                              .Include(o => o.Localizations)
                                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                              .ToList();
            return new PortfolioIndustryDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<PortfolioIndustryDTO>();
        }
        #endregion

        #region Получение статистики портфолио

        [HttpGet, Route("GetPortfolioStats")]
        public async Task<IEnumerable<PortfolioStatsCategoryGrouping>> GetPortfolioStats(int year, int month)
        {
            var categoryStats = new List<PortfolioStatsCategoryGrouping>();


            var itemsByCategories = DB.Portfolios.IncludeAvailability()
                                                 .Include(o => o.WatchesList)
                                                 .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                                 .GroupBy(o => o.CategoryId);
  
            foreach(var byCategory in itemsByCategories)
            {
                var items = byCategory.ToList();
                var totalWatches = items.SelectMany(o => o.WatchesList);
                DateTime dateStart = new DateTime(year, month, 1);


                var categoryModel = new PortfolioStatsCategoryGrouping()
                {
                    Category = (await GetPortfolioCategories()).FirstOrDefault(o => o.Id == byCategory.Key)
                };

                while (dateStart.Month == month)
                {
                    int watchesCount = totalWatches.Count(o => o.CreatedAt.Date == dateStart);

                    categoryModel.Days.Add(new PortfolioStatsCategoryGroupingDay
                    {
                        Date = dateStart,
                        WatchesCount = watchesCount
                    });

                    dateStart = dateStart.AddDays(1);
                }

                categoryStats.Add(categoryModel);
            }


            return categoryStats;
        }


        #endregion







        #region Private other methods
        private RateVote GetLike(Portfolio portfolio, string fingerprint)
        {
            int? userId = GetUserIdIfSessionValid();
            if (userId == null)
            {
                return portfolio.LikesList.FirstOrDefault(o => o.SetByFingerprint == fingerprint);
            }
            else
            {
                return portfolio.LikesList.FirstOrDefault(o => o.SetById == userId);
            }
        }

        #endregion

        #region Private get included methods
        private IQueryable<Portfolio> GetPortfoliosList()
        {
            return DB.Portfolios.IncludeAvailability()
                                .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                                .Include(o => o.Category).ThenInclude(o => o.Localizations)
                                .Include(o => o.Localizations)
                                .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        private IQueryable<Portfolio> GetFullIncludedPortfoliosList()
        {
            return DB.Portfolios.IncludeAvailability()
                                .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                                .Include(o => o.Category).ThenInclude(o => o.Localizations)
                                .Include(o => o.Localizations)
                                .Include(o => o.Content).ThenInclude(o => o.Items)
                                .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}
