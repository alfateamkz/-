using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerJudgesController : AbsController
	{
		public LawyerJudgesController(ControllerParams @params) : base(@params)
		{
		}

		#region Судьи

		[HttpGet, Route("GetJudges")]
		public async Task<RequestResult> GetJudges(int offset, int count = 20)
		{
			var queryable = DB.Judges.Include(o => o.Country).Where(o => o.LawDepartmentId == this.DepartmentId);
			return GetMany<Judge, JudgeClientModel>(queryable, offset, count);
		}


		[HttpGet, Route("GetJudge")]
		public async Task<RequestResult> GetJudge(int id)
		{
			var judge = DB.Judges.Include(o => o.Country).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseJudge(judge),
				() => RequestResult<Judge>.AsSuccess(judge)
			});
		}




		[HttpPost, Route("CreateJudge")]
		public async Task<RequestResult> CreateJudge(JudgeCreateModel model)
		{
			return TryCreateModel(DB.Judges, model, (item) =>
			{
				item.LawDepartmentId = (int)this.DepartmentId;
				return RequestResult<Judge>.AsSuccess(item);
			});
		}



		[HttpPut, Route("UpdateJudge")]
		public async Task<RequestResult> UpdateJudge(JudgeEditModel model)
		{

			var judge = DB.Judges.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseJudge(judge),
				() => TryUpdateModel(DB.Judges, judge, model)
			});
		}


		[HttpDelete, Route("DeleteJudge")]
		public async Task<RequestResult> DeleteJudge(int id)
		{
			var judge = DB.Judges.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseJudge(judge),
				() => DeleteModel(DB.Judges, judge)
			});
		}



		#endregion






		#region Private check methods

		private RequestResult CheckBaseJudge(Judge judge)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(judge != null,404,"Судья с данным id не найден"),
				() => RequestResult.FromBoolean(judge.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данному судье"),
			});
		}

		#endregion
	}
}
