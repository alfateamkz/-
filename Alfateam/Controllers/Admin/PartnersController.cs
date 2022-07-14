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
    public class PartnersController : AbsController
    {
        public PartnersController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet, Route("Admin/Partners")]
        public IActionResult Partners()
        {
            var partners = DB.Partners
                .Include(o => o.Titles).ThenInclude(o => o.Language)
                .Include(o => o.Descriptions).ThenInclude(o => o.Language)
                .ToList();
            return View(@"Views\Admin\Partners\Partners.cshtml", partners);
        }


        #region Добавление нового партнера
        [HttpGet, Route("Admin/CreatePartner")]
        public IActionResult CreatePartner()
        {
            return View(@"Views\Admin\Partners\CreatePartner.cshtml");
        }
        [HttpPost, Route("Admin/CreatePartnerPOST")]
        public async Task<IActionResult> CreatePartnerPOST(Partner partner)
        {
            partner.ImgPath = await SetAttachmentIfHas(partner.ImgPath);

            DB.Partners.Add(partner);
            DB.SaveChanges();
            return RedirectToAction("Partners", "Partners");
        }
        #endregion

        #region Редактирование существующего партнера

        [HttpGet, Route("Admin/UpdatePartner")]
        public IActionResult UpdatePartner(int id)
        {
            var partner = DB.Partners
                .Include(o => o.Titles).ThenInclude(o => o.Language)
                .Include(o => o.Descriptions).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == id);
            var vm = new VMWithLanguages<Partner>()
            {
                TargetType = partner,
                Languages = GetOtherLanguages()
            };
            return View(@"Views\Admin\Partners\UpdatePartner.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdatePartnerPOST")]
        public async Task<IActionResult> UpdatePartnerPOST(VMWithLanguages<Partner> vm)
        {
            vm.TargetType.ImgPath = await SetAttachmentIfHas(vm.TargetType.ImgPath);

            DB.Partners.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("Partners", "Partners");
        }


        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpPost, Route("SetPartnerTitleTranslations")]
        public async Task SetPartnerTitleTranslations([FromBody] IdsModel ids)
        {
            Partner obj = DB.Partners.Include(o => o.Titles).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach(var translation in obj.Titles.Where(o => o.Language.Code != "RU").ToList())
            {
                obj.Titles.Remove(translation);
            }

            foreach (var id in ids.Ids)
            {
                var translation = DB.TranslationItems.FirstOrDefault(o => o.Id == id);
                obj.Titles.Add(translation);
            }
            DB.SaveChanges();
        }
        [HttpPost, Route("SetPartnerDescriptionTranslations")]
        public async Task SetPartnerDescriptionTranslations([FromBody] IdsModel ids)
        {
            Partner obj = DB.Partners.Include(o => o.Descriptions).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
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


        [HttpGet, Route("Admin/DeletePartner")]
        public IActionResult DeletePartner(int id)
        {
            var partner = DB.Partners
                .Include(o => o.Titles)
                .Include(o => o.Descriptions)
                .FirstOrDefault(o => o.Id == id);

            DB.TranslationItems.RemoveRange(partner.Titles);
            DB.TranslationItems.RemoveRange(partner.Descriptions);

            DB.Partners.Remove(partner);
            DB.SaveChanges();
            return RedirectToAction("Partners", "Partners");
        }
    }
}
