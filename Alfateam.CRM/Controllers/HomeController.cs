using Alfateam.Abstractions;
using Alfateam.CRM.Models;
using Alfateam.Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace Alfateam.CRM.Controllers {
    public class HomeController : AbsController {
        public HomeController(CRMDatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment) {
        }

        [Route("ToGayClub")]
        public IActionResult Login() {
            return View(@"Views\Profile\Login.cshtml");
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [Route("DownloadFile")]
        public IActionResult DownloadFile(string path) {

            byte[] fileBytes = System.IO.File.ReadAllBytes(AppEnvironment.WebRootPath + path);
            string fileName = Path.GetFileName(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}