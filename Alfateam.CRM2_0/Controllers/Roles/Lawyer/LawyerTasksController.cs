using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Lawyer)]
    public class LawyerTasksController : AbsController
    {
        public LawyerTasksController(ControllerParams @params) : base(@params)
        {
        }

		#region Поручения юристам

		[HttpGet, Route("GetLawyerTasks")]
		public async Task<RequestResult> GetLawyerTasks(LawyerTaskStatus status, int offset, int count = 20)
		{
			var tasks = DB.LawyerTask.Where(o => o.LawDepartmentId == DepartmentId 
												 && !o.IsDeleted 
												 && o.Status == status)
									 .Include(o => o.SecondSide)
									 .Include(o => o.Order)
									 .Include(o => o.CreatedBy)
									 .Include(o => o.AcceptedBy);

			return GetMany<LawyerTask,LawyerTaskClientModel>(tasks, offset, count);
		}

		[HttpGet, Route("GetLawyerTask")]
		public async Task<RequestResult> GetLawyerTask(int id)
		{
			var task = DB.LawyerTask.Where(o =>  !o.IsDeleted)
									.Include(o => o.SecondSide)
									.Include(o => o.Order)
									.Include(o => o.CreatedBy)
								    .Include(o => o.AcceptedBy)
									.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
		    {
				() => CheckBaseLawyerTask(task),
				() => RequestResult<LawyerTask>.AsSuccess(task)
			});
		}



		[HttpPut, Route("SetLawyerTaskStatus")]
		public async Task<RequestResult> SetLawyerTaskStatus(int id, LawyerTaskStatus status)
		{
			var task = DB.LawyerTask.FirstOrDefault(o => o.Id == id);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLawyerTask(task),
				() =>
				{
					task.Status = status;
					return UpdateModel(DB.LawyerTask, task);
				}
			});
		}


		#endregion





		#region Private check methods
		private RequestResult CheckBaseLawyerTask(LawyerTask task)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(task != null,404,"Сущность с данным id не найдена"),
				() => RequestResult.FromBoolean(task.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
			});
		}

		#endregion


	}
}
