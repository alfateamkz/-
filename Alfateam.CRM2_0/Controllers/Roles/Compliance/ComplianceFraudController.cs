using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceFraudController : AbsController
	{
		public ComplianceFraudController(ControllerParams @params) : base(@params)
		{
		}

		//TODO: добавить методы получения по цепочке вверх

		#region Описания способов мошенничества

		[HttpGet, Route("GetFraudDescriptions")]
		public async Task<RequestResult> GetFraudDescriptions(int offset, int count = 20)
		{
			var queryable = DB.FraudDescriptions.Include(o => o.Category)
												.Where(o => o.ComplianceDepartmentId == this.DepartmentId);

			return GetMany<FraudDescription, FraudDescriptionClientModel>(queryable, offset, count);
		}

		[HttpGet, Route("GetFraudDescription")]
		public async Task<RequestResult> GetFraudDescription(int id)
		{
			var item = DB.FraudDescriptions.Include(o => o.Category)
										   .Include(o => o.PreventionMethods)
										   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescription(item),
				() =>
				{
					 item.PreventionMethods = item.PreventionMethods.Where(o => !o.IsDeleted).ToList();
					 return RequestResult<FraudDescription>.AsSuccess(item);
				}
			});
		}

		[HttpPost, Route("CreateFraudDescription")]
		public async Task<RequestResult> CreateFraudDescription(FraudDescriptionCreateModel model)
		{
			var category = DB.FraudCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudCategory(category),
				() => TryCreateModel(DB.FraudDescriptions, model, (item) =>
				{
					item.ComplianceDepartmentId = (int)this.DepartmentId;
					return RequestResult<FraudDescription>.AsSuccess(item);
				})
			});
		}

		[HttpPut, Route("UpdateFraudDescription")]
		public async Task<RequestResult> UpdateFraudDescription(FraudDescriptionEditModel model)
		{
			var item = DB.FraudDescriptions.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			var category = DB.FraudCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescription(item),
				() => CheckBaseFraudCategory(category),
				() => TryUpdateModel(DB.FraudDescriptions, item, model)
			});
		}

		[HttpDelete, Route("DeleteFraudDescription")]
		public async Task<RequestResult> DeleteFraudDescription(int id)
		{
			var item = DB.FraudDescriptions.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescription(item),
				() => DeleteModel(DB.FraudDescriptions, item)
			});
		}

		#endregion

		#region Способы предотвращения мошенничества

		[HttpGet, Route("GetFraudDescriptionPreventionMethods")]
		public async Task<RequestResult> GetFraudDescriptionPreventionMethods(int descriptionId)
		{
			var item = DB.FraudDescriptions.Include(o => o.PreventionMethods)
										   .FirstOrDefault(o => o.Id == descriptionId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescription(item),
				() =>
				{
					var clientModels = FraudPreventionMethodClientModel.CreateItems(item.PreventionMethods.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<FraudPreventionMethodClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetFraudDescriptionPreventionMethod")]
		public async Task<RequestResult> GetFraudDescriptionPreventionMethod(int descriptionId,int methodId)
		{
			var item = DB.FraudDescriptions.FirstOrDefault(o => o.Id == descriptionId && !o.IsDeleted);
			var method = DB.FraudPreventionMethods.FirstOrDefault(o => o.Id == methodId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescriptionAndMethod(item,method),
				() => RequestResult<FraudPreventionMethod>.AsSuccess(method)
			});
		}



		[HttpPost, Route("CreateFraudDescriptionPreventionMethod")]
		public async Task<RequestResult> CreateFraudDescriptionPreventionMethod(int descriptionId, FraudPreventionMethodCreateModel model)
		{
			var item = DB.FraudDescriptions.FirstOrDefault(o => o.Id == descriptionId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescription(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var method = model.Create();
					item.PreventionMethods.Add(method);

					UpdateModel(DB.FraudDescriptions, item);
					return RequestResult<FraudPreventionMethod>.AsSuccess(method);
				}
			});
		}

		[HttpPut, Route("UpdateFraudDescriptionPreventionMethod")]
		public async Task<RequestResult> UpdateFraudDescriptionPreventionMethod(int descriptionId, FraudPreventionMethodEditModel model)
		{
			var item = DB.FraudDescriptions.FirstOrDefault(o => o.Id == descriptionId && !o.IsDeleted);
			var method = DB.FraudPreventionMethods.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescriptionAndMethod(item,method),
				() => TryUpdateModel(DB.FraudPreventionMethods,method,model)
			});
		}


		[HttpDelete, Route("DeleteFraudDescriptionPreventionMethod")]
		public async Task<RequestResult> DeleteFraudDescriptionPreventionMethod(int descriptionId, int methodId)
		{
			var item = DB.FraudDescriptions.FirstOrDefault(o => o.Id == descriptionId && !o.IsDeleted);
			var method = DB.FraudPreventionMethods.FirstOrDefault(o => o.Id == methodId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescriptionAndMethod(item,method),
				() => DeleteModel(DB.FraudPreventionMethods, method)
			});
		}


		#endregion

		#region Категории мошенничества 

		[HttpGet, Route("GetFraudCategories")]
		public async Task<RequestResult> GetFraudCategories(int offset, int count = 20)
		{
			var queryable = DB.FraudCategories.Where(o => o.ComplianceDepartmentId == this.DepartmentId);
			return GetMany<FraudCategory, FraudCategoryClientModel>(queryable, offset, count);
		}


		[HttpGet, Route("GetFraudCategory")]
		public async Task<RequestResult> GetFraudCategory(int id)
		{
			var category = DB.FraudCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudCategory(category),
				() => RequestResult<FraudCategory>.AsSuccess(category)
			});
		}




		[HttpPost, Route("CreateFraudCategory")]
		public async Task<RequestResult> CreateFraudCategory(FraudCategoryCreateModel model)
		{
			return TryCreateModel(DB.FraudCategories, model, (item) =>
			{
				item.ComplianceDepartmentId = (int)this.DepartmentId;
				return RequestResult<FraudCategory>.AsSuccess(item);
			});
		}



		[HttpPut, Route("UpdateFraudCategory")]
		public async Task<RequestResult> UpdateFraudCategory(FraudCategoryEditModel model)
		{
			var category = DB.FraudCategories.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudCategory(category),
				() => TryUpdateModel(DB.FraudCategories, category, model)
			});
		}


		[HttpDelete, Route("DeleteFraudCategory")]
		public async Task<RequestResult> DeleteFraudCategory(int id)
		{
			var category = DB.FraudCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudCategory(category),
				() => DeleteModel(DB.FraudCategories, category)
			});
		}



		#endregion





		#region Private check methods

		private RequestResult CheckBaseFraudCategory(FraudCategory category)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(category != null,404,"Категория с данным id не найдена"),
				() => RequestResult.FromBoolean(category.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данной категории"),
			});
		}
		private RequestResult CheckBaseFraudDescription(FraudDescription description)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(description != null,404,"Описание мошенничества с данным id не найдено"),
				() => RequestResult.FromBoolean(description.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному описанию мошенничества"),
			});
		}
		private RequestResult CheckBaseFraudDescriptionAndMethod(FraudDescription description,FraudPreventionMethod method)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseFraudDescription(description),
				() => RequestResult.FromBoolean(method != null,404,"Способ противодействия мошенничеству с данным id не найден"),
				() => RequestResult.FromBoolean(method.FraudDescriptionId == description.Id,403,"Способ противодействия мошенничеству не находится в описании мошенничества"),
			});
		}

		#endregion
	}
}
