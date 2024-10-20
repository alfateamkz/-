using Alfateam.Core.Exceptions;
using Alfateam.DB;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.ApprovalRoutes.RouteStageExecutors;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Services
{
    public class DocumentApprovalService
    {
        private EDMDbContext DB;
        private DocumentsService DocService;
        public DocumentApprovalService(EDMDbContext db, DocumentsService documentsService)
        {
            DB = db;
            DocService = documentsService;
        }

        public void SetApprovalResult(Document document, DocumentApprovalResult result)
        {
            var approvalMeta = document.Approval;

            if (approvalMeta.Strategy is DocumentApprovalRouteStrategy routeStrategy)
            {
                var approvalStage = DB.ApprovalRouteStages.Include(o => o.Actions)
                                                          .FirstOrDefault(o => !o.IsDeleted && o.Id == routeStrategy.ApprovalRouteStageId);

                if (!CanUserMakeActionAtStage(result.UserId, approvalStage.Id))
                {
                    throw new Exception403("Данный пользователь не может согласовать текущий документ");
                }

                if (result.ResultType == DocumentApprovalResultType.Approve)
                {
                    var nextApprovalStage = GetNextApprovalRouteStage(routeStrategy.ApprovalRouteId, (int)routeStrategy.ApprovalRouteStageId);
                    routeStrategy.ApprovalRouteStageId = nextApprovalStage?.Id;

                    if (nextApprovalStage == null)
                    {
                        approvalMeta.Status = DocumentApprovalStatus.Approved;
                    }
                }
                else if (result.ResultType == DocumentApprovalResultType.Reject)
                {
                    approvalMeta.Status = DocumentApprovalStatus.ApprovalRejected;
                }
            }
            else if (approvalMeta.Strategy is DocumentApprovalDepartmentStrategy departmentStrategy)
            {
                var users = DB.Users.Where(o => o.DocumentApprovalDepartmentStrategyId == departmentStrategy.Id && !o.IsDeleted);
                if (users.Any(o => o.Id == result.UserId))
                {
                    approvalMeta.ApprovalResults.Add(result);
                    if (result.ResultType == DocumentApprovalResultType.Approve)
                    {
                        approvalMeta.Status = DocumentApprovalStatus.Approved;
                    }
                    else if (result.ResultType == DocumentApprovalResultType.Reject)
                    {
                        approvalMeta.Status = DocumentApprovalStatus.ApprovalRejected;
                    }
                }
                else
                {
                    throw new Exception403("Данный пользователь не может согласовать текущий документ");
                }
            }


            else throw new NotImplementedException();
        }





        public ApprovalRouteStage? GetFirstApprovalRouteStage(int approvalRouteId)
        {
            var stages = DB.ApprovalRouteStages.Include(o => o.Actions)
                                               .Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            return stages.FirstOrDefault();
        }
        public ApprovalRouteStage? GetNextApprovalRouteStage(int approvalRouteId, int approvalRouteStageId)
        {
            var stages = DB.ApprovalRouteStages.Include(o => o.Actions)
                                               .Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId)
                                               .ToList();

            var stage = stages.FirstOrDefault(o => o.Id == approvalRouteStageId);
            if (stage != null)
            {
                var index = stages.IndexOf(stage);
                if (index + 1 < stages.Count)
                {
                    return stages[index + 1];
                }
            }
            return null;
        }



        public bool CanUserMakeActionAtStage(int userId, int approvalRouteStageId)
        {
            var user = DB.Users.Include(o => o.Permissions).FirstOrDefault(o => o.Id == userId);
            var stage = DB.ApprovalRouteStages.Include(o => o.Executor)
                                              .FirstOrDefault(o => o.Id == approvalRouteStageId);

            if (stage.Executor is RouteStageExecutorDepartment departmentExecutor)
            {
                var departmentUsers = DB.Users.Where(o => o.DepartmentId == departmentExecutor.DepartmentId && !o.IsDeleted).ToList();
                var excludingUsers = DB.Users.Where(o => o.RouteStageExecutorDepartmentId == departmentExecutor.Id && !o.IsDeleted);

                foreach (var excludingUser in excludingUsers)
                {
                    var departmentUser = departmentUsers.FirstOrDefault(o => o.Id == excludingUser.Id);
                    if (departmentUser != null)
                    {
                        departmentUsers.Remove(departmentUser);
                    }
                }

                return departmentUsers.Any(o => o.Id == user.Id);
            }
            else if (stage.Executor is RouteStageExecutorUsers usersExecutor)
            {
                var users = DB.Users.Where(o => o.RouteStageExecutorUsersId == usersExecutor.Id && !o.IsDeleted);
                return users.Any(o => o.Id == user.Id);
            }
            else throw new NotImplementedException();
        }


        public ApprovalRoute? GetDocumentMatchRoute(EDMSubject ourEDMSubject, Document document, bool isOutgoing)
        {
            var routes = DB.ApprovalRoutes.Where(o => o.CompanyId == ourEDMSubject.Id && !o.IsDeleted).OrderBy(o => o.Order);
            foreach (var route in routes)
            {
                ApprovalRouteDocCondition condition = route.ForInboxDocCondition;
                if (isOutgoing)
                {
                    condition = route.ForOutgoingDocCondition;
                }

                if (IsDocumentMatch(ourEDMSubject, condition, document))
                {
                    return route;
                }
            }
            return null;
        }
        public bool IsDocumentMatch(EDMSubject ourEDMSubject, ApprovalRouteDocCondition condition, Document document)
        {
            bool match = true;

            if (condition.DocumentTypes.Any())
            {
                match &= condition.DocumentTypes.Any(o => o.Id == document.TypeId);
            }
            if (condition.Counterparties.Any())
            {
                bool hasCounterparty = false;
                foreach (var side in document.SigningSides.Where(o => !o.IsThisSubject(ourEDMSubject)))
                {
                    hasCounterparty = condition.Counterparties.Any(o => o.IsThisDocumentSigningSide(side));
                    if (hasCounterparty)
                    {
                        break;
                    }
                }
                match &= hasCounterparty;
            }
            if (condition.CounterpartyGroups.Any())
            {
                bool hasGroup = false;
                foreach (var side in document.SigningSides.Where(o => !o.IsThisSubject(ourEDMSubject)))
                {
                    var counterparty = DocService.GetCounterpartyFromSide(ourEDMSubject.Id, side);
                    if (counterparty != null && condition.CounterpartyGroups.Any(o => o.Id == counterparty.GroupId))
                    {
                        hasGroup = true;
                        break;
                    }
                }
                match &= hasGroup;
            }

            return match;
        }
    }
}
