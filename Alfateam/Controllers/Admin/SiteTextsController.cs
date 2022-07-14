using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.SitePagesTexts;
using Alfateam.Helpers;
using Alfateam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class SiteTextsController : AbsController
    {
        public SiteTextsController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        #region ErrorPages

        [HttpGet,Route("Admin/SiteTexts/ErrorPages")]
        public IActionResult ErrorPages()
        {
            var texts = DB.ErrorPages
                .Include(o => o.TextsNuhuyaTitle).ThenInclude(o => o.Language)
                .Include(o => o.TextsNuhuyaDescription).ThenInclude(o => o.Language)
                .Include(o => o.Texts403).ThenInclude(o => o.Language)
                .Include(o => o.Texts404).ThenInclude(o => o.Language)
                .FirstOrDefault();

            var vm = new VMWithLanguages<ErrorPages>
            {
                Languages = DBHelper.GetLanguages(),
                TargetType = texts
            };
            return View(@"Views\Admin\SiteTexts\ErrorPages.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdateErrorPages")]
        public async Task<IActionResult> UpdateErrorPages(VMWithLanguages<ErrorPages> vm)
        {
            DB.ErrorPages.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("ErrorPages", "SiteTexts");
        }
        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpGet, Route("Admin/ClearErrorPages")]
        public async Task ClearErrorPages(int id)
        {
            try
            { 
                var texts = DB.ErrorPages
                    .Include(o => o.TextsNuhuyaTitle).ThenInclude(o => o.Language)
                    .Include(o => o.TextsNuhuyaDescription).ThenInclude(o => o.Language)
                    .Include(o => o.Texts403).ThenInclude(o => o.Language)
                    .Include(o => o.Texts404).ThenInclude(o => o.Language)
                    .FirstOrDefault();

                DB.TranslationItems.RemoveRange(texts.TextsNuhuyaTitle);
                DB.TranslationItems.RemoveRange(texts.TextsNuhuyaDescription);
                DB.TranslationItems.RemoveRange(texts.Texts403);
                DB.TranslationItems.RemoveRange(texts.Texts404);

                texts.TextsNuhuyaTitle.Clear();
                texts.TextsNuhuyaDescription.Clear();
                texts.Texts403.Clear();
                texts.Texts404.Clear();

                DB.ErrorPages.Update(texts);

                DB.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #endregion

        #region GeneralTexts
        [HttpGet, Route("Admin/SiteTexts/GeneralTexts")]
        public IActionResult GeneralTexts()
        {
            var texts = DBHelper.GetGeneralTexts();
            var vm = new VMWithLanguages<GeneralTexts>
            {
                Languages = DBHelper.GetLanguages(),
                TargetType = texts
            };
            return View(@"Views\Admin\SiteTexts\GeneralTexts.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdateGeneralTexts")]
        public async Task<IActionResult> UpdateGeneralTexts(VMWithLanguages<GeneralTexts> vm)
        {
            DB.GeneralTexts.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("GeneralTexts", "SiteTexts");
        }

        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpGet, Route("Admin/ClearGeneralTexts")]
        public async Task ClearGeneralTexts(int id)
        {
            try
            {
                var texts = DBHelper.GetGeneralTexts();

                DB.TranslationItems.RemoveRange(texts.Main);
                DB.TranslationItems.RemoveRange(texts.ServicesPrice);
                DB.TranslationItems.RemoveRange(texts.OurWorks);
                DB.TranslationItems.RemoveRange(texts.Partners);
                DB.TranslationItems.RemoveRange(texts.Team);

                DB.TranslationItems.RemoveRange(texts.Navigation);
                DB.TranslationItems.RemoveRange(texts.Contacts);

                DB.TranslationItems.RemoveRange(texts.SocialNetworks);
                DB.TranslationItems.RemoveRange(texts.AllRightsReserved);

                DB.TranslationItems.RemoveRange(texts.PublishedAt);
                DB.TranslationItems.RemoveRange(texts.NewPortfolioLabel);
                DB.TranslationItems.RemoveRange(texts.Close);
                DB.TranslationItems.RemoveRange(texts.Categories);
                DB.TranslationItems.RemoveRange(texts.AddedAt);
                DB.TranslationItems.RemoveRange(texts.Watches);
                DB.TranslationItems.RemoveRange(texts.AllPortfolios);
                DB.TranslationItems.RemoveRange(texts.News);

                texts.Main.Clear();
                texts.ServicesPrice.Clear();
                texts.OurWorks.Clear();
                texts.Partners.Clear();
                texts.Team.Clear();

                texts.Navigation.Clear();
                texts.Contacts.Clear();

                texts.SocialNetworks.Clear();
                texts.AllRightsReserved.Clear();

                texts.PublishedAt.Clear();
                texts.NewPortfolioLabel.Clear();
                texts.Close.Clear();
                texts.Categories.Clear();
                texts.AddedAt.Clear();
                texts.Watches.Clear();
                texts.AllPortfolios.Clear();
                texts.News.Clear();

                DB.GeneralTexts.Update(texts);

                DB.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #endregion

        #region LandingTexts

        [HttpGet, Route("Admin/SiteTexts/LandingTexts")]
        public IActionResult LandingTexts()
        {
            var texts = DBHelper.GetLangingTexts();
            var vm = new VMWithLanguages<LandingTexts>
            {
                Languages = DBHelper.GetLanguages(),
                TargetType = texts
            };
            return View(@"Views\Admin\SiteTexts\LandingTexts.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdateLandingTexts")]
        public async Task<IActionResult> UpdateLandingTexts(VMWithLanguages<LandingTexts> vm)
        {
            DB.LandingTexts.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("LandingTexts", "SiteTexts");
        }
        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpGet, Route("Admin/ClearLandingTexts")]
        public async Task ClearLandingTexts(int id)
        {
            try
            {
                var texts = DBHelper.GetLangingTexts();

                DB.TranslationItems.RemoveRange(texts.StartBusiness);
                DB.TranslationItems.RemoveRange(texts.StartBusinessDescriptions);
                DB.TranslationItems.RemoveRange(texts.OrderNow);

                DB.TranslationItems.RemoveRange(texts.WeAcceptPayments);

                DB.TranslationItems.RemoveRange(texts.OurPortfolios);
                DB.TranslationItems.RemoveRange(texts.OurLastPortfolios);
                DB.TranslationItems.RemoveRange(texts.MorePortfolios);

                DB.TranslationItems.RemoveRange(texts.News);
                DB.TranslationItems.RemoveRange(texts.DiscoverNews);
                DB.TranslationItems.RemoveRange(texts.NewsDetails);
                DB.TranslationItems.RemoveRange(texts.NewsMore);

                DB.TranslationItems.RemoveRange(texts.Order);
                DB.TranslationItems.RemoveRange(texts.MakeOrder);
                DB.TranslationItems.RemoveRange(texts.YourName);
                DB.TranslationItems.RemoveRange(texts.CompanyName);
                DB.TranslationItems.RemoveRange(texts.DescribeJob);
                DB.TranslationItems.RemoveRange(texts.DescribeJobPlaceholder);
                DB.TranslationItems.RemoveRange(texts.YourBudget);
                DB.TranslationItems.RemoveRange(texts.Contacts);
                DB.TranslationItems.RemoveRange(texts.ContactsPlaceholder);
                DB.TranslationItems.RemoveRange(texts.Send);

                DB.TranslationItems.RemoveRange(texts.OrderCompleted);


                texts.StartBusiness.Clear();
                texts.StartBusinessDescriptions.Clear();
                texts.OrderNow.Clear();

                texts.WeAcceptPayments.Clear();

                texts.OurPortfolios.Clear();
                texts.OurLastPortfolios.Clear();
                texts.MorePortfolios.Clear();

                texts.News.Clear();
                texts.DiscoverNews.Clear();
                texts.NewsDetails.Clear();
                texts.NewsMore.Clear();

                texts.Order.Clear();
                texts.MakeOrder.Clear();
                texts.YourName.Clear();
                texts.CompanyName.Clear();
                texts.DescribeJobPlaceholder.Clear();
                texts.MakeOrder.Clear();
                texts.YourBudget.Clear();
                texts.Contacts.Clear();
                texts.ContactsPlaceholder.Clear();
                texts.Send.Clear();

                texts.OrderCompleted.Clear();

                DB.LandingTexts.Update(texts);

                DB.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #endregion
    }
}
