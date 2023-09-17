using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceRequirementsController : AbsController
    {
        public ComplianceRequirementsController(ControllerParams @params) : base(@params)
        {
        }

		#region Категории требований соответствия

		[HttpGet, Route("GetComplianceRequirementsCategories")]
		public async Task<RequestResult> GetComplianceRequirementsCategories(int offset, int count = 20)
		{
			var queryable = DB.ComplianceRequirementsCategories.Where(o => o.ComplianceDepartmentId == this.DepartmentId);
			return GetMany<ComplianceRequirementsCategory, ComplianceRequirementsCategoryClientModel>(queryable, offset, count);
		}


		[HttpGet, Route("GetComplianceRequirementsCategory")]
		public async Task<RequestResult> GetComplianceRequirementsCategory(int id)
		{
			var category = DB.ComplianceRequirementsCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsCategory(category),
				() => RequestResult<ComplianceRequirementsCategory>.AsSuccess(category)
			});
		}




		[HttpPost, Route("CreateComplianceRequirementsCategory")]
		public async Task<RequestResult> CreateComplianceRequirementsCategory(ComplianceRequirementsCategoryCreateModel model)
		{
			return TryCreateModel(DB.ComplianceRequirementsCategories, model, (item) =>
			{
				item.ComplianceDepartmentId = (int)this.DepartmentId;
				return RequestResult<ComplianceRequirementsCategory>.AsSuccess(item);
			});
		}



		[HttpPut, Route("UpdateComplianceRequirementsCategory")]
		public async Task<RequestResult> UpdateComplianceRequirementsCategory(ComplianceRequirementsCategoryEditModel model)
		{
			var category = DB.ComplianceRequirementsCategories.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsCategory(category),
				() => TryUpdateModel(DB.ComplianceRequirementsCategories, category, model)
			});
		}


		[HttpDelete, Route("DeleteComplianceRequirementsCategory")]
		public async Task<RequestResult> DeleteComplianceRequirementsCategory(int id)
		{
			var category = DB.ComplianceRequirementsCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsCategory(category),
				() => DeleteModel(DB.ComplianceRequirementsCategories, category)
			});
		}


		#endregion

		#region Требования соответствия

		[HttpGet, Route("GetComplianceRequirements")]
		public async Task<RequestResult> GetComplianceRequirements(int offset, int count = 20)
		{
			var queryable = DB.ComplianceRequirements.Include(o => o.Category)
													 .Where(o => o.ComplianceDepartmentId == this.DepartmentId);

			return GetMany<ComplianceRequirements, ComplianceRequirementsClientModel>(queryable, offset, count);
		}

		[HttpGet, Route("GetComplianceRequirement")]
		public async Task<RequestResult> GetComplianceRequirement(int id)
		{
			var item = DB.ComplianceRequirements.Include(o => o.Category)
													.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirements(item),
				() => RequestResult<ComplianceRequirements>.AsSuccess(item)
			});
		}




		[HttpPost, Route("CreateComplianceRequirements")]
		public async Task<RequestResult> CreateComplianceRequirements(ComplianceRequirementsCreateModel model)
		{
			var category = DB.ComplianceRequirementsCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsCategory(category),
				() => TryCreateModel(DB.ComplianceRequirements, model, (item) =>
				{
					item.ComplianceDepartmentId = (int)this.DepartmentId;
					return RequestResult<ComplianceRequirements>.AsSuccess(item);
				})
			});
		}

		[HttpPut, Route("UpdateComplianceRequirements")]
		public async Task<RequestResult> UpdateComplianceRequirements(ComplianceRequirementsEditModel model)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			var category = DB.ComplianceRequirementsCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirements(item),
				() => CheckBaseComplianceRequirementsCategory(category),
				() => TryUpdateModel(DB.ComplianceRequirements, item, model)
			});
		}

		[HttpDelete, Route("DeleteComplianceRequirements")]
		public async Task<RequestResult> DeleteComplianceRequirements(int id)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirements(item),
				() => DeleteModel(DB.ComplianceRequirements, item)
			});
		}

		#endregion

		#region Группы критерий внутри требования соответствия

		[HttpGet, Route("GetComplianceRequirementsCriteriaGroups")]
		public async Task<RequestResult> GetComplianceRequirementsCriteriaGroups(int requirementId)
		{
			var item = DB.ComplianceRequirements.Include(o => o.Groups)
												.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirements(item),
				() =>
				{
					var clientModels = ComplianceCriteriaGroupClientModel.CreateItems(item.Groups.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<ComplianceCriteriaGroupClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetComplianceRequirementsCriteriaGroup")]
		public async Task<RequestResult> GetComplianceRequirementsCriteriaGroup(int requirementId, int groupId)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);
			var group = DB.ComplianceCriteriaGroups.FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndGroup(item,group),
				() =>
				{
					var clientModel = ComplianceCriteriaGroupClientModel.Create(group);
					return RequestResult<ComplianceCriteriaGroupClientModel>.AsSuccess(clientModel);
				}
			});
		}



		[HttpPost, Route("CreateComplianceRequirementsCriteriaGroup")]
		public async Task<RequestResult> CreateComplianceRequirementsCriteriaGroup(int requirementId, ComplianceCriteriaGroupCreateModel model)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirements(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполения полей"),
				() =>
				{
					var group = model.Create();
					item.Groups.Add(group);

					UpdateModel(DB.ComplianceRequirements, item);
					return RequestResult<ComplianceCriteriaGroup>.AsSuccess(group);
				}
			});
		}

		[HttpPut, Route("UpdateComplianceRequirementsCriteriaGroup")]
		public async Task<RequestResult> UpdateComplianceRequirementsCriteriaGroup(int requirementId, ComplianceCriteriaGroupEditModel model)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);
			var group = DB.ComplianceCriteriaGroups.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndGroup(item,group),
				() => TryUpdateModel(DB.ComplianceCriteriaGroups, group, model)
			});
		}

		[HttpDelete, Route("DeleteComplianceRequirementsCriteriaGroup")]
		public async Task<RequestResult> DeleteComplianceRequirementsCriteriaGroup(int requirementId, int groupId)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);
			var group = DB.ComplianceCriteriaGroups.FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndGroup(item,group),
				() => DeleteModel(DB.ComplianceCriteriaGroups, group)
			});
		}

		#endregion

		#region Критерии соответствия

		[HttpGet, Route("GetComplianceRequirementsCriterias")]
		public async Task<RequestResult> GetComplianceRequirementsCriteriaGroups(int requirementId, int groupId)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);

			var group = DB.ComplianceCriteriaGroups.Include(o => o.Criterias)
												   .FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndGroup(item,group),
				() =>
				{
					var clientModels = ComplianceCriteriaClientModel.CreateItems(group.Criterias.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<ComplianceCriteriaClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetComplianceRequirementsCriteria")]
		public async Task<RequestResult> GetComplianceRequirementsCriteria(int requirementId, int groupId, int criteriaId)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);
			var group = DB.ComplianceCriteriaGroups.FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);
			var criteria = DB.ComplianceCriterias.FirstOrDefault(o => o.Id == criteriaId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndCriteria(item,group,criteria),
				() =>
				{
					var clientModel = ComplianceCriteriaClientModel.Create(criteria);
					return RequestResult<ComplianceCriteriaClientModel>.AsSuccess(clientModel);
				}
			});
		}



		[HttpPost, Route("CreateComplianceRequirementsCriteria")]
		public async Task<RequestResult> CreateComplianceRequirementsCriteriaGroup(int requirementId, int groupId, ComplianceCriteriaCreateModel model)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);
			var group = DB.ComplianceCriteriaGroups.FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndGroup(item,group),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполения полей"),
				() =>
				{
					var criteria = model.Create();
					group.Criterias.Add(criteria);

					UpdateModel(DB.ComplianceCriterias, item);
					return RequestResult<ComplianceCriteria>.AsSuccess(criteria);
				}
			});
		}

		[HttpPut, Route("UpdateComplianceRequirementsCriteria")]
		public async Task<RequestResult> UpdateComplianceRequirementsCriteria(int requirementId, int groupId, ComplianceCriteriaEditModel model)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);
			var group = DB.ComplianceCriteriaGroups.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			var criteria = DB.ComplianceCriterias.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndCriteria(item,group,criteria),
				() => TryUpdateModel(DB.ComplianceCriterias, criteria, model)
			});
		}
		
		[HttpDelete, Route("DeleteComplianceRequirementsCriteria")]
		public async Task<RequestResult> DeleteComplianceRequirementsCriteria(int requirementId, int groupId, int criteriaId)
		{
			var item = DB.ComplianceRequirements.FirstOrDefault(o => o.Id == requirementId && !o.IsDeleted);
			var group = DB.ComplianceCriteriaGroups.FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);
			var criteria = DB.ComplianceCriterias.FirstOrDefault(o => o.Id == criteriaId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndCriteria(item,group,criteria),
				() => DeleteModel(DB.ComplianceCriterias, criteria)
			});
		}


		#endregion











		#region Private check methods

		private RequestResult CheckBaseComplianceRequirements(ComplianceRequirements item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(item != null,404,"Требования соответствия с данным id не найдены"),
				() => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данным требованиям соответствия"),
			});
		}
		private RequestResult CheckBaseComplianceRequirementsAndGroup(ComplianceRequirements item, ComplianceCriteriaGroup group)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirements(item),
				() => RequestResult.FromBoolean(group != null,404,"Группа критерий с данным id не найдена"),
				() => RequestResult.FromBoolean(group.ComplianceRequirementsId == item.Id,403,"Группа критерий не принадлежит данным требованиям соответствия"),
			});
		}
		private RequestResult CheckBaseComplianceRequirementsAndCriteria(ComplianceRequirements item, ComplianceCriteriaGroup group, ComplianceCriteria criteria)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseComplianceRequirementsAndGroup(item,group),
				() => RequestResult.FromBoolean(criteria != null,404,"Критерий с данным id не найден"),
				() => RequestResult.FromBoolean(criteria.ComplianceCriteriaGroupId == group.Id,403,"Критерий не принадлежит данным требованиям соответствия"),
			});
		}



		private RequestResult CheckBaseComplianceRequirementsCategory(ComplianceRequirementsCategory category)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(category != null,404,"Категория с данным id не найдена"),
				() => RequestResult.FromBoolean(category.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данной категории"),
			});
		}

		#endregion
	}
}
