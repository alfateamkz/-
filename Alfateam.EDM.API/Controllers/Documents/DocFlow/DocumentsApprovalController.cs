using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;

namespace Alfateam.EDM.API.Controllers.Documents.DocFlow
{
    public class DocumentsApprovalController : AbsDocumentsController
    {
        public DocumentsApprovalController(ControllerParams @params) : base(@params)
        {
        }

        #region Согласование документов

        [HttpPut, Route("MoveToApprovalRoute")]
        public async Task MoveToApprovalRoute(int documentId, int approvalRouteId, string comment = null)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForMoveToApproval(document);

            var route = DBService.TryGetOne(DB.ApprovalRoutes.Where(o => o.CompanyId == EDMSubjectId), approvalRouteId);
            var firstStage = DocApprovalService.GetFirstApprovalRouteStage(approvalRouteId);

            document.Approval.Strategy = new DocumentApprovalRouteStrategy(route.Id, firstStage.Id, comment);
            DBService.UpdateEntity(DB.Documents, document);
        }

        [HttpPut, Route("MoveToApproval")]
        public async Task MoveToApproval(int documentId, int departmentId, string? comment = null, [FromBody] List<int> allowedUserIds = null)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForMoveToApproval(document);

            var strategy = new DocumentApprovalDepartmentStrategy()
            {
                DepartmentId = departmentId,
                Comment = comment
            };
            document.Approval.Strategy = strategy;

            if (allowedUserIds != null && allowedUserIds.Count > 0)
            {
                foreach (var allowedUserId in allowedUserIds)
                {
                    var allowedUser = DBService.TryGetOne(DB.Users, allowedUserId);
                    if (allowedUser.DepartmentId != departmentId)
                    {
                        throw new Exception400($"Пользователь с id={allowedUser.Id} не принадлежит подразделению с id={departmentId}");
                    }
                    strategy.AllowedUsers.Add(allowedUser);
                }
            }
            DBService.UpdateEntity(DB.Documents, document);
        }


        [HttpPut, Route("SetApprovalStatus")]
        public async Task SetApprovalStatus(int documentId, DocumentApprovalResultType resultType, string? comment = null)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForApprovalAvailablity(document);

            var user = AuthorizedUser;

            var approvalResult = new DocumentApprovalResult()
            {
                UserId = user.Id,
                ResultType = resultType,
                Comment = comment
            };


            if (document.Approval.StrategyId == null) //Просто сразу согласовываем документ от себя
            {
                document.Approval.Strategy = new DocumentApprovalDepartmentStrategy()
                {
                    DepartmentId = user.DepartmentId,
                    AllowedUsers = new List<User> { user },
                    Comment = comment
                };
            }
            DocApprovalService.SetApprovalResult(document, approvalResult);
            DBService.UpdateEntity(DB.Documents, document);
        }

        #endregion










        #region Private check methods
        private void CheckDocumentForMoveToApproval(Document document)
        {
            if (!document.IsAvailableForApproval)
            {
                throw new Exception403("Данный документ нельзя отправить по маршруту согласования");
            }
            else if (document.DraftInfoId != null)
            {
                throw new Exception403("Данный документ является черновиком");
            }
            else if (document.Approval.StrategyId != null)
            {
                throw new Exception403("Данный документ уже отправлен на согласование");
            }
        }
        private void CheckDocumentForApprovalAvailablity(Document document)
        {
            if (!document.IsAvailableForApproval)
            {
                throw new Exception403("Данный документ нельзя согласовать");
            }
            else if (document.DraftInfoId != null)
            {
                throw new Exception403("Данный документ является черновиком");
            }
        }

        #endregion
    }
}
