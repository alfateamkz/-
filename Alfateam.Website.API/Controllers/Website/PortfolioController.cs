using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam.Website.API.Models.Stats;
using Alfateam2._0.Models;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Portfolios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class PortfolioController : AbsController
    {
        public PortfolioController(WebsiteDBContext db) : base(db)
        {
        }

        #region Получение портфолио

        [HttpGet, Route("GetPortfolios")]
        public async Task<IEnumerable<PortfolioDTO>> GetPortfolios(int offset,int count = 20)
        {
            var items = GetPortfoliosList().Skip(offset).Take(count).ToList();
            return PortfolioDTO.CreateItemsWithLocalization(items, LanguageId) as IEnumerable<PortfolioDTO>;
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
            return PortfolioDTO.CreateItemsWithLocalization(portfolios.ToList(), LanguageId) as IEnumerable<PortfolioDTO>;
        }


        [HttpGet, Route("GetPortfolio")]
        public async Task<PortfolioDTO> GetPortfolio(int id)
        {
            var portfolio = GetFullIncludedPortfoliosList().FirstOrDefault(o => o.Id == id);
            return PortfolioDTO.CreateWithLocalization(portfolio,LanguageId) as PortfolioDTO;
        }

        #endregion

        #region Взаимодействие с портфолио

        [HttpPut, Route("AddWatch")]
        public async Task<RequestResult> AddWatch(int id,string fingerprint)
        {
            var res = new RequestResult();


            var portfolio = DB.Portfolios.FirstOrDefault(o => o.Id == id);
            if(portfolio != null)
            {
                int? userId = null;
                if (!string.IsNullOrEmpty(this.UserSessid))
                {
                    var session = DB.Sessions.Include(o => o.User)
                                             .FirstOrDefault(o => o.SessID == this.UserSessid);

                    var checkSessionRes = CheckSession(session);
                    if (!checkSessionRes.Success)
                    {
                        res.FillFromRequestResult(checkSessionRes);
                        return res;
                    }
                    userId = session.User.Id;
                }
               

                portfolio.Watches++;
                portfolio.WatchesList.Add(new Watch
                {
                    WatchedByFingerprint = fingerprint,
                    WatchedById = userId
                });

                DB.Portfolios.Update(portfolio);
                DB.SaveChanges();

                res.Success = true;
            }
            else
            {
                res.Code = 404;
                res.Error = "Портфолио по данному id не найдено";
            }

            return res;
        }

        [HttpPut, Route("ToggleLike")]
        public async Task<RequestResult<bool>> ToggleLike(int id, string fingerprint)
        {
            var res = new RequestResult<bool>();


            var portfolio = DB.Portfolios
                .Include(o => o.LikesList)
                .FirstOrDefault(o => o.Id == id);
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
                        res.FillFromRequestResult(checkSessionRes);
                        return res;
                    }
                    userId = session.User.Id;
                }




                RateVote foundLike;

                if (userId == null)
                {
                    foundLike = portfolio.LikesList.FirstOrDefault(o => o.SetByFingerprint == fingerprint);
                }
                else
                {
                    foundLike = portfolio.LikesList.FirstOrDefault(o => o.SetById == userId);
                }



                if(foundLike == null)
                {
                    portfolio.Likes++;
                    portfolio.LikesList.Add(new RateVote
                    {
                        SetByFingerprint = fingerprint,
                        SetById = userId
                    });
                }
                else
                {
                    portfolio.Likes--;
                    portfolio.LikesList.Remove(foundLike);
                }


                DB.Portfolios.Update(portfolio);
                DB.SaveChanges();


                //Если foundLike  == null, то лайк ставим, иначе убираем
                res.Value = foundLike == null;
                res.Success = true;
            }
            else
            {
                res.Code = 404;
                res.Error = "По данному id кейс не найден";
            }
           
            return res;
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
            return PortfolioCategoryDTO.CreateItemsWithLocalization(items, LanguageId) as IEnumerable<PortfolioCategoryDTO>;
        }
        [HttpGet, Route("GetPortfolioIndustries")]
        public async Task<IEnumerable<PortfolioIndustryDTO>> GetPortfolioIndustries()
        {
            var items = DB.PortfolioIndustries.IncludeAvailability()
                                              .Include(o => o.Localizations)
                                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                              .ToList();
            return PortfolioIndustryDTO.CreateItemsWithLocalization(items, LanguageId) as IEnumerable<PortfolioIndustryDTO>;
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



        #region Private methods
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
