using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Enums;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.TestTasks;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{
    [AccessActionFilter(roles: UserRole.Candidate)]
    public class HRForCandidateController : AbsController
    {
        public HRForCandidateController(ControllerParams @params) : base(@params)
        {
        }

        #region Собеседования - получение по роли кандидата

        [HttpGet, Route("GetInterviewsAsCandidate")]
        public async Task<RequestResult> GetInterviewsAsCandidate(int offset, int count = 20)
        {
            var candidate = GetAuthorizedUser() as Candidate;

            return TryFinishAllRequestes(new[]
            {
                () =>
                {
                    var interviews = DB.CandidateInterviews.Where(o => o.CandidateId == candidate.Id
                                                                    && !o.IsDeleted)
                                                           .ToList();
                    return GetMany<CandidateInterview,CandidateInterviewClientModel>(interviews,offset,count);
                }
            });
        }


        [HttpGet, Route("GetInterviewAsCandidate")]
        public async Task<RequestResult> GetInterviewAsCandidate(int interviewId)
        {
            var candidate = GetAuthorizedUser() as Candidate;

            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .Include(o => o.Decision)
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(interview != null, 404, "Собеседование с данным id не найдено"),
                () => RequestResult.FromBoolean(interview.CandidateId == candidate.Id, 403, "Данное собеседование не принадлежит кандидату"),
                () => RequestResult<CandidateInterview>.AsSuccess(interview)
            });
        }

        #endregion

        #region Тестовые задания - получение по роли кандидата

        [HttpGet, Route("GetTestTasksAsCandidate")]
        public async Task<RequestResult> GetTestTasksAsCandidate(int interviewId, int offset, int count = 20)
        {
            var candidate = GetAuthorizedUser() as Candidate;
            var interview = DB.CandidateInterviews.Include(o => o.TestTasks).FirstOrDefault(o => o.Id == interviewId);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(interview != null, 404, "Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(interview.CandidateId != candidate.Id, 403, "Данное тестовое задание не принадлежит кандидату"),
                () => GetMany<CandidateTestTask,CandidateTestTaskClientModel>(interview.TestTasks,offset,count)
            });
        }



        [HttpGet, Route("GetTestTaskAsCandidate")]
        public async Task<RequestResult> GetTestTaskAsCandidate(int taskId)
        {
            var candidate = GetAuthorizedUser() as Candidate;

            var task = DB.CandidateTestTasks.Include(o => o.Answer).ThenInclude(o => o.Attachments)
                                            .FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(task != null, 404, "Тестовое задание с данным id не найдено"),
                () =>
                {
                    var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == task.CandidateInterviewId);
                    if(interview.CandidateId != candidate.Id)
                    {
                        return RequestResult.AsError(403,"Данное тестовое задание не принадлежит кандидату");
                    }
                    return RequestResult<CandidateTestTask>.AsSuccess(task);
                }
            });
        }


        #endregion

        #region Ответы на тестовое задание 

        [HttpPost, Route("SetTestTaskAnswer")]
        public async Task<RequestResult> SetTestTaskAnswer(int taskId, CandidateTestTaskAnswer answer)
        {
            var candidate = GetAuthorizedUser();
            var task = DB.CandidateTestTasks.FirstOrDefault(o => o.Id == taskId);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate.RoleModel.HasRole(UserRole.Candidate), 403, "Только кандидат может дать ответ на тестовое задание"),
                () => RequestResult.FromBoolean(task != null, 404, "Тестовое задание с данным id не найдено"),
                () => RequestResult.FromBoolean(task.AnswerId == null, 403, "Нельзя дать ответ повторно"),
                () =>
                {
                    var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == task.CandidateInterviewId);
                    if(interview.CandidateId != candidate.Id)
                    {
                        return RequestResult.AsError(403,"Данное тестовое задание не принадлежит кандидату");
                    }

                    answer.Attachments.Clear(); //А то вдруг захотят сюда что-то запихнуть

                    foreach(var attachmentFile in Request.Form.Files)
                    {
                         var uploadFileResult = TryUploadFile(attachmentFile, FileType.Any).Result;
                         if(!uploadFileResult.Success) return uploadFileResult;

                         answer.Attachments.Add(new CandidateTestTaskAnswerAttachment
                         {
                             Filepath = uploadFileResult.Value
                         });
                    }

                    task.Answer = answer;
                    return UpdateModel(DB.CandidateTestTasks,task);
                }
            });
        }

        #endregion






    }
}
