using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.Portfolios;
using Alfateam.Helpers;
using Alfateam.Models;
using Alfateam.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class PortfoliosController : AbsController
    {
        public PortfoliosController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Admin/Portfolios")]
        public IActionResult Portfolios()
        {
            var portfolios = DB.Portfolios
                .Include(o => o.Category).ThenInclude(o => o.Localizations)
                .Include(o => o.Localizations)
                .ToList();
            return View(@"Views\Admin\Portfolio\Portfolios.cshtml", portfolios);
        }


        #region Добавление нового портфолио
        [HttpGet, Route("Admin/CreatePortfolio")]
        public IActionResult CreatePortfolio()
        {
            var vm = new PortfoliosVM
            {
                PortfolioCategories = DB.PortfolioCategories
                                    .Include(o => o.Localizations)
                                    .ToList()
            };
            return View(@"Views\Admin\Portfolio\CreatePortfolio.cshtml", vm);
        }
        [HttpPost, Route("Admin/CreatePortfolioPOST")]
        public async Task<IActionResult> CreatePortfolioPOST(PortfoliosVM vm)
        {
            foreach(var formFile in Request.Form.Files)
                vm.NewPortfolio.Images.Add(new PortfolioImage { });

            for (int i=0;i< vm.NewPortfolio.Images.Count; i++)
            {
                vm.NewPortfolio.Images[i].ImgPath = await SetAttachmentIfHas(vm.NewPortfolio.Images[i].ImgPath,i);
            }
           

            DB.Portfolios.Add(vm.NewPortfolio);
            DB.SaveChanges();
            return RedirectToAction("Portfolios", "Portfolios");
        }
        #endregion

        #region Редактирование портфолио
        [HttpGet, Route("Admin/UpdatePortfolio")]
        public IActionResult UpdatePortfolio(int id)
        {
            var vm = new PortfoliosVM
            {
                PortfolioCategories = DB.PortfolioCategories
                                    .Include(o => o.Localizations)
                                    .ToList(),
                NewPortfolio = DB.Portfolios
                                    .Include(o => o.Localizations)
                                    .Include(o => o.Category).ThenInclude(o => o.Localizations)
                                    .Include(o => o.Images)
                                    .FirstOrDefault(o => o.Id == id),
                Languages = GetOtherLanguages()
            };
            return View(@"Views\Admin\Portfolio\UpdatePortfolio.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdatePortfolioPOST")]
        public async Task<IActionResult> UpdatePortfolioPOST(PortfoliosVM vm)
        {
            if(Request.Form.Files.Where(o => o.Length > 0).Count() > 0)
            {

                var oldPhotos = DB.Portfolios
                    .Include(o => o.Images)
                    .FirstOrDefault(o => o.Id == vm.NewPortfolio.Id)
                    .Images;
                DB.PortfolioImages.RemoveRange(oldPhotos);
                DB.SaveChanges();

                DB.ChangeTracker.Clear();


                var files = Request.Form.Files.Where(o => o.Length > 0).ToList();
                for(int i = 0; i < files.Count; i++)
                {
                    vm.NewPortfolio.Images.Add(new PortfolioImage
                    {
                        ImgPath = await SetAttachmentIfHas("", files[i])
                    });
                }
            }

            if(vm.NewPortfolio.URL is null)
            {
                vm.NewPortfolio.URL = "";
            }

            DB.Portfolios.Update(vm.NewPortfolio);
            DB.SaveChanges();

            return RedirectToAction("Portfolios", "Portfolios");
        }





        #endregion



        [HttpGet, Route("Admin/TogglePortfilioVisibility")]
        public IActionResult TogglePortfilioVisibility(int id)
        {
            var portfolio = DB.Portfolios
                .Include(o => o.Localizations)
                .FirstOrDefault(o => o.Id == id);

            portfolio.IsHidden = !portfolio.IsHidden;


            DB.Portfolios.Update(portfolio);
            DB.SaveChanges();
            return RedirectToAction("Portfolios", "Portfolios");
        }


        [HttpGet, Route("Admin/DeletePortfolio")]
        public IActionResult DeletePortfolio(int id)
        {
            var portfolio = DB.Portfolios
                .Include(o => o.Localizations)
                .FirstOrDefault(o => o.Id == id);

            DB.Portfolios.Remove(portfolio);
            DB.SaveChanges();
            return RedirectToAction("Portfolios", "Portfolios");
        }
    }
}
