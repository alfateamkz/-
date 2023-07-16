using Alfateam.Abstractions;
using Alfateam.CRM.ViewModels.Orders;
using Alfateam.CRM.ViewModels.Resources;
using Alfateam.CRM.ViewModels.Sales;
using Alfateam.Database;
using Alfateam.Database.Enums.CRM;
using Alfateam.Database.Enums.CRM.Staff;
using Alfateam.Database.Models.CRM;
using Alfateam.Database.Models.CRM.Orders;
using Alfateam.Database.Models.CRM.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin {

    //[Authorize(Roles ="Admin,ProjectManager")]
    public class ResourcesController : AbsController
    {
        public ResourcesController(CRMDatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Resources")]
        public IActionResult Resources()
        {
            var vm = new ResourcesPageVM {
                Resources = DB.Resources.OrderByDescending(o => o.Id).ToList()
            };
            return View(@"Views\Resources\Resources.cshtml", vm);
        }

        //[HttpGet, Route("OrderPage")]
        //public IActionResult OrderPage(int id) {
        //    var order = DB.OrderModels.Where(o => o.Status == OrderStatus.Active)
        //                               .FirstOrDefault(o => o.Id == id);
        //    var vm = new OrderPageVM {
        //        Order = order,
        //        Employees = DB.Employees.ToList(),
        //        Resources = DB.Resources.ToList(),
        //    };
        //    return View(@"Views\Orders\Order.cshtml", vm);
        //}


        [HttpGet, Route("CreateResource")]
        public IActionResult CreateResource() {

            var vm = new ResourcePageVM();
            return View(@"Views\Resources\CreateResource.cshtml", vm);
        }
        [HttpPost, Route("CreateResourcePOST")]
        public async Task<IActionResult> CreateResourcePOST(ResourcePageVM vm) {

            DB.Resources.Add(vm.Resource);
            DB.SaveChanges();
            return RedirectToAction("Resources", "Resources");
        }




        [HttpGet, Route("UpdateResource")]
        public IActionResult UpdateResource(int id) {

            var vm = new ResourcePageVM() {
                Resource = DB.Resources.FirstOrDefault(o => o.Id == id)
            };
            return View(@"Views\Resources\UpdateResource.cshtml", vm);
        }

        [HttpPost, Route("UpdateResourcePOST")]
        public async Task<IActionResult> UpdateResourcePOST(ResourcePageVM vm) {

            DB.Resources.Update(vm.Resource);
            DB.SaveChanges();
            return RedirectToAction("Resources", "Resources");
        }


    }
}
