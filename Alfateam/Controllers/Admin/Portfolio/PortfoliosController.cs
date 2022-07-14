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
                .Include(o => o.Category).ThenInclude(o => o.Captions).ThenInclude(o => o.Language)
                .Include(o => o.Captions).ThenInclude(o => o.Language)
                .Include(o => o.Descriptions).ThenInclude(o => o.Language)
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
                                    .Include(o => o.Captions).ThenInclude(o => o.Language)
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
                                    .Include(o => o.Captions).ThenInclude(o => o.Language)
                                    .ToList(),
                NewPortfolio = DB.Portfolios
                                    .Include(o => o.Captions).ThenInclude(o => o.Language)
                                    .Include(o => o.Descriptions).ThenInclude(o => o.Language)
                                    .Include(o => o.Category).ThenInclude(o => o.Captions).ThenInclude(o => o.Language)
                                    .Include(o => o.Images)
                                    .FirstOrDefault(o => o.Id == id),
                Languages = GetOtherLanguages()
            };
            return View(@"Views\Admin\Portfolio\UpdatePortfolio.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdatePortfolioPOST")]
        public async Task<IActionResult> UpdatePortfolioPOST(PortfoliosVM vm)
        {
            if(Request.Form.Files.Count > 0)
            {
                var oldPhotos = DB.Portfolios
                    .Include(o => o.Images)
                    .FirstOrDefault(o => o.Id == vm.NewPortfolio.Id)
                    .Images;
                DB.PortfolioImages.RemoveRange(oldPhotos);

                foreach (var formFile in Request.Form.Files)
                    vm.NewPortfolio.Images.Add(new PortfolioImage { });

                for (int i = 0; i < vm.NewPortfolio.Images.Count; i++)
                {
                    vm.NewPortfolio.Images[i].ImgPath = await SetAttachmentIfHas(vm.NewPortfolio.Images[i].ImgPath, i);
                }
            }

            DB.Portfolios.Update(vm.NewPortfolio);
            DB.SaveChanges();

            return RedirectToAction("Portfolios", "Portfolios");
        }


        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpPost, Route("SetPortfolioCaptionTranslations")]
        public async Task SetPortfolioCaptionTranslations([FromBody] IdsModel ids)
        {
            var obj = DB.Portfolios.Include(o => o.Captions).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach (var translation in obj.Captions.Where(o => o.Language.Code != "RU").ToList())
            {
                obj.Captions.Remove(translation);
            }

            foreach (var id in ids.Ids)
            {
                var translation = DB.TranslationItems.FirstOrDefault(o => o.Id == id);
                obj.Captions.Add(translation);
            }
            DB.SaveChanges();
        }
        [HttpPost, Route("SetPortfolioDescriptionTranslations")]
        public async Task SetPortfolioDescriptionTranslations([FromBody] IdsModel ids)
        {
            var obj = DB.Portfolios.Include(o => o.Descriptions).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach (var translation in obj.Descriptions.Where(o => o.Language.Code != "RU").ToList())
            {
                obj.Descriptions.Remove(translation);
            }

            foreach (var id in ids.Ids)
            {
                var translation = DB.TranslationItems.FirstOrDefault(o => o.Id == id);
                obj.Descriptions.Add(translation);
            }
            DB.SaveChanges();
        }
        #endregion


        #endregion

        [HttpGet, Route("Admin/DeletePortfolio")]
        public IActionResult DeletePortfolio(int id)
        {
            var portfolio = DB.Portfolios
                .Include(o => o.Captions)
                .Include(o => o.Descriptions)
                .FirstOrDefault(o => o.Id == id);

            DB.TranslationItems.RemoveRange(portfolio.Captions);
            DB.TranslationItems.RemoveRange(portfolio.Descriptions);

            DB.Portfolios.Remove(portfolio);
            DB.SaveChanges();
            return RedirectToAction("Portfolios", "Portfolios");
        }
    }
}
