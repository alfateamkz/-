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
    public class TeamController : AbsController
    {
        public TeamController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Admin/Team")]
        public IActionResult Team()
        {
            var teammates = DB.Teammates
                .Include(o => o.Titles).ThenInclude(o => o.Language)
                .Include(o => o.MiddleDescriptions).ThenInclude(o => o.Language)
                .Include(o => o.Positions).ThenInclude(o => o.Language)
                .ToList();
            return View(@"Views\Admin\Team\Team.cshtml", teammates);
        }


        #region Создание нового члена команды
        [HttpGet, Route("Admin/CreateTeammate")]
        public IActionResult CreateTeammate()
        {
            return View(@"Views\Admin\Team\CreateTeammate.cshtml");
        }
        [HttpPost, Route("Admin/CreateTeammatePOST")]
        public async Task<IActionResult> CreateTeammatePOST(Teammate teammate)
        {
            teammate.ImgPath = await SetAttachmentIfHas(teammate.ImgPath);

            DB.Teammates.Add(teammate);
            DB.SaveChanges();
            return RedirectToAction("Team", "Team");
        }
        #endregion

        #region Редактирование члена команды
        [HttpGet, Route("Admin/UpdateTeammate")]
        public IActionResult UpdateTeammate(int id)
        {
            var teammate = DB.Teammates
              .Include(o => o.Titles).ThenInclude(o => o.Language)
              .Include(o => o.MiddleDescriptions).ThenInclude(o => o.Language)
              .Include(o => o.Positions).ThenInclude(o => o.Language)
              .FirstOrDefault(o => o.Id == id);
            var vm = new VMWithLanguages<Teammate>()
            {
                TargetType = teammate,
                Languages = GetOtherLanguages()
            };
            return View(@"Views\Admin\Team\UpdateTeammate.cshtml", vm);
        }
        [HttpPost, Route("Admin/UpdateTeammatePOST")]
        public async Task<IActionResult> UpdateTeammatePOST(VMWithLanguages<Teammate> vm)
        {
            vm.TargetType.ImgPath = await SetAttachmentIfHas(vm.TargetType.ImgPath);

            DB.Teammates.Update(vm.TargetType);
            DB.SaveChanges();
            return RedirectToAction("Team", "Team");
        }

        #region Удаляем удаленные на фронте переводы и добавляем выбранные
        [HttpPost, Route("SetTeammateTitlesTranslations")]
        public async Task SetTeammateTitlesTranslations([FromBody] IdsModel ids)
        {
            var obj = DB.Teammates.Include(o => o.Titles).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach (var translation in obj.Titles.Where(o => o.Language.Code != "RU").ToList())
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
        [HttpPost, Route("SetTeammateMiddleDescriptionsTranslations")]
        public async Task SetTeammateMiddleDescriptionsTranslations([FromBody] IdsModel ids)
        {
            var obj = DB.Teammates.Include(o => o.MiddleDescriptions).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach (var translation in obj.MiddleDescriptions.Where(o => o.Language.Code != "RU").ToList())
            {
                obj.MiddleDescriptions.Remove(translation);
            }

            foreach (var id in ids.Ids)
            {
                var translation = DB.TranslationItems.FirstOrDefault(o => o.Id == id);
                obj.MiddleDescriptions.Add(translation);
            }
            DB.SaveChanges();
        }
        [HttpPost, Route("SetTeammatePositionTranslations")]
        public async Task SetTeammatePositionTranslations([FromBody] IdsModel ids)
        {
            var obj = DB.Teammates.Include(o => o.Positions).ThenInclude(o => o.Language).FirstOrDefault(o => o.Id == ids.Id);
            foreach (var translation in obj.Positions.Where(o => o.Language.Code != "RU").ToList())
            {
                obj.Positions.Remove(translation);
            }

            foreach (var id in ids.Ids)
            {
                var translation = DB.TranslationItems.FirstOrDefault(o => o.Id == id);
                obj.Positions.Add(translation);
            }
            DB.SaveChanges();
        }
        #endregion

        #endregion


        [HttpGet, Route("Admin/DeleteTeammate")]
        public IActionResult DeleteTeammate(int id)
        {
            var teammate = DB.Teammates
                .Include(o => o.Titles)
                .Include(o => o.MiddleDescriptions)
                .Include(o => o.Positions)
                .FirstOrDefault(o => o.Id == id);

            DB.TranslationItems.RemoveRange(teammate.Titles);
            DB.TranslationItems.RemoveRange(teammate.MiddleDescriptions);
            DB.TranslationItems.RemoveRange(teammate.Positions);

            DB.Teammates.Remove(teammate);
            DB.SaveChanges();
            return RedirectToAction("Team", "Team");
        }
    }
}
