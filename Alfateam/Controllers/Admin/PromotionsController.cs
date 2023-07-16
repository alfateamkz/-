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
                .Include(o => o.Localizations)
                .Include(o => o.Descriptions).ThenInclude(o => o.Localizations)
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
                                .Include(o => o.Localizations)
                                .Include(o => o.Descriptions).ThenInclude(o => o.Localizations)
                                .FirstOrDefault(o => o.Id == id),
                Languages = DB.Languages.ToList()
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


        #endregion

        [HttpGet, Route("Admin/DeletePromotion")]
        public IActionResult DeletePromotion(int id)
        {
            var promotion = DB.Promotions
                .Include(o => o.Localizations)
                .FirstOrDefault(o => o.Id == id);


            DB.PromotionDescriptionItems.RemoveRange(promotion.Descriptions);


            DB.Promotions.Remove(promotion);
            DB.SaveChanges();
            return RedirectToAction("Promotions", "Promotions");
        }


    }
}
