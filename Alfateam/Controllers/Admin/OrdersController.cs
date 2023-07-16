using Alfateam.Abstractions;
using Alfateam.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class OrdersController : AbsController
    {
        public OrdersController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Admin/Orders")]
        public IActionResult Orders()
        {
            var orders = DB.Orders.OrderByDescending(o => o.Id).ToList();
            return View(@"Views\Admin\Orders.cshtml", orders);
        }





        [HttpGet, Route("Admin/CallRequests")]
        public IActionResult CallRequests()
        {
            var orders = DB.CallRequests.Where(o => !o.WasCall).OrderByDescending(o => o.Id).ToList();
            return View(@"Views\Admin\CallRequests.cshtml", orders);
        }
        [HttpGet, Route("Admin/HandleCallRequest")]
        public IActionResult HandleCallRequest(int id)
        {
            
            var call = DB.CallRequests.FirstOrDefault(o => o.Id == id);
            call.WasCall = true;

            DB.CallRequests.Update(call);
            DB.SaveChanges();

            return RedirectToAction("CallRequests","Orders");
        }


    }
}
