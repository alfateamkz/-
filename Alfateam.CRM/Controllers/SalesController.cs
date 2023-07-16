using Alfateam.Abstractions;
using Alfateam.CRM.ViewModels.Orders;
using Alfateam.CRM.ViewModels.Resources;
using Alfateam.CRM.ViewModels.Sales;
using Alfateam.CRM.ViewModels.Sales.Clients;
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
    public class SalesController : AbsController
    {
        public SalesController(CRMDatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        #region Клиенты
        [HttpGet, Route("Clients")]
        public IActionResult Clients() {
            var vm = new ClientsPageVM {
                Clients = DB.Clients.OrderByDescending(o => o.Id).ToList()
            };
            return View(@"Views\Sales\Clients\Clients.cshtml", vm);
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


        [HttpGet, Route("CreateClient")]
        public IActionResult CreateClient() {

            var vm = new ClientPageVM();
            return View(@"Views\Sales\Clients\CreateClient.cshtml", vm);
        }
        [HttpPost, Route("CreateClientPOST")]
        public async Task<IActionResult> CreateClientPOST(ClientPageVM vm) {

            DB.Clients.Add(vm.Client);
            DB.SaveChanges();
            return RedirectToAction("Clients", "Sales");
        }




        [HttpGet, Route("UpdateClient")]
        public IActionResult UpdateClient(int id) {

            var vm = new ClientPageVM() {
                Client = DB.Clients.Include(o => o.Contacts)
                                   .FirstOrDefault(o => o.Id == id)
            };
            return View(@"Views\Sales\Clients\UpdateClient.cshtml", vm);
        }

        [HttpPost, Route("UpdateClientPOST")]
        public async Task<IActionResult> UpdateClientPOST(ClientPageVM vm) {

            DB.Clients.Update(vm.Client);
            DB.SaveChanges();
            return RedirectToAction("Clients", "Sales");
        }

        #endregion





    }
}
