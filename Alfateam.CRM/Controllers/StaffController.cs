using Alfateam.Abstractions;
using Alfateam.CRM.ViewModels.Orders;
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
    public class StaffController : AbsController
    {
        public StaffController(CRMDatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Employees")]
        public IActionResult Employees()
        {
            var employees = DB.Employees.OrderByDescending(o => o.Id).ToList();


            var vm = new EmployeesPageVM {
                Employees = employees
            };
            return View(@"Views\Staff\Employees.cshtml", vm);
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


        [HttpGet, Route("CreateEmployee")]
        public IActionResult CreateEmployee() {
            var vm = new EmployeePageVM {
                Employee = new Employee {
                    Contacts = new ContactsModel(),
                    Documents = new EmployeeDocuments()
                }
            };
            return View(@"Views\Staff\CreateEmployee.cshtml", vm);
        }
        [HttpPost, Route("CreateEmployeePOST")]
        public async Task<IActionResult> CreateEmployeePOST(EmployeePageVM vm) {

            var employee = vm.Employee;
            employee.Documents = new EmployeeDocuments();

            employee.PhotoPath = await this.SetAttachmentIfHas(employee.PhotoPath, "file");
            employee.Documents.CVPath = await this.SetAttachmentIfHas(employee.Documents.CVPath, "cv");
            employee.Documents.MainDocumentPath = await this.SetAttachmentIfHas(employee.Documents.MainDocumentPath, "mainDocument");
            employee.Documents.MilitaryIDPath = await this.SetAttachmentIfHas(employee.Documents.MilitaryIDPath, "militaryId");
            employee.Documents.DiplomaPath = await this.SetAttachmentIfHas(employee.Documents.DiplomaPath, "diploma");


            DB.Employees.Add(employee);
            DB.SaveChanges();
            return RedirectToAction("Employees", "Staff");
        }




        [HttpGet, Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(int id) {
            var vm = new EmployeePageVM {
                Employee = DB.Employees.Include(o => o.Contacts)
                                       .Include(o => o.Documents)
                                       .FirstOrDefault(o => o.Id == id)
            };
            return View(@"Views\Staff\UpdateEmployee.cshtml", vm);
        }
        [HttpPost, Route("UpdateEmployeePOST")]
        public async Task<IActionResult> UpdateEmployeePOST(EmployeePageVM vm) {

            var employee = vm.Employee;

            employee.PhotoPath = await this.SetAttachmentIfHas(employee.PhotoPath, "file");
            employee.Documents.CVPath = await this.SetAttachmentIfHas(employee.Documents.CVPath, "cv");
            employee.Documents.MainDocumentPath = await this.SetAttachmentIfHas(employee.Documents.MainDocumentPath, "mainDocument");
            employee.Documents.MilitaryIDPath = await this.SetAttachmentIfHas(employee.Documents.MilitaryIDPath, "militaryId");
            employee.Documents.DiplomaPath = await this.SetAttachmentIfHas(employee.Documents.DiplomaPath, "diploma");

            if(employee.Status == EmployeeStatus.Fired) {
                employee.FiredAt = DateTime.Now;
            }

            DB.Employees.Update(employee);
            DB.SaveChanges();
            return RedirectToAction("Employees", "Staff");
        }


    }
}
