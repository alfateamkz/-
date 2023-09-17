using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Roles.Compliance.Law;
using Microsoft.AspNetCore.Mvc;


namespace Alfateam.CRM2_0.Controllers.Roles.Compliance
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceLawController : AbsController
	{
		public ComplianceLawController(ControllerParams @params) : base(@params)
		{
		}

		#region Запрещенные услуги

		[HttpGet, Route("GetProhibitedServices")]
		public async Task<RequestResult> GetProhibitedServices(int offset, int count = 20)
		{
			var queryable = DB.ProhibitedServices.Where(o => o.ComplianceDepartmentId == this.DepartmentId);
			return GetMany<ProhibitedService, ProhibitedServiceClientModel>(queryable, offset, count);
		}

		[HttpGet, Route("GetProhibitedService")]
		public async Task<RequestResult> GetProhibitedService(int id)
		{
			var item = DB.ProhibitedServices.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseProhibitedService(item),
				() => RequestResult<ProhibitedService>.AsSuccess(item)
			});
		}




		[HttpPost, Route("CreateProhibitedService")]
		public async Task<RequestResult> CreateProhibitedService(ProhibitedServiceCreateModel model)
		{
			return TryCreateModel(DB.ProhibitedServices, model, (item) =>
			{
				item.ComplianceDepartmentId = (int)this.DepartmentId;
				return RequestResult<ProhibitedService>.AsSuccess(item);
			});
		}

		[HttpPut, Route("UpdateProhibitedService")]
		public async Task<RequestResult> UpdateProhibitedService(ProhibitedServiceEditModel model)
		{
			var item = DB.ProhibitedServices.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseProhibitedService(item),
				() => TryUpdateModel(DB.ProhibitedServices, item, model)
			});
		}

		[HttpDelete, Route("DeleteProhibitedService")]
		public async Task<RequestResult> DeleteProhibitedService(int id)
		{
			var item = DB.ProhibitedServices.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseProhibitedService(item),
				() => DeleteModel(DB.ProhibitedServices, item)
			});
		}


		#endregion




		#region Private check methods

		private RequestResult CheckBaseProhibitedService(ProhibitedService item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(item != null,404,"Услуга с данным id не найдена"),
				() => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данной услуге"),
			});
		}

		#endregion

	}
}
