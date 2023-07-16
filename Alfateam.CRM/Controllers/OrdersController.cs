using Alfateam.Abstractions;
using Alfateam.CRM.ViewModels.Orders;
using Alfateam.Database;
using Alfateam.Database.Enums.CRM;
using Alfateam.Database.Enums.CRM.Staff;
using Alfateam.Database.Models.CRM;
using Alfateam.Database.Models.CRM.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Controllers.Admin {

//    [Authorize(Roles ="Admin,Employee,SalesManager,ProjectManager" )]
    public class OrdersController : AbsController
    {
        public OrdersController(CRMDatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Orders")]
        public IActionResult Orders()
        {
            var orders = DB.OrderModels.Include(o => o.BudgetItems)
                                       .Where(o => o.Status == OrderStatus.Active)
                                       .OrderByDescending(o => o.Id)
                                       .ToList();
            var vm = new OrdersPageVM {
                Orders = orders
            };
            return View(@"Views\Orders\Orders.cshtml", vm);
        }

        [HttpGet, Route("OrderPage")]
        public IActionResult OrderPage(int id) {
            var order = DB.OrderModels.Where(o => o.Status == OrderStatus.Active)
                                       .FirstOrDefault(o => o.Id == id);
            var vm = new OrderPageVM {
                Order = order,
                Employees = DB.Employees.ToList(),
                Resources = DB.Resources.ToList(),
            };
            return View(@"Views\Orders\Order.cshtml", vm);
        }


        [HttpGet, Route("CreateOrder")]
        public IActionResult CreateOrder() {
            var vm = new OrderPageVM {
                Clients = DB.Clients.ToList()
            };
            return View(@"Views\Orders\CreateOrder.cshtml", vm);
        }
        [HttpPost, Route("CreateOrderPOST")]
        public async Task<IActionResult> CreateOrderPOST(OrderPageVM vm) {

            var order = vm.Order;
            order.TSPath = await this.SetAttachmentIfHas(order.TSPath, "ts");

            order.SetDefaultData();
           

            DB.OrderModels.Add(order);
            DB.SaveChanges();

            return RedirectToAction("Orders", "Orders");
        }




        [HttpGet, Route("UpdateOrder")]
        public IActionResult UpdateOrder(int id) {

            var vm = new OrderPageVM {
                Order = DB.OrderModels.Include(o => o.Client)
                                      .Include(o => o.BudgetItems)
                                      .Include(o => o.Stages).ThenInclude(o => o.HumanResources).ThenInclude(o => o.Employee)
                                      .Include(o => o.Stages).ThenInclude(o => o.MaterialResources).ThenInclude(o => o.Resource)
                                      .Include(o => o.Stages).ThenInclude(o => o.BudgetItems)
                                      .FirstOrDefault(o => o.Id == id),
                Clients = DB.Clients.ToList(),
                Employees = DB.Employees.ToList(),
                Resources = DB.Resources.ToList(),
            };

            vm.Order.Stages = vm.Order.Stages.Where(o => !o.IsDeleted).ToList();
            vm.Order.BudgetItems = vm.Order.BudgetItems.Where(o => !o.IsDeleted).ToList();

            return View(@"Views\Orders\UpdateOrder.cshtml", vm);
        }
        [HttpPost, Route("UpdateOrderPOST")]
        public async Task<IActionResult> UpdateOrderPOST(OrderPageVM vm) {

            var order = vm.Order;
            order.TSPath = await this.SetAttachmentIfHas(order.TSPath, "ts");

            DB.OrderModels.Update(order);
            DB.SaveChanges();

            return RedirectToAction("Orders", "Orders");
        }





        [HttpGet, Route("UpdateOrderStage")]
        public IActionResult UpdateOrderStage(int id) {

            var vm = new OrderStagePageVM {
                Stage = DB.OrderStages.Include(o => o.BudgetItems)
                                      .Include(o => o.HumanResources).ThenInclude(o => o.Employee)
                                      .Include(o => o.MaterialResources).ThenInclude(o => o.Resource)
                                      .FirstOrDefault(o => o.Id == id),
                Employees = DB.Employees.ToList(),
                Resources = DB.Resources.ToList(),
            };

            vm.Stage.BudgetItems = vm.Stage.BudgetItems.Where(o => !o.IsDeleted).ToList();
            vm.Stage.MaterialResources = vm.Stage.MaterialResources.Where(o => !o.IsDeleted).ToList();
            vm.Stage.HumanResources = vm.Stage.HumanResources.Where(o => !o.IsDeleted).ToList();

            return View(@"Views\Orders\Stages\UpdateStage.cshtml", vm);
        }

        #region Элементы бюджета заказа
        [HttpGet, Route("GetOrderBudgetItem")]
        public IActionResult GetOrderBudgetItem(int budgetItemId) {

            var item = DB.BudgetItems.FirstOrDefault(o => o.Id == budgetItemId);
            return Json(item);
        }
        [HttpGet, Route("AddOrderBudgetItem")]
        public IActionResult AddOrderBudgetItem(int orderId) {

            var order = DB.OrderModels
                .Include(o => o.BudgetItems)
                .FirstOrDefault(o => o.Id == orderId);


            var item = new BudgetItem {
                Title = $"Статья бюджета {order.BudgetItems.Where(o => !o.IsDeleted).Count() + 1}",
            };
            order.BudgetItems.Add(item);
            DB.OrderModels.Update(order);

            DB.SaveChanges();
            return Json(item);
        }

        [HttpPost, Route("EditOrderBudgetItem")]
        public IActionResult EditOrderBudgetItem([FromBody]BudgetItem item) {
            DB.BudgetItems.Update(item);
            DB.SaveChanges();
            return Json(item);
        }


        [HttpDelete, Route("DeleteOrderBudgetItem")]
        public void DeleteOrderBudgetItem(int budgetItemId) {

            var item = DB.BudgetItems.FirstOrDefault(o => o.Id == budgetItemId);
            item.IsDeleted = true;

            DB.BudgetItems.Update(item);
            DB.SaveChanges();
        }

        #endregion

        #region Этапы заказа
        [HttpGet, Route("GetOrderStage")]
        public IActionResult GetOrderStage(int stageId) {

            var stage = DB.OrderStages
                .Include(o => o.MaterialResources).ThenInclude(o => o.Resource)
                .Include(o => o.HumanResources).ThenInclude(o => o.Employee)
                .Include(o => o.BudgetItems)
                .FirstOrDefault(o => o.Id == stageId);

            

            return Json(stage);
        }
        [HttpGet, Route("AddOrderStage")]
        public IActionResult AddOrderStage(int orderId) {

            var order = DB.OrderModels
                .Include(o => o.Stages)
                .FirstOrDefault(o => o.Id == orderId);


            var stage = new OrderStage {
                Title = $"Этап {order.Stages.Where(o => !o.IsDeleted).Count()+1}",
            };
            order.Stages.Add(stage);
            DB.OrderModels.Update(order);

            DB.SaveChanges();
            return Json(stage);
        }
        [HttpPost, Route("UpdateOrderStage")]
        public IActionResult UpdateOrderStage(OrderStage stage) {

            DB.OrderStages.Update(stage);
            DB.SaveChanges();
            return Json(stage);
        }


        [HttpDelete, Route("DeleteOrderStage")]
        public void DeleteOrderStage(int stageId) {

            var stage = DB.OrderStages.FirstOrDefault(o => o.Id == stageId);
            stage.IsDeleted = true;


            DB.OrderStages.Update(stage);
            DB.SaveChanges();
        }
        #endregion



        #region Элементы бюджета этапа заказа
        [HttpGet, Route("GetOrderStageBudgetItem")]
        public IActionResult GetOrderStageBudgetItem(int budgetItemId) {

            var item = DB.BudgetItems.FirstOrDefault(o => o.Id == budgetItemId);
            return Json(item);
        }
        [HttpGet, Route("AddOrderStageBudgetItem")]
        public IActionResult AddOrderStageBudgetItem(int stageId) {

            var stage = DB.OrderStages
                .Include(o => o.BudgetItems)
                .FirstOrDefault(o => o.Id == stageId);


            var budgetItem = new BudgetItem {
                Title = $"Этап {stage.BudgetItems.Where(o => !o.IsDeleted).Count() + 1}",
            };
            stage.BudgetItems.Add(budgetItem);

            DB.OrderStages.Update(stage);
            DB.SaveChanges();
            return Json(budgetItem);
        }
        [HttpPost, Route("EditOrderStageBudgetItem")]
        public IActionResult EditOrderStageBudgetItem([FromBody] BudgetItem item) {
            DB.BudgetItems.Update(item);
            DB.SaveChanges();
            return Json(item);
        }


        [HttpDelete, Route("DeleteOrderStageBudgetItem")]
        public void DeleteOrderStageBudgetItem(int budgetItemId) {

            var item = DB.BudgetItems.FirstOrDefault(o => o.Id == budgetItemId);
            item.IsDeleted = true;

            DB.BudgetItems.Update(item);
            DB.SaveChanges();
        }
        #endregion

        #region Человеческий ресурс этапа заказа

        [HttpGet, Route("GetStageHumanResource")]
        public IActionResult GetStageHumanResource(int id) {

            var item = DB.StageHumanResources
                .Include(o => o.Employee)
                .FirstOrDefault(o => o.Id == id);
            return Json(item);
        }

        [HttpPost, Route("AddStageHumanResource")]
        public IActionResult AddStageHumanResource(int stageId,[FromBody] StageHumanResource resource) {

            var stage = DB.OrderStages
                .Include(o => o.HumanResources)
                .FirstOrDefault(o => o.Id ==stageId);
            
            if(stage.HumanResources.Any(o => o.EmployeeId == resource.EmployeeId)) {
                return Json(new {
                    Success = false,
                    ErrorText = "Данный человек уже задействован на этапе",
                    Resource = resource
                });
            }

            stage.HumanResources.Add(resource);
            DB.OrderStages.Update(stage);
            DB.SaveChanges();


            resource.Employee = DB.Employees.FirstOrDefault(o => o.Id == resource.EmployeeId);
            return Json(new {
                Success = true,
                ErrorText = "",
                Resource = resource
            });
        }
        [HttpPost, Route("UpdateStageHumanResource")]
        public IActionResult UpdateStageHumanResource(int stageId, [FromBody] StageHumanResource resource) {

            var stage = DB.OrderStages
                .Include(o => o.HumanResources)
                .FirstOrDefault(o => o.Id == stageId);

            var oldResourceVersion = DB.StageHumanResources.AsNoTracking()
                                                           .FirstOrDefault(o => o.Id == resource.Id);
            


            if (stage.HumanResources.Any(o => o.EmployeeId == resource.EmployeeId)
                          && oldResourceVersion.EmployeeId != resource.EmployeeId) {
                return Json(new {
                    Success = false,
                    ErrorText = "Данный человек уже задействован на этапе",
                    Resource = resource
                });
            }

            oldResourceVersion = null;
            DB.ChangeTracker.Clear();


            DB.StageHumanResources.Update(resource);
            DB.SaveChanges();

            resource.Employee = DB.Employees.FirstOrDefault(o => o.Id == resource.EmployeeId);
            return Json(new {
                Success = true,
                ErrorText = "",
                Resource = resource
            });
        }

        [HttpDelete, Route("DeleteStageHumanResource")]
        public void DeleteStageHumanResource(int resourceId) {

            var resource = DB.StageHumanResources.FirstOrDefault(o => o.Id == resourceId);

            DB.StageHumanResources.Remove(resource);
            DB.SaveChanges();
        }

        #endregion

        #region Ресурс этапа заказа

        [HttpGet, Route("GetStageResource")]
        public IActionResult GetStageResource(int id) {

            var item = DB.StageMaterialResources
                .Include(o => o.Resource)
                .FirstOrDefault(o => o.Id == id);
            return Json(item);
        }

        [HttpPost, Route("AddStageResource")]
        public IActionResult AddStageResource(int stageId, [FromBody] StageMaterialResource resource) {

            var stage = DB.OrderStages
                .Include(o => o.MaterialResources)
                .FirstOrDefault(o => o.Id == stageId);

            if (stage.MaterialResources.Any(o => o.ResourceId == resource.ResourceId)) {
                return Json(new {
                    Success = false,
                    ErrorText = "Данный ресурс уже задействован на этапе",
                    Resource = resource
                });
            }

            stage.MaterialResources.Add(resource);
            DB.OrderStages.Update(stage);
            DB.SaveChanges();


            resource.Resource = DB.Resources.FirstOrDefault(o => o.Id == resource.ResourceId);
            return Json(new {
                Success = true,
                ErrorText = "",
                Resource = resource
            });
        }
        [HttpPost, Route("UpdateStageResource")]
        public IActionResult UpdateStageResource(int stageId, [FromBody] StageMaterialResource resource) {

            var stage = DB.OrderStages
                .Include(o => o.MaterialResources)
                .FirstOrDefault(o => o.Id == stageId);

            var oldResourceVersion = DB.StageMaterialResources.AsNoTracking()
                                                           .FirstOrDefault(o => o.Id == resource.Id);



            if (stage.MaterialResources.Any(o => o.ResourceId == resource.ResourceId)
                              && oldResourceVersion.ResourceId != resource.ResourceId) {
                return Json(new {
                    Success = false,
                    ErrorText = "Данный ресурс уже задействован на этапе",
                    Resource = resource
                });
            }

            oldResourceVersion = null;
            DB.ChangeTracker.Clear();


            DB.StageMaterialResources.Update(resource);
            DB.SaveChanges();

            resource.Resource = DB.Resources.FirstOrDefault(o => o.Id == resource.ResourceId);
            return Json(new {
                Success = true,
                ErrorText = "",
                Resource = resource
            });
        }

        [HttpDelete, Route("DeleteStageResource")]
        public void DeleteStageResource(int resourceId) {

            var resource = DB.StageMaterialResources.FirstOrDefault(o => o.Id == resourceId);

            DB.StageMaterialResources.Remove(resource);
            DB.SaveChanges();
        }

        #endregion
    }
}
