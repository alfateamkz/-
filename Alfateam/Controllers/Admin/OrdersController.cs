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


    }
}
