using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.TestTasks;
using Alfateam.CRM2_0.Models.Content.Feedback;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.HR)]
    public class HRInterviewsController : AbsController
    {
        public HRInterviewsController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: добавить методы получения по цепочке вверх

        #region Собеседования с кандидатами

        [HttpGet, Route("GetInterviews")]
        public async Task<RequestResult> GetInterviews(int candidateId, int offset, int count = 20)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () =>
                {
                    var interviews = DB.CandidateInterviews.Where(o => o.CandidateId == candidateId 
                                                                    && !o.IsDeleted)
                                                           .ToList();
                   
                    return GetMany<CandidateInterview,CandidateInterviewClientModel>(interviews,offset,count);
                }
            });
        }

        [HttpGet, Route("GetInterview")]
        public async Task<RequestResult> GetInterview(int candidateId, int interviewId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
           
            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .Include(o => o.Decision)
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => RequestResult<CandidateInterview>.AsSuccess(interview)
            });
        }
       


        [HttpPost, Route("CreateInterview")]
        public async Task<RequestResult> CreateInterview(int candidateId, CandidateInterviewCreateModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () =>
                {
                    var interview = model.Create();
                    if(interview.Call == null)
                    {
                        return RequestResult.AsError(400,"Необходимо назначить созвон");
                    }

                   
                    candidate.Interviews.Add(interview);
                    return UpdateModel(DB.Users,candidate);
                }
            });
        }

        [HttpPut, Route("UpdateInterview")]
        public async Task<RequestResult> UpdateInterview(int candidateId, CandidateInterviewEditModel model)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
            var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => UpdateModel(DB.CandidateInterviews, interview,model)
            });
        }


        [HttpDelete, Route("DeleteInterview")]
        public async Task<RequestResult> DeleteInterview(int candidateId, int interviewId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
            var interview = DB.CandidateInterviews.FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => DeleteModel(DB.CandidateInterviews, interview)
            });
        }

        #endregion

        #region Созвоны с кандидатами в рамках собеседования


        [HttpPut, Route("StartInterviewCall")]
        public async Task<RequestResult> StartInterviewCall(int candidateId,int interviewId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;
           
            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => RequestResult.FromBoolean(interview.Call.StartedAt == null, 400, "Звонок уже начат"),
                () =>
                {
                    interview.Call.StartedAt = DateTime.UtcNow;
                    interview.Call.Status = CandidateCallStatus.Active;
                    return UpdateModel(DB.CandidateInterviews,interview);
                }
            });
        }

        [HttpPut, Route("FinishInterviewCall")]
        public async Task<RequestResult> FinishInterviewCall(int candidateId, int interviewId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;

            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => RequestResult.FromBoolean(interview.Call.StartedAt != null, 400, "Звонок еще не начат начат"),
                () => RequestResult.FromBoolean(interview.Call.EndedAt == null, 400, "Звонок уже завершен"),
                () =>
                {
                    interview.Call.EndedAt = DateTime.UtcNow;
                    interview.Call.Status = CandidateCallStatus.Completed;
                    return UpdateModel(DB.CandidateInterviews,interview);
                }
            });
        }


        [HttpPut, Route("RescheduleInterviewCall")]
        public async Task<RequestResult> RescheduleInterviewCall(int candidateId, int interviewId, DateTime newDate, string comment = null)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;

            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => RequestResult.FromBoolean(interview.Call.StartedAt == null, 400, "Звонок уже начат"),
                () => RequestResult.FromBoolean(interview.Call.EndedAt == null, 400, "Звонок уже завершен"),
                () =>
                {
                         
                    var rescheduling = new CandidateCallRescheduling
                    {
                        NewPlannedTime = newDate,
                        Comment = comment
                    };

                    if(interview.Call.PostponedPlannedTime == null)
                    {
                        rescheduling.OldPlannedTime = interview.Call.InitialPlannedTime;
                    }
                    else
                    {
                        rescheduling.OldPlannedTime = (DateTime)interview.Call.PostponedPlannedTime;
                    }

                    interview.Call.Reschedulings.Add(rescheduling);
                    interview.Call.PostponedPlannedTime = newDate;
                    interview.Call.Status = CandidateCallStatus.Postponed;

                    return UpdateModel(DB.CandidateInterviews,interview);
                }
            });
        }


        [HttpPut, Route("SetInterviewCallFailed")]
        public async Task<RequestResult> SetInterviewCallFailed(int candidateId, int interviewId)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;

            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => RequestResult.FromBoolean(interview.Call.StartedAt == null, 400, "Звонок уже начат"),
                () => RequestResult.FromBoolean(interview.Call.EndedAt == null, 400, "Звонок уже завершен"),
                () =>
                {
                    interview.Call.Status = CandidateCallStatus.Failed;
                    return UpdateModel(DB.CandidateInterviews,interview);
                }
            });
        }

        //TODO: путь к запись звонка

        #endregion

        #region Результаты собеседований

        [HttpPost, Route("CreateInterviewDecision")]
        public async Task<RequestResult> CreateInterviewDecision(int candidateId, int interviewId, CandidateInterviewDecisionCreateModel decision)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;

            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
           {
                () => BaseCheckCandidateAndInterview(candidate,interview),   
                () => RequestResult.FromBoolean(decision.IsValid(),400,"Проверьте корректность заполнения полей"),
                () => RequestResult.FromBoolean(interview.DecisionId == null,400,"Результат собеседования был уже ранее установлен"),
                () => CheckInterviewDecisionType(interview, decision.Type),
                () =>
                {            
                    interview.Decision = decision.Create();
                    return UpdateModel(DB.CandidateInterviews,interview);
                }
            });
        }

        [HttpPut, Route("UpdateInterviewDecision")]
        public async Task<RequestResult> UpdateInterviewDecision(int candidateId, int interviewId, CandidateInterviewDecisionEditModel decision)
        {
            var candidate = DB.Users.FirstOrDefault(o => o.Id == candidateId && o is Candidate && !o.IsDeleted) as Candidate;

            var interview = DB.CandidateInterviews.Include(o => o.Call)
                                                  .Include(o => o.Decision)
                                                  .AsNoTracking()
                                                  .FirstOrDefault(o => o.Id == interviewId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => BaseCheckCandidateAndInterview(candidate,interview),
                () => RequestResult.FromBoolean(interview.DecisionId != null, 400, "Решение невозможно отредакировать, т.к. его еще нет"),
                () => RequestResult.FromBoolean(interview.Decision.CreatedAt.AddDays(7) > DateTime.UtcNow,
                                                    403, "Решение невозможно отредакировать, т.к. истек срок редактирования"),
                () => RequestResult.FromBoolean(decision.IsValid(),400,"Проверьте корректность заполнения полей"),
                () => CheckInterviewDecisionType(interview, decision.Type),
                () =>
                {
                    decision.Id = (int)interview.DecisionId;
                    return TryUpdateModel(DB.CandidateInterviewDecisions,decision);
                }
            });
        }


        #endregion






        #region Private check methods

        private RequestResult BaseCheckCandidateAndInterview(Candidate candidate, CandidateInterview interview)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(candidate != null, 404, "Кандидат с данным id не найден"),
                () => RequestResult.FromBoolean(candidate.HRDepartmentId == DepartmentId, 403, "Нет доступа к данной сущности"),
                () => RequestResult.FromBoolean(interview != null, 404, "Собеседование с данным id не найдено"),
                () => RequestResult.FromBoolean(interview.CandidateId == candidate.Id, 403, "Данное собеседование не принадлежит кандидату"),
            });
        }

        private RequestResult CheckInterviewDecisionType(CandidateInterview interview, CandidateInterviewDecisionType type)
        {
            switch (type)
            {
                case CandidateInterviewDecisionType.ReInterview:
                case CandidateInterviewDecisionType.Approved:
                    if (interview.Call.Status != CandidateCallStatus.Completed)
                    {
                        return RequestResult.AsError(403, "Нельзя выбрать данный статус, т.к. звонок не состоялся");
                    }
                    break;
                case CandidateInterviewDecisionType.Rejected:
                    if (interview.Call.Status != CandidateCallStatus.Completed
                        || interview.Call.Status != CandidateCallStatus.Failed)
                    {
                        return RequestResult.AsError(403, "Нельзя выбрать данный статус, т.к. звонок не состоялся или не был помечен как несостоявшийся");
                    }
                    break;
                default:
                    throw new NotImplementedException("Check for new CandidateInterviewDecisionType enum statuses");
            }

            return RequestResult.AsSuccess();
        }

        #endregion
    }
}
