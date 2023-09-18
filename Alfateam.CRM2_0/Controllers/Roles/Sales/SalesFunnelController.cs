using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.EditModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Sales
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Sales)]
	public class SalesFunnelController : AbsController
    {
        public SalesFunnelController(ControllerParams @params) : base(@params)
        {
        }

		#region Воронки продаж

		[HttpGet, Route("GetSalesFunnels")]
		public async Task<RequestResult> GetSalesFunnels(int offset, int count = 20)
		{
			var queryable = DB.SalesFunnels.Where(o => o.SalesDepartmentId == this.DepartmentId);
			return GetMany<SalesFunnel, SalesFunnelClientModel>(queryable, offset, count);
		}

		[HttpGet, Route("GetSalesFunnel")]
		public async Task<RequestResult> GetSalesFunnel(int id)
		{
			var item = DB.SalesFunnels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnel(item),
				() => RequestResult<SalesFunnel>.AsSuccess(item)
			});
		}




		[HttpPost, Route("CreateSalesFunnel")]
		public async Task<RequestResult> CreateSalesFunnel(SalesFunnelCreateModel model)
		{
			return TryCreateModel(DB.SalesFunnels, model, (item) =>
			{
				item.SalesDepartmentId = (int)this.DepartmentId;
				return RequestResult<SalesFunnel>.AsSuccess(item);
			});
		}

		[HttpPut, Route("UpdateSalesFunnel")]
		public async Task<RequestResult> UpdateSalesFunnel(SalesFunnelEditModel model)
		{
			var item = DB.SalesFunnels.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnel(item),
				() => TryUpdateModel(DB.SalesFunnels, item, model)
			});
		}

		[HttpDelete, Route("DeleteSalesFunnel")]
		public async Task<RequestResult> DeleteSalesFunnel(int id)
		{
			var item = DB.SalesFunnels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnel(item),
				() => DeleteModel(DB.SalesFunnels, item)
			});
		}

		#endregion

		#region Этапы воронки продаж

		[HttpGet, Route("GetSalesFunnelStages")]
		public async Task<RequestResult> GetSalesFunnelStages(int funnelId)
		{
			var item = DB.SalesFunnels.Include(o => o.Stages)
									  .FirstOrDefault(o => o.Id == funnelId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnel(item),
				() =>
				{
					var clientModels = SalesFunnelStageClientModel.CreateItems(item.Stages);
					return RequestResult<IEnumerable<SalesFunnelStageClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetSalesFunnelStage")]
		public async Task<RequestResult> GetSalesFunnelStage(int funnelId, int stageId)
		{
			var item = DB.SalesFunnels.FirstOrDefault(o => o.Id == funnelId && !o.IsDeleted);
			var stage = DB.SalesFunnelStages.FirstOrDefault(o => o.Id == stageId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnelAndStage(item, stage),
				() =>
				{
					var clientModel = SalesFunnelStageClientModel.Create(stage);
					return RequestResult<SalesFunnelStageClientModel>.AsSuccess(clientModel);
				}
			});
		}




		[HttpPost, Route("CreateSalesFunnelStage")]
		public async Task<RequestResult> CreateSalesFunnelStage(int funnelId, SalesFunnelStageCreateModel model)
		{
			var item = DB.SalesFunnels.FirstOrDefault(o => o.Id == funnelId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnel(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполения полей"),
				() =>
				{
					var stage = model.Create();
					item.Stages.Add(stage);

					UpdateModel(DB.SalesFunnels, item);
					return RequestResult<SalesFunnelStage>.AsSuccess(stage);
				}
			});
		}

		[HttpPut, Route("UpdateSalesFunnelStage")]
		public async Task<RequestResult> UpdateSalesFunnelStage(int funnelId, SalesFunnelStageEditModel model)
		{
			var item = DB.SalesFunnels.FirstOrDefault(o => o.Id == funnelId && !o.IsDeleted);
			var stage = DB.SalesFunnelStages.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnelAndStage(item, stage),
				() => TryUpdateModel(DB.SalesFunnelStages, stage, model)
			});
		}

		[HttpDelete, Route("DeleteSalesFunnelStage")]
		public async Task<RequestResult> DeleteSalesFunnelStage(int funnelId, int stageId)
		{
			var item = DB.SalesFunnels.FirstOrDefault(o => o.Id == funnelId && !o.IsDeleted);
			var stage = DB.SalesFunnelStages.FirstOrDefault(o => o.Id == stageId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseSalesFunnelAndStage(item, stage),
				() => DeleteModel(DB.SalesFunnelStages, stage)
			});
		}

		#endregion



		#region Private check methods

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
