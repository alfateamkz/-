using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Plan;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Plan;
using Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Plan;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.CRM2_0.Controllers.Roles.Sales
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Sales)]
	public class SalesPlanController : AbsController
    {

		//TODO: нельзя изменять, если планирование утверждено
        public SalesPlanController(ControllerParams @params) : base(@params)
        {
        }

		#region Планирование продаж 

		[HttpGet, Route("GetSalesPlannings")]
		public async Task<RequestResult> GetSalesPlannings(int offset, int count = 20)
		{
			var plannings = DB.SalesPlannings.Where(o => o.SalesDepartmentId == this.DepartmentId && !o.IsDeleted);
			return GetMany<SalesPlanning, SalesPlanningClientModel>(plannings, offset, count);
		}

		[HttpGet, Route("GetSalesPlanning")]
		public async Task<RequestResult> GetSalesPlanning(int id)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanning(item),
				() => RequestResult<SalesPlanning>.AsSuccess(item)
			});
		}





		[HttpPost, Route("CreateSalesPlanning")]
		public async Task<RequestResult> CreateSalesPlanning(SalesPlanningCreateModel model)
		{
			var plannings = DB.SalesPlannings.Where(o => o.SalesDepartmentId == this.DepartmentId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(!plannings.Any(o => o.IsInPeriod(model.StartDate)),403,"Планирование продаж уже имеется в данном диапазоне дат"),
				() => RequestResult.FromBoolean(!plannings.Any(o => o.IsInPeriod(model.EndDate)),403,"Планирование продаж уже имеется в данном диапазоне дат"),
				() => TryCreateModel(DB.SalesPlannings, model, (item) =>
				{
					item.Plans.Add(new SalesPlan()
					{
						Title = "План-минимум"
					});
					item.Plans.Add(new SalesPlan()
					{
						Title = "Основной план"
					});
					item.Plans.Add(new SalesPlan()
					{
						Title = "План-максимум"
					});

					item.SalesDepartmentId = (int)this.DepartmentId;
					return RequestResult<SalesPlanning>.AsSuccess(item);
				})
			});
		}

		[HttpPut, Route("UpdateSalesPlanning")]
		public async Task<RequestResult> UpdateSalesPlanning(SalesPlanningEditModel model)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanning(item),
				() => TryUpdateModel(DB.SalesPlannings, item, model)
			});
		}

		[HttpDelete, Route("DeleteSalesPlanning")]
		public async Task<RequestResult> DeleteSalesPlanning(int id)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanning(item),
				() => DeleteModel(DB.SalesPlannings, item)
			});
		}

		#endregion

		#region Планы продаж 


		[HttpGet, Route("GetSalesPlanningPlans")]
		public async Task<RequestResult> GetSalesPlanningPlans(int planningId)
		{
			var item = DB.SalesPlannings.Include(o => o.Plans)
										.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanning(item),
				() =>
				{
					var clientModels = SalesPlanClientModel.CreateItems(item.Plans.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<SalesPlanClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetSalesPlanningPlan")]
		public async Task<RequestResult> GetSalesPlanningPlan(int planningId, int planId)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);
			var plan = DB.SalesPlans.FirstOrDefault(o => o.Id == planId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlan(item, plan),
				() =>
				{
					var clientModel = SalesPlanClientModel.Create(plan);
					return RequestResult<SalesPlanClientModel>.AsSuccess(clientModel);
				}
			});
		}





		[HttpPost, Route("CreateSalesPlanningPlan")]
		public async Task<RequestResult> CreateSalesPlanningPlan(int planningId, SalesPlanCreateModel model)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanning(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var plan = model.Create();
					item.Plans.Add(plan);

					UpdateModel(DB.SalesPlannings, item);
					return RequestResult<SalesPlan>.AsSuccess(plan);
				}
			});
		}

		[HttpPut, Route("UpdateSalesPlanningPlan")]
		public async Task<RequestResult> UpdateSalesPlanningPlan(int planningId, SalesPlanEditModel model)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);
			var plan = DB.SalesPlans.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);


			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlan(item, plan),
				() => TryUpdateModel(DB.SalesPlans, plan, model)
			});
		}

		[HttpDelete, Route("DeleteSalesPlanningPlan")]
		public async Task<RequestResult> DeleteSalesPlanningPlan(int planningId, int planId)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);
			var plan = DB.SalesPlans.FirstOrDefault(o => o.Id == planId && !o.IsDeleted);


			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlan(item, plan),
				() => DeleteModel(DB.SalesPlans, plan)
			});
		}

		#endregion

		#region Пункты плана продаж 

		[HttpGet, Route("GetSalesPlanningPlanItems")]
		public async Task<RequestResult> GetSalesPlanningPlanItems(int planningId, int planId)
		{
			var item = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);

			var plan = DB.SalesPlans.Include(o => o.Items)
								    .FirstOrDefault(o => o.Id == planId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlan(item, plan),
				() =>
				{
					var clientModels = SalesPlanItemClientModel.CreateItems(plan.Items.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<SalesPlanItemClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetSalesPlanningPlanItem")]
		public async Task<RequestResult> GetSalesPlanningPlanItem(int planningId, int planId, int itemId)
		{
			var planning = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);
			var plan = DB.SalesPlans.FirstOrDefault(o => o.Id == planId && !o.IsDeleted);
			var item = DB.SalesPlanItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlanItem(planning, plan, item),
				() =>
				{
					var clientModel = SalesPlanItemClientModel.Create(item);
					return RequestResult<SalesPlanItemClientModel>.AsSuccess(clientModel);
				}
			});
		}





		[HttpPost, Route("CreateSalesPlanningPlanItem")]
		public async Task<RequestResult> CreateSalesPlanningPlanItem(int planningId, int planId, SalesPlanItemCreateModel model)
		{
			var planning = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);
			var plan = DB.SalesPlans.FirstOrDefault(o => o.Id == planId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlan(planning, plan),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var item = model.Create();
					plan.Items.Add(item);

					UpdateModel(DB.SalesPlans, plan);
					return RequestResult<SalesPlanItem>.AsSuccess(item);
				}
			});
		}

		[HttpPut, Route("UpdateSalesPlanningPlanItem")]
		public async Task<RequestResult> UpdateSalesPlanningPlanItem(int planningId, int planId, SalesPlanEditModel model)
		{
			var planning = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);
			var plan = DB.SalesPlans.FirstOrDefault(o => o.Id == planId && !o.IsDeleted);
			var item = DB.SalesPlanItems.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlanItem(planning, plan, item),
				() => TryUpdateModel(DB.SalesPlanItems, item, model)
			});
		}

		[HttpDelete, Route("DeleteSalesPlanningPlanItem")]
		public async Task<RequestResult> DeleteSalesPlanningPlanItem(int planningId, int planId, int itemId)
		{
			var planning = DB.SalesPlannings.FirstOrDefault(o => o.Id == planningId && !o.IsDeleted);
			var plan = DB.SalesPlans.FirstOrDefault(o => o.Id == planId && !o.IsDeleted);
			var item = DB.SalesPlanItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlanItem(planning, plan, item),
				() => DeleteModel(DB.SalesPlanItems, item)
			});
		}

		#endregion






		#region Private other methods

		private RequestResult CheckBaseSalesPlanning(SalesPlanning planning)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(planning != null,404,"Планирование продаж  с данным id не найдено"),
				() => RequestResult.FromBoolean(planning.SalesDepartmentId == this.DepartmentId,403,"Нет доступа к данной планированию продаж"),
			});
		}
		private RequestResult CheckBaseSalesPlanningAndPlan(SalesPlanning planning, SalesPlan plan)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanning(planning),
				() => RequestResult.FromBoolean(plan != null,404,"План продаж с данным id не найден"),
				() => RequestResult.FromBoolean(plan.SalesPlanningId == planning.Id,403,"План продаж не принадлежит текущему планированию продаж"),
			});
		}
		private RequestResult CheckBaseSalesPlanningAndPlanItem(SalesPlanning planning, SalesPlan plan, SalesPlanItem item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesPlanningAndPlan(planning, plan),
				() => RequestResult.FromBoolean(item != null,404,"Пункт плана продаж с данным id не найден"),
				() => RequestResult.FromBoolean(item.SalesPlanId == plan.Id,403,"Пункт плана продаж не принадлежит текущему плану продаж"),
			});
		}

		#endregion
	}
}
