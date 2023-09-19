using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.CRM2_0.Controllers.Roles.Sales
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Sales)]
	public class SalesOrdersController : AbsController
    {
        public SalesOrdersController(ControllerParams @params) : base(@params)
        {
        }

		#region Заказы

		[HttpGet, Route("GetOrders")]
		public async Task<RequestResult> GetOrders(int offset, int count = 20)
		{
			var orders = DB.Orders.Include(o => o.Customer)
								  .Include(o => o.Currency)
								  .Include(o => o.SaleInfo)
								  .Include(o => o.ProjectManager)
								  .Include(o => o.TechLead)
							      .Include(o => o.TeamLead)
								  .Where(o => o.SalesDepartmentId == this.DepartmentId);

			return GetMany<Order, OrderClientModel>(orders, offset, count);
		}

		[HttpGet, Route("GetOrder")]
		public async Task<RequestResult> GetOrder(int id)
		{
			var order = DB.Orders.Include(o => o.Customer)
								 .Include(o => o.Currency)
								 .Include(o => o.SaleInfo)
								 .Include(o => o.ProjectManager)
								 .Include(o => o.TechLead)
								 .Include(o => o.TeamLead)
								 .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseOrder(order),
				() =>
				{
					var clientModel = OrderClientModel.Create(order);
					return RequestResult<OrderClientModel>.AsSuccess(clientModel);
				}
			});
		}



		[HttpPost, Route("CreateOrder")]
		public async Task<RequestResult> CreateOrder(OrderCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var order = model.Create();

					var orderCheckResult = CheckOrderModel(order);
					if (!orderCheckResult.Success)
					{
						return orderCheckResult;
					}

					order.SalesDepartmentId = this.DepartmentId;
					order.SaleInfo.FoundById = authorizedUser.Id;

					return CreateModel(DB.Orders, order);
				}
			});
		}

		[HttpPut, Route("EditOrder")]
		public async Task<RequestResult> EditOrder(OrderEditModel model)
		{
			var order = DB.Orders.Include(o => o.SaleInfo).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseOrder(order),
				() =>
				{
					model.Fill(order);

					var orderCheckResult = CheckOrderModel(order);
					if (!orderCheckResult.Success)
					{
						return orderCheckResult;
					}

					return UpdateModel(DB.Orders, order);
				}
			});
		}

		[HttpGet, Route("DeleteOrder")]
		public async Task<RequestResult> DeleteOrder(int id)
		{
			var order = DB.Orders.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseOrder(order),
				() => DeleteOrder(DB.Orders, order)
			});
		}

		#endregion

		#region Работа с заказом

		[HttpPost, Route("UploadOrderTS")]
		public async Task<RequestResult> UploadOrderTS(int id)
		{
			var order = DB.Orders.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseOrder(order),
				() => RequestResult.FromBoolean(Request.Form.Files.Any(o => o.Name == "tsFile"), 400, "Не загружен файл ТЗ"),
				() =>
				{
					var uploadFileResult = TryUploadFile("tsFile", Enums.FileType.Document).Result;
					if (!uploadFileResult.Success)
					{
						return uploadFileResult;
					}

					order.TSPath = uploadFileResult.Value;
					return UpdateModel(DB.Orders, order);
				}
			});
		}

		#endregion




		#region Private check methods

		private RequestResult CheckBaseOrder(Order order)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(order != null,404,"Заказ с данным id не найден"),
				() => RequestResult.FromBoolean(order.SalesDepartmentId == this.DepartmentId,403,"Нет доступа к данному заказу"),
			});
		}
		private RequestResult CheckOrderModel(Order order)
		{
			var customer = DB.Users.Where(o => o is Customer)
					   .Cast<Customer>()
					   .FirstOrDefault(o => !o.IsDeleted && o.Id == model.CustomerId);
			
			var customerCheckResult = CheckBaseCustomer(customer);
			if (!customerCheckResult.Success)
			{
				return customerCheckResult;
			}


			var currency = DB.Currencies.FirstOrDefault(o => o.Id == model.CurrencyId && !o.IsDeleted);
			if(currency == null)
			{
				return RequestResult.AsError(404, "Валюта с данным id не найдена");
			}


			if (model.StartDate >= model.Deadline)
			{
				return RequestResult.AsError(400, "Дедлайн не может быть раньше даты старта");
			}

			if (order.SaleInfo.FunnelId != null)
			{
				var funnel = DB.SalesFunnels.FirstAsync(o => o.Id == order.SaleInfo.FunnelId && !o.IsDeleted);
				var funnelCheckResult = CheckBaseSalesFunnel(funnel);
				if (!funnelCheckResult.Success)
				{
					return funnelCheckResult;
				}

				if (order.SaleInfo.FunnelStageId != null)
				{
					var funnelStage = DB.SalesFunnelStages.FirstOrDefault(o => o.Id == order.SaleInfo.FunnelStageId && !o.IsDeleted);
					var funnelStageCheckResult = CheckBaseSalesFunnelAndStage(funnel, funnelStage);
					if (!funnelStageCheckResult.Success)
					{
						return funnelStageCheckResult;
					}
				}
			}

		}


		private RequestResult CheckBaseCustomer(Customer customer)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(customer != null,404,"Клиент с данным id не найден"),
				() => RequestResult.FromBoolean(customer.SalesDepartmentId == this.DepartmentId,403,"Нет доступа к данному клиенту"),
			});
		}



		private RequestResult CheckBaseSalesFunnel(SalesFunnel funnel)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(funnel != null,404,"Воронка продаж с данным id не найдена"),
				() => RequestResult.FromBoolean(funnel.SalesDepartmentId == this.DepartmentId,403,"Нет доступа к данной воронки продаж"),
			});
		}
		private RequestResult CheckBaseSalesFunnelAndStage(SalesFunnel funnel, SalesFunnelStage stage)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnel(funnel),
				() => RequestResult.FromBoolean(stage != null,404,"Этап воронки продаж с данным id не найден"),
				() => RequestResult.FromBoolean(stage.SalesFunnelId == funnel.Id,403,"Этап воронки продаж не принадлежит текущей воронке продаж"),
			});
		}

		#endregion
	}
}
