using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer.LegalCases
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerLegalCaseRequestsController : AbsController
	{
		public LawyerLegalCaseRequestsController(ControllerParams @params) : base(@params)
		{
		}

		#region Запросы на юридическое дело

		[HttpGet, Route("GetActualLegalCaseRequests")]
		public async Task<RequestResult> GetActualLegalCaseRequests(int offset, int count = 20)
		{
			var requests = DB.LegalCaseRequests.Where(o => o.LawDepartmentId == DepartmentId
															! && o.IsDeleted
															&& o.ResultId == null)
											   .Include(o => o.From)
											   .Include(o => o.SecondSide)
											   .Skip(offset)
											   .Take(count)
											   .ToList();
			return RequestResult<IEnumerable<LegalCaseRequest>>.AsSuccess(requests);
		}

		[HttpGet, Route("GetHandledLegalCaseRequests")]
		public async Task<RequestResult> GetHandledLegalCaseRequests(LegalCaseRequestResultType type, int offset, int count = 20)
		{
			var requests = DB.LegalCaseRequests.Include(o => o.Result)
											   .Where(o => o.LawDepartmentId == DepartmentId
															! && o.IsDeleted
															&& o.ResultId != null)
											   .Include(o => o.From)
											   .Include(o => o.SecondSide)
											   .Where(o => o.Result.Type == type)
											   .Skip(offset)
											   .Take(count)
											   .ToList();
			return RequestResult<IEnumerable<LegalCaseRequest>>.AsSuccess(requests);
		}

		[HttpGet, Route("GetLegalCaseRequest")]
		public async Task<RequestResult> GetLegalCaseRequest(int id)
		{
			var request = DB.LegalCaseRequests.Include(o => o.From)
											  .Include(o => o.SecondSide)
											  .Include(o => o.Result)
											  .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseRequest(request),
				() => RequestResult<LegalCaseRequest>.AsSuccess(requests)
			});
		}



		[HttpPut, Route("SetLegalCaseRequestResult")]
		public async Task<RequestResult> SetLegalCaseRequestResult(int id, LegalCaseRequestResultCreateModel model)
		{
			var request = DB.LegalCaseRequests.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			var authorizedUser = GetAuthorizedUser();

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseRequest(request),
				() => RequestResult.FromBoolean(request.ResultId == null, 403, "Результат запроса уже был ранее задан"),
				() =>
				{
					request.Result = model.Create();

					if(request.Result.Type == LegalCaseRequestResultType.Approved)
					{
						request.Result.LegalCase = new LegalCase
						{
							CaseInfo = request.CaseInfo,
							SecondSideId = request.SecondSideId,
							CreatedById = authorizedUser.Id,
							LawDepartmentId = request.LawDepartmentId,
						};
					}

					return UpdateModel(DB.LegalCaseRequests, request);
				}
			});
		}

		#endregion




		#region Private check methods

		private RequestResult CheckBaseLegalCaseRequest(LegalCaseRequest request)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(request != null,404,"Сущность с данным id не найдена"),
				() => RequestResult.FromBoolean(request.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
			});
		}

		#endregion
	}
}
