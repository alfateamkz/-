using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Portfolios;
using Alfateam.Website.API.Models.Core;
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
        public async Task<IEnumerable<PortfolioClientModel>> GetPortfolios(int offset,int count = 20)
        {
            var items = GetPortfoliosList().Skip(offset).Take(count).ToList();
            return PortfolioClientModel.CreateItems(items, LanguageId);
        }

        [HttpGet, Route("GetPortfoliosByFilter")]
        public async Task<IEnumerable<PortfolioClientModel>> GetPortfoliosByFilter(int categoryId, int industryId, int offset, int count = 20)
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
            return PortfolioClientModel.CreateItems(portfolios.ToList(), LanguageId);
        }


        [HttpGet, Route("GetPortfolio")]
        public async Task<PortfolioClientModel> GetPortfolio(int id)
        {
            var portfolio = GetFullIncludedPortfoliosList().FirstOrDefault(o => o.Id == id);
            return PortfolioClientModel.Create(portfolio,LanguageId);
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
        public async Task<IEnumerable<PortfolioCategoryClientModel>> GetPortfolioCategories()
        {
            var items = DB.PortfolioCategories.IncludeAvailability()
                                              .Include(o => o.Localizations)
                                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                              .ToList();
            return PortfolioCategoryClientModel.CreateItems(items, LanguageId);
        }
        [HttpGet, Route("GetPortfolioIndustries")]
        public async Task<IEnumerable<PortfolioIndustryClientModel>> GetPortfolioIndustries()
        {
            var items = DB.PortfolioIndustries.IncludeAvailability()
                                              .Include(o => o.Localizations)
                                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                              .ToList();
            return PortfolioIndustryClientModel.CreateItems(items, LanguageId);
        }
        #endregion


        #region Private methods
        public IQueryable<Portfolio> GetPortfoliosList()
        {
            return DB.Portfolios.IncludeAvailability()
                                .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                                .Include(o => o.Category).ThenInclude(o => o.Localizations)
                                .Include(o => o.Localizations)
                                .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        public IQueryable<Portfolio> GetFullIncludedPortfoliosList()
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
