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
            var emloyees = DB.OutstaffEmployeeInfos.ToList();
            return View(@"Views\ForBusinessClient\Outstaff.cshtml", emloyees);
        }


    }
}
