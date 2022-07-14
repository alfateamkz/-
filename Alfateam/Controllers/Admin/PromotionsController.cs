using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.Promotions;
using Alfateam.Helpers;
using Alfateam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class PromotionsController : AbsController
    {
        public PromotionsController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Admin/Promotions")]
        public IActionResult Promotions()
        {
            var promotions = DB.Promotions
                .Include(o => o.Captions).ThenInclude(o => o.Language)
                .Include(o => o.Prices).ThenInclude(o => o.Language)
                .Include(o => o.Descriptions).ThenInclude(o => o.Texts).ThenInclude(o => o.Language)
                .ToList();
            return View(@"Views\Admin\Promotions\Promotions.cshtml", promotions);
        }


        #region Создание новой тарифной карточки
        [HttpGet, Route("Admin/CreatePromotion")]
        public IActionResult CreatePromotion()
        {
            return View(@"Views\Admin\Promotions\CreatePromotion.cshtml");
        }
        [HttpPost, Route("Admin/CreatePromotionPOST")]
        public async Task<IActionResult> CreatePromotionPOST(Promotion promotion)
        {
            promotion.RightImgPath = await SetAttachmentIfHas(promotion.RightImgPath);

            DB.Promotions.Add(promotion);
            DB.SaveChanges();
            return RedirectToAction("Promotions", "Promotions");
        }
        #endregion

        #region Редактирование тарифной карточки
        [HttpGet, Route("Admin/UpdatePromotion")]
        public IActionResult UpdatePromotion(int id)
        {
            var vm = new VMWithLanguages<Promotion>()
            {
                TargetType = DB.Promotions
                                .Include(o => o.Captions).ThenInclude(o => o.Language)
                                .Include(o => o.Prices).ThenInclude(o => o.Language)
                                .Include(o => o.Descriptions).ThenInclude(o => o.Texts).ThenInclude(o => o.Language)
                                .FirstOrDefault(o => o.Id == id),
                Languages = DBHelper.GetLanguages()
            };
            return View(@"Views\Admin\Promotions\UpdatePromotion.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdatePromotionPOST")]
        public async Task<IActionResult> UpdatePromotionPOST(VMWithLanguages<Promotion> vm)
        {
            vm.TargetType.RightImgPath = await SetAttachmentIfHas(vm.TargetType.RightImgPath);


            DB.Promotions.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("Promotions", "Promotions");
        }
        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpGet, Route("Admin/ClearPromotion")]
        public async Task ClearPromotion(int id)
        {
            try
            {
                var promotion = DB.Promotions
                              .Include(o => o.Captions).ThenInclude(o => o.Language)
                              .Include(o => o.Prices).ThenInclude(o => o.Language)
                              .Include(o => o.Descriptions).ThenInclude(o => o.Texts).ThenInclude(o => o.Language)
                              .FirstOrDefault(o => o.Id == id);


                DB.TranslationItems.RemoveRange(promotion.Captions);
                DB.TranslationItems.RemoveRange(promotion.Prices);
                DB.TranslationItems.RemoveRange(promotion.Descriptions.SelectMany(o => o.Texts));

                promotion.Descriptions.ForEach(o => o.Texts.Clear());
                DB.PromotionDescriptionItems.RemoveRange(promotion.Descriptions);


                promotion.Captions.Clear();
                promotion.Prices.Clear();
                promotion.Descriptions.Clear();

                DB.Promotions.Update(promotion);

                DB.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #endregion

        [HttpGet, Route("Admin/DeletePromotion")]
        public IActionResult DeletePromotion(int id)
        {
            var promotion = DB.Promotions
                .Include(o => o.Captions)
                .Include(o => o.Prices)
                .Include(o => o.Descriptions)
                .FirstOrDefault(o => o.Id == id);

            DB.TranslationItems.RemoveRange(promotion.Captions);
            DB.TranslationItems.RemoveRange(promotion.Prices);

            DB.PromotionDescriptionItems.RemoveRange(promotion.Descriptions);


            DB.Promotions.Remove(promotion);
            DB.SaveChanges();
            return RedirectToAction("Promotions", "Promotions");
        }


    }
}
