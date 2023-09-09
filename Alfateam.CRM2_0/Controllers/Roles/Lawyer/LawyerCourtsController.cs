using Accord;
using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Content.Education.Courses;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerCourtsController : AbsController
	{
		public LawyerCourtsController(ControllerParams @params) : base(@params)
		{
		}


		#region Суды

		[HttpGet, Route("GetCourts")]
		public async Task<RequestResult> GetCourts(int offset, int count = 20)
		{
			var queryable = DB.Courts.Include(o => o.Address)
								     .Include(o => o.Structure)
									 .Where(o => o.LawDepartmentId == this.DepartmentId);
			return GetMany<Court, CourtClientModel>(queryable, offset, count);
		}


		[HttpGet, Route("GetCourt")]
		public async Task<RequestResult> GetCourt(int id)
		{
			var court = DB.Courts.Include(o => o.Address)
								 .Include(o => o.Structure)
							     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseCourt(court),
				() => RequestResult<Court>.AsSuccess(court)
			});
		}




		[HttpPost, Route("CreateCourt")]
		public async Task<RequestResult> CreateCourt(CourtCreateModel model)
		{
			return TryCreateModel(DB.Courts, model, (item) =>
			{
				item.LawDepartmentId = (int)this.DepartmentId;
				return RequestResult<Court>.AsSuccess(item);
			});
		}



		[HttpPut, Route("UpdateCourt")]
		public async Task<RequestResult> UpdateCourt(CourtEditModel model)
		{
			var court = DB.Courts.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseCourt(court),
				() => TryUpdateModel(DB.Courts, court, model)
			});
		}


		[HttpDelete, Route("DeleteCourt")]
		public async Task<RequestResult> DeleteCourt(int id)
		{
			var court = DB.Courts.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseCourt(court),
				() => DeleteModel(DB.Courts, court)
			});
		}



		#endregion





		#region Private check methods

		private RequestResult CheckBaseCourt(Court court)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(court != null,404,"Суд с данным id не найден"),
				() => RequestResult.FromBoolean(court.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данному суду"),
			});
		}

		#endregion

	}
}
