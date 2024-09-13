using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
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
                News = DB.NewPosts
                        .Include(o => o.Language)
                        .Include(o => o.Headings)
                        .Include(o => o.Paragraphs)
                        .Include(o => o.Images)
                        .Where(o => o.LanguageId == GetCurrentLanguage().Id && !o.IsDeleted)
                        .ToList(),
                Partners = DB.Partners
                            .Include(o => o.Localizations)
                            .ToList(),
                Teammates = DB.Teammates
                            .Include(o => o.Localizations)
                            .ToList(),
                Portfolios = DB.Portfolios
                                .Include(o => o.Images)
                                .Where(o => !o.IsHidden)
                                .Take(6)
                                .ToList()
            };
            vm.Portfolios.Reverse();
            vm.News.Reverse();
            return View(vm);
        }

        

     


        //[Route("News")]
        //public IActionResult News(int page=1)
        //{
        //    int skipped = (page - 1) * 8;

        //    int pagesCount = (int)Math.Ceiling((double)DB.Posts.Count() / (double)8);

        //    var allPosts = DB.Posts
        //        .Include(o => o.Captions).ThenInclude(o => o.Language)
        //        .Include(o => o.Contents).ThenInclude(o => o.Language)
        //        .ToList();
        //    allPosts.Reverse();


        //    var vm = new NewsVM
        //    {
        //        Posts =  allPosts.Skip(skipped)
        //                         .Take(8)
        //                         .ToList(),
        //        CurrentPage = page,
        //        PagesCount = pagesCount
        //    };
        //    return View(vm);
        //}
        //[Route("NewsPage")]
        //public IActionResult NewsPage(int id)
        //{
        //    var post = DB.Posts
        //        .Include(o => o.Captions).ThenInclude(o => o.Language)
        //        .Include(o => o.Contents).ThenInclude(o => o.Language)
        //        .FirstOrDefault(o => o.Id == id);

        //    post.Watches++;
        //    DB.Posts.Update(post);
        //    DB.SaveChanges();
        //    return View(post);
        //}

        [Route("News")]
        public IActionResult News(int page = 1)
        {
            int skipped = (page - 1) * 8;

    

            var allPosts = DB.NewPosts
                .Include(o => o.Language)
                .Include(o => o.Headings)
                .Include(o => o.Images)
                .Include(o => o.Paragraphs)
                .Where(o => o.LanguageId == this.GetCurrentLanguage().Id && !o.IsDeleted)
                .ToList();
            allPosts.Reverse();

            int pagesCount = (int)Math.Ceiling((double)allPosts.Count() / (double)8);

            

            

            var vm = new NewsVM
            {
                Posts = allPosts.Skip(skipped)
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
            var post = DB.NewPosts
                .Include(o => o.Language)
                .Include(o => o.Headings)
                .Include(o => o.Images)
                .Include(o => o.Paragraphs)
                .Include(o => o.Videos)
                .Include(o => o.Sliders).ThenInclude(o => o.Images)
                .FirstOrDefault(o => o.Id == id);

            post.Watches++;
            DB.NewPosts.Update(post);
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
                    .Include(o => o.Localizations)
                    .Where(o => !o.IsHidden)
                    .ToList();
            allPortfolios.Reverse();

            var vm = new PortfoliosVM
            {
                Portfolios = allPortfolios.Skip(skipped)
                                          .Take(9)
                                          .ToList(),

                PortfolioCategories = DB.PortfolioCategories
                     .Include(o => o.Localizations)
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
                                        .Include(o => o.Localizations)
                                        .FirstOrDefault(o => o.Id == categoryId);

                vm.PagesCount = (int)Math.Ceiling((double)filteredPortfolios.Count() / (double)9);
            }

            return View(vm);
        }

        [Route("GetPortfolioJSON")]
        public IActionResult GetPortfolioJSON(int id,int langId)
        {
            var portfolio = DB.Portfolios
                    .Include(o => o.Images)
                    .Include(o => o.Localizations)
                    .FirstOrDefault(o => o.Id == id);
            var portfilioJson = new PortfolioJson()
            {
                Id = portfolio.Id,
                Images = portfolio.Images,
                CreatedAt = portfolio.CreatedAt,
                Description = portfolio.GetLocalizedDescription(langId),
                Caption = portfolio.GetLocalizedCaption(langId),
                URL = portfolio.URL
            };

            return new JsonResult(portfilioJson);
        }





        [Route("Partners")]
        public IActionResult Partners()
        {
            var vm = new PartnersVM()
            {
                Partners = DB.Partners
                                .Include(o => o.Localizations)
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
                                    .Include(o => o.Localizations)
                                    .Include(o => o.Descriptions).ThenInclude(o => o.Localizations)
                                    .ToList(),
            };
            return View(vm);
        }
        [Route("Team")]
        public IActionResult Team()
        {
            var vm = new TeamVM()
            {
                Teammates = DB.Teammates
                                .Include(o => o.Localizations)
                                .ToList()
            };
            return View(vm);
        }



        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Privacy_ru")]
        public IActionResult Privacy_ru()
        {
            return View();
        }
        [Route("Privacy_en")]
        public IActionResult Privacy_en()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #region Обратная связя

        [HttpPost]
        public IActionResult CreateOrder([FromForm] IndexVM vm)
        {
            DB.Orders.Add(vm.NewOrder);
            DB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult CreateCallRequest([FromForm] CallRequest req)
        {
            DB.CallRequests.Add(req);
            DB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        #endregion


        [Route("DownloadFile")]
        public IActionResult DownloadFile(string path)
        {

            byte[] fileBytes = System.IO.File.ReadAllBytes(AppEnvironment.WebRootPath + path);
            string fileName = Path.GetFileName(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}