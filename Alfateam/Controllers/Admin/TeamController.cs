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
                .Include(o => o.Localizations)
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
              .Include(o => o.Localizations)
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



        #endregion


        [HttpGet, Route("Admin/DeleteTeammate")]
        public IActionResult DeleteTeammate(int id)
        {
            var teammate = DB.Teammates
                .Include(o => o.Localizations)
                .FirstOrDefault(o => o.Id == id);


            DB.Teammates.Remove(teammate);
            DB.SaveChanges();
            return RedirectToAction("Team", "Team");
        }
    }
}
