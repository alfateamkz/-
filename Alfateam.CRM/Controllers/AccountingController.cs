using Alfateam.Abstractions;
using Alfateam.CRM.ViewModels.Accounting;
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
using System;

namespace Alfateam.Controllers.Admin {

    //[Authorize(Roles ="Admin,ProjectManager")]
    public class AccountingController : AbsController
    {
        public AccountingController(CRMDatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Accounting")]
        public IActionResult Accounting()
        {
            var from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var to = from.AddMonths(1).AddDays(-1);

            var items = DB.AccountingItems.Where(o => o.Date>=from && o.Date <= to)
                                          .OrderBy(o => o.Date)
                                          .ToList();
            items.Add(new Database.Models.CRM.Accounting.AccountingItem {
                Title = "[eq",
                Description = "dasfsdfs",
                Sum = 134234,
                Direction = Database.Enums.CRM.Accounting.AccountingItemDirection.Income
            });
            items.Add(new Database.Models.CRM.Accounting.AccountingItem {
                Title = "[eq",
                Description = "dasfsdfs",
                Sum = 13234,
                Direction = Database.Enums.CRM.Accounting.AccountingItemDirection.Expense
            });
            var vm = new AccountingPageVM {
                Items = items,
                From = from,
                To = to,
            };
            return View(@"Views\Accounting\Accounting.cshtml", vm);
        }



        [HttpGet, Route("AccountingByPeriod")]
        public IActionResult AccountingByPeriod(DateTime from,DateTime to) {

            var items = DB.AccountingItems.Where(o => o.Date >= from && o.Date <= to)
                                          .OrderBy(o => o.Date)
                                          .ToList();
            var vm = new AccountingPageVM {
                Items = items,
                From = from,
                To = to,
            };
            return View(@"Views\Accounting\Accounting.cshtml", vm);
        }
        [HttpGet, Route("AccountingByMonth")]
        public IActionResult AccountingByMonth(int year,int month) {

            var from = new DateTime(year, month, 1);
            var to = from.AddMonths(1).AddDays(-1);

            var items = DB.AccountingItems.Where(o => o.Date >= from && o.Date <= to)
                                        .OrderBy(o => o.Date)
                                        .ToList();
            var vm = new AccountingPageVM {
                Items = items,
                From = from,
                To = to,
            };
            return View(@"Views\Accounting\Accounting.cshtml", vm);
        }




        [HttpGet, Route("GetAccountingByPeriodJSON")]
        public IActionResult GetAccountingByPeriodJSON(DateTime from, DateTime to) {

            var items = DB.AccountingItems.Where(o => o.Date >= from && o.Date <= to)
                                          .OrderBy(o => o.Date)
                                          .ToList();
            return Json(items);
        }
        [HttpGet, Route("GetAccountingByMonthJSON")]
        public IActionResult GetAccountingByMonthJSON(int year, int month) {

            var from = new DateTime(year, month, 1);
            var to = from.AddMonths(1).AddDays(-1);
            var items = DB.AccountingItems.Where(o => o.Date >= from && o.Date <= to)
                                          .OrderBy(o => o.Date)
                                          .ToList();


            items.Add(new Database.Models.CRM.Accounting.AccountingItem {
                Title = "[eq",
                Description = "dasfsdfs",
                Sum = 134234,
                Direction = Database.Enums.CRM.Accounting.AccountingItemDirection.Income
            });
            items.Add(new Database.Models.CRM.Accounting.AccountingItem {
                Title = "[eq",
                Description = "dasfsdfs",
                Sum = 13234,
                Direction = Database.Enums.CRM.Accounting.AccountingItemDirection.Expense
            });

            var vm = new AccountingPageVM {
                Items = items,
                From = from,
                To = to,
            };
            return Json(vm);
        }
    }
}
