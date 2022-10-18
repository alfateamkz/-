using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.Portfolios;
using Alfateam.Helpers;
using Alfateam.Models;
using Alfateam.ViewModels;
using Alfateam.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Alfateam.Controllers
{
    public class HomeController : AbsController
    {
        public HomeController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }


        [Route("ToGayClub")]
        public IActionResult Login()
        {          
            return View(@"Views\Profile\Login.cshtml");
        }
        [Route("/")]
        public IActionResult Index()
        {
            var vm = new IndexVM
            {
                GeneralTexts = DBHelper.GetGeneralTexts(),
                LandingTexts = DBHelper.GetLangingTexts(),
                News = DB.Posts
                        .Include(o => o.Captions).ThenInclude(o => o.Language)
                        .Include(o => o.Contents).ThenInclude(o => o.Language)
                        .ToList(),
                Portfolios = DB.Portfolios
                                .Include(o => o.Images)
                                .ToList()
            };
            vm.Portfolios.Reverse();
            vm.News.Reverse();
            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromForm]IndexVM vm)
        {
            DB.Orders.Add(vm.NewOrder);
            DB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

     


        [Route("News")]
        public IActionResult News(int page=1)
        {
            int skipped = (page - 1) * 8;

            int pagesCount = (int)Math.Ceiling((double)DB.Posts.Count() / (double)8);

            var allPosts = DB.Posts
                .Include(o => o.Captions).ThenInclude(o => o.Language)
                .Include(o => o.Contents).ThenInclude(o => o.Language)
                .ToList();
            allPosts.Reverse();


            var vm = new NewsVM
            {
                Posts =  allPosts.Skip(skipped)
                                 .Take(8)
                                 .ToList(),
                CurrentPage = page,
                PagesCount = pagesCount
            };
            return View(vm);
        }
        [Route("NewsPage")]
        public IActionResult NewsPage(int id)
        {
            var post = DB.Posts
                .Include(o => o.Captions).ThenInclude(o => o.Language)
                .Include(o => o.Contents).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == id);

            post.Watches++;
            DB.Posts.Update(post);
            DB.SaveChanges();
            return View(post);
        }



        [Route("Portfolios")]
        public IActionResult Portfolios(int page = 1,int categoryId = 0)
        {
            int skipped = (page - 1) * 9;

            int pagesCount = (int)Math.Ceiling((double)DB.Portfolios.Count() / (double)9);

            var allPortfolios = DB.Portfolios
                    .Include(o => o.Images)
                    .Include(o => o.Captions).ThenInclude(o => o.Language)
                    .Include(o => o.Descriptions).ThenInclude(o => o.Language).ToList();
            allPortfolios.Reverse();

            var vm = new PortfoliosVM
            {
                Portfolios = allPortfolios.Skip(skipped)
                                          .Take(9)
                                          .ToList(),

                PortfolioCategories = DB.PortfolioCategories
                     .Include(o => o.Captions).ThenInclude(o => o.Language)
                     .ToList(),

                CurrentPage = page,
                PagesCount = pagesCount,
                CategoryId = categoryId
            };

          

            if(categoryId != 0)
            {
                var filteredPortfolios = allPortfolios.Where(o => o.CategoryId == categoryId);


                vm.Portfolios =  filteredPortfolios.Skip(skipped)
                                                   .Take(9)
                                                   .ToList();
                vm.SelectedCategory = DB.PortfolioCategories
                                        .Include(o => o.Captions).ThenInclude(o => o.Language)
                                        .FirstOrDefault(o => o.Id == categoryId);

                vm.PagesCount = (int)Math.Ceiling((double)filteredPortfolios.Count() / (double)9);
            }

            return View(vm);
        }

        [Route("GetPortfolioJSON")]
        public IActionResult GetPortfolioJSON(int id,string langCode)
        {
            var portfolio = DB.Portfolios
                    .Include(o => o.Images)
                    .Include(o => o.Captions).ThenInclude(o => o.Language)
                    .Include(o => o.Descriptions).ThenInclude(o => o.Language)
                    .FirstOrDefault(o => o.Id == id);
            var portfilioJson = new PortfolioJson()
            {
                Id = portfolio.Id,
                Images = portfolio.Images,
                CreatedAt = portfolio.CreatedAt,
                Description = LocalizationHelper.GetLocalizedString(portfolio.Descriptions, langCode),
                Caption = LocalizationHelper.GetLocalizedString(portfolio.Captions, langCode)
            };

            return new JsonResult(portfilioJson);
        }





        [Route("Partners")]
        public IActionResult Partners()
        {
            var vm = new PartnersVM()
            {
                Partners = DB.Partners
                .Include(o => o.Titles).ThenInclude(o => o.Language)
                .Include(o => o.Descriptions).ThenInclude(o => o.Language)
                .ToList()

            };
            return View(vm);
        }
        [Route("Services")]
        public IActionResult Services()
        {
            var vm = new ServicesVM()
            {
                Promotions = DB.Promotions
                .Include(o => o.Captions).ThenInclude(o => o.Language)
                .Include(o => o.Prices).ThenInclude(o => o.Language)
                .Include(o => o.Descriptions).ThenInclude(o => o.Texts).ThenInclude(o => o.Language)
                .ToList()
            };
            return View(vm);
        }
        [Route("Team")]
        public IActionResult Team()
        {
            var vm = new TeamVM()
            {
                Teammates = DB.Teammates
                    .Include(o => o.Titles).ThenInclude(o => o.Language)
                    .Include(o => o.MiddleDescriptions).ThenInclude(o => o.Language)
                    .Include(o => o.Positions).ThenInclude(o => o.Language)
                    .ToList()
            };
            return View(vm);
        }



        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}