using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Database.Models.ForBusiness;
using Alfateam.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin.ForBusiness
{
	[Authorize("Admin")]
	public class OutstaffController : AbsController
	{
		public OutstaffController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
		{
		}

		[HttpGet, Route("Admin/Outstaff")]
		public IActionResult Outstaff()
		{
			var emloyees = DB.OutstaffEmployeeInfos.ToList();
			return View(@"Views\Admin\ForBusiness\Outstaff\Outstaff.cshtml", emloyees);
		}


        #region Добавление нового аутстафф сотрудника
        [HttpGet, Route("Admin/CreateOutstaff")]
        public IActionResult CreateOutstaff()
        {
            return View(@"Views\Admin\ForBusiness\Outstaff\CreateOutstaff.cshtml");
        }
        [HttpPost, Route("Admin/CreateOutstaffPOST")]
        public async Task<IActionResult> CreateOutstaffPOST(OutstaffEmployeeInfo outstaff)
        {
            outstaff.CVPath = await SetAttachmentIfHas(outstaff.CVPath);

            DB.OutstaffEmployeeInfos.Add(outstaff);
            DB.SaveChanges();
            return RedirectToAction("Outstaff", "Outstaff");
        }
        #endregion

        #region Редактирование существующего партнера

        [HttpGet, Route("Admin/UpdateOutstaff")]
        public IActionResult UpdateOutstaff(int id)
        {
            var outstaff = DB.OutstaffEmployeeInfos.FirstOrDefault(o => o.Id == id);
            return View(@"Views\Admin\ForBusiness\Outstaff\UpdateOutstaff.cshtml", outstaff);
        }
        [HttpPost, Route("Admin/UpdateOutstaffPOST")]
        public async Task<IActionResult> UpdateOutstaffPOST(OutstaffEmployeeInfo outstaff)
        {
            outstaff.CVPath = await SetAttachmentIfHas(outstaff.CVPath);

            DB.OutstaffEmployeeInfos.Update(outstaff);
            DB.SaveChanges();
            return RedirectToAction("Outstaff", "Outstaff");
        }



        #endregion


        [HttpGet, Route("Admin/DeleteOutstaff")]
        public IActionResult DeleteOutstaff(int id)
        {
            var outstaff = DB.OutstaffEmployeeInfos.FirstOrDefault(o => o.Id == id);


            DB.OutstaffEmployeeInfos.Remove(outstaff);
            DB.SaveChanges();
            return RedirectToAction("Outstaff", "Outstaff");
        }
    }
}
