using Alfateam.Abstractions;
using Alfateam.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers
{
    public class ErrorPagesController : AbsController
    {
        public ErrorPagesController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }


        [Route("Hui"), Route("Хуй")]
        public IActionResult Hui()
        {
            var vm = DB.ErrorPages
                .Include(o => o.TextsNuhuyaTitle).ThenInclude(o => o.Language)
                .Include(o => o.TextsNuhuyaDescription).ThenInclude(o => o.Language)
                .FirstOrDefault();
            return View(@"Views\ErrorPages\Hui.cshtml", vm);
        }
        [Route("Error/NotFound")]
        public IActionResult NotFound()
        {
            var vm = DB.ErrorPages
                .Include(o => o.Texts404).ThenInclude(o => o.Language)
                .FirstOrDefault();
            return View(@"Views\ErrorPages\404.cshtml", vm);
        }
        [Route("Error/Forbidden")]
        public IActionResult Forbidden()
        {
            var vm = DB.ErrorPages
                .Include(o => o.Texts403).ThenInclude(o => o.Language)
                .FirstOrDefault();
            return View(@"Views\ErrorPages\403.cshtml", vm);
        }
    }
}
