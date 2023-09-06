using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.TestTasks;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.TestTasks;
using Alfateam.CRM2_0.Enums;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.TestTasks;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{

    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.HR)]
    public class HRTestTasksController : AbsController
    {
        public HRTestTasksController(ControllerParams @params) : base(@params)
        {
        }


        #region Тестовые задания

        [HttpGet, Route("GetTestTasks")]      
        public async Task<RequestResult> GetTestTasks(int candidateId, int interviewId,int offset, int count = 20)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
           
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () =>
                {
                    var interview = DB.CandidateInterviews.Include(o => o.TestTasks).FirstOrDefault(o => o.Id == interviewId);
                    if(interview.CandidateId != candidateId)
                    {
                        return RequestResult.AsError(403,"Данное тестовое задание не принадлежит кандидату");
                    }
                    return GetMany<CandidateTestTask,CandidateTestTaskClientModel>(interview.TestTasks,offset,count);
                }
            });
        }



        [HttpGet, Route("GetTestTask")]
        public async Task<RequestResult> GetTestTask(int candidateId, int taskId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
    
            var task = DB.CandidateTestTasks.Include(o => o.Answer).ThenInclude(o => o.Attachments)
                                            .FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () => RequestResult.FromBoolean(task != null, 404, "Тестовое задание с данным id не найдено"),
                () =>
                {
                    var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == task.CandidateInterviewId);
                    if(interview.CandidateId != candidateId)
                    {
                        return RequestResult.AsError(403,"Данное тестовое задание не принадлежит кандидату");
                    }
                    return RequestResult<CandidateTestTask>.AsSuccess(task);
                }
            });
        }



        [HttpPost, Route("CreateTestTask")]
        public async Task<RequestResult> CreateTestTask(int candidateId, int interviewId, CandidateTestTaskCreateModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
            var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () => RequestResult.FromBoolean(interview != null, 404, "Собеседование с данным id не найдено"),
                () => RequestResult.FromBoolean(interview.CandidateId == candidateId,403,"Данное собеседование не принадлежит кандидату"),
                () =>
                {
                    interview.TestTasks.Add(model.Create());
                    return UpdateModel(DB.CandidateInterviews,interview);
                }
            });
        }

        [HttpPut, Route("UpdateTestTask")]
        public async Task<RequestResult> UpdateTestTask(int candidateId, int taskId, CandidateTestTaskEditModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
            var task = DB.CandidateTestTasks.FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () => RequestResult.FromBoolean(task != null, 404, "Тестовое задание с данным id не найдено"),
                () =>
                {
                    var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == task.CandidateInterviewId);
                    if(interview.CandidateId != candidateId)
                    {
                        return RequestResult.AsError(403,"Данное тестовое задание не принадлежит кандидату");
                    }
                    return UpdateModel(DB.CandidateTestTasks, task, model);
                }
            });
        }

        [HttpDelete, Route("DeleteTestTask")]
        public async Task<RequestResult> DeleteTestTask(int candidateId, int taskId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
            var task = DB.CandidateTestTasks.FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
           {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () => RequestResult.FromBoolean(task != null, 404, "Тестовое задание с данным id не найдено"),
                () =>
                {
                    var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == task.CandidateInterviewId);
                    if(interview.CandidateId != candidateId)
                    {
                        return RequestResult.AsError(403,"Данное тестовое задание не принадлежит кандидату");
                    }
                    return DeleteModel(DB.CandidateTestTasks, task);
                }
            });
        }

        #endregion

      
    }
}
