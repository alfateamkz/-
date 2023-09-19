using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Management
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.BranchDirector)]
	public class OrdersAssignmentsController : AbsController
	{
		public OrdersAssignmentsController(ControllerParams @params) : base(@params)
		{
		}

		#region Назначение ответственных

		[HttpPut, Route("SetOrderProjectManager")]
		public async Task<RequestResult> SetOrderProjectManager(int orderId, int userId)
		{
			var order = DB.Orders.Include(o => o.Employees)
							     .FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

			var user = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
							   .FirstOrDefault(o => o.Id == userId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseOrder(order),
				() => CheckUserBase(user),
				() => RequestResult.FromBoolean(user.RoleModel.HasRole(UserRole.ProjectManager), 403, "Пользователь не имеет роль проектного менеджера"),
				() =>
				{
					

					order.ProjectManagerId = userId;
					return UpdateModel(DB.Orders, order);
				}
			});
		}

		[HttpPut, Route("SetOrderTeamLead")]
		public async Task<RequestResult> SetOrderTeamLead(int orderId, int userId)
		{
			var order = DB.Orders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

			var user = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
							   .FirstOrDefault(o => o.Id == userId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseOrder(order),
				() => CheckUserBase(user),
				() => RequestResult.FromBoolean(user.RoleModel.HasRole(UserRole.TeamLead), 403, "Пользователь не имеет роль тим.лида"),
				() =>
				{
					order.TeamLeadId = userId;
					return UpdateModel(DB.Orders, order);
				}
			});
		}

		[HttpPut, Route("SetOrderTechLead")]
		public async Task<RequestResult> SetOrderTechLead(int orderId, int userId)
		{
			var order = DB.Orders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);

			var user = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
							   .FirstOrDefault(o => o.Id == userId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseOrder(order),
				() => CheckUserBase(user),
				() => RequestResult.FromBoolean(user.RoleModel.HasRole(UserRole.TechLead), 403, "Пользователь не имеет роль тех.лида"),
				() =>
				{
					order.TeamLeadId = userId;
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
		public RequestResult CheckUserBase(User user)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(user != null,404,"Пользователь с данным id не найден"),
				() => RequestResult.FromBoolean(user.BusinessId == this.BusinessId,403,"Нет доступа к данному пользователю"),
				//TODO: нельзя брать сотрудников из вышестоящих организаций

			});
		}

		#endregion

		#region Private 

		#endregion
	}
}
