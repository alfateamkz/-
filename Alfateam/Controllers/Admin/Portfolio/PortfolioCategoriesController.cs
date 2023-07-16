using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Models;
using Alfateam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class PortfolioCategoriesController : AbsController
    {
        public PortfolioCategoriesController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Admin/Portfolio/Categories")]
        public IActionResult Categories()
        {
            var categories = DB.PortfolioCategories
                .Include(o => o.Localizations)
                .ToList();
            return View(@"Views\Admin\Portfolio\Categories\Categories.cshtml", categories);
        }


        #region Добавление новой категории портфолио
        [HttpGet, Route("Admin/CreateCategory")]
        public IActionResult CreateCategory()
        {
            return View(@"Views\Admin\Portfolio\Categories\CreateCategory.cshtml");
        }
        [HttpPost, Route("Admin/CreateCategoryPOST")]
        public async Task<IActionResult> CreateCategoryPOST(PortfolioCategory category)
        {
            DB.PortfolioCategories.Add(category);
            DB.SaveChanges();
            return RedirectToAction("Categories", "PortfolioCategories");
        }
        #endregion

        #region Редактирование категории портфолио
        [HttpGet, Route("Admin/UpdateCategory")]
        public IActionResult UpdateCategory(int id)
        {
            var cat = DB.PortfolioCategories
                .Include(o => o.Localizations)
                .FirstOrDefault(o => o.Id == id);
            var vm = new VMWithLanguages<PortfolioCategory>()
            {
                TargetType = cat,
                Languages = GetOtherLanguages()
            };
            return View(@"Views\Admin\Portfolio\Categories\UpdateCategory.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdateCategoryPOST")]
        public async Task<IActionResult> UpdateCategoryPOST(VMWithLanguages<PortfolioCategory> vm)
        {
            DB.PortfolioCategories.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("Categories", "PortfolioCategories");
        }

        #endregion

        [HttpGet, Route("Admin/DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            var cat = DB.PortfolioCategories
                .Include(o => o.Localizations)
                .FirstOrDefault(o => o.Id == id);

            DB.PortfolioCategories.Remove(cat);
            DB.SaveChanges();

            return RedirectToAction("Categories", "PortfolioCategories");
        }
    }
}
