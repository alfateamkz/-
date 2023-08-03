using Alfateam.Abstractions;
using Alfateam.Database;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Controllers
{
    public class ForBusinessClientController : AbsController
    {
        public ForBusinessClientController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet, Route("Outstaff")]
        public IActionResult Outstaff()
        {
            return NotFound();
            var emloyees = DB.OutstaffEmployeeInfos.ToList();
            return View(@"Views\ForBusinessClient\Outstaff.cshtml", emloyees);
        }

        [HttpGet, Route("ChurchApp")]
        public IActionResult ChurchApp()
        {
            return File("/файлы/church.apk", "application/octet-stream","church.apk");
        }
    }
}
