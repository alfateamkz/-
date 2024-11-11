using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Helpers;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections;


namespace Alfateam.EDM.API.Controllers.Documents
{
    public class DocumentsController : AbsAuthorizedController
    {
        public DocumentsController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: includes of derived types


        #region Получение документов

        [HttpGet, Route("GetDocuments")]
        public async Task<IEnumerable<DocumentDTO>> GetDocuments(bool drafts)
        {
            var documents = GetAvailableDocuments(drafts);
            return new DocumentDTO().CreateDTOs(documents).Cast<DocumentDTO>();
        }

        [HttpGet, Route("GetDocumentsByDepartment")]
        public async Task<IEnumerable<DocumentDTO>> GetDocumentsByDepartment(bool drafts, int departmentId)
        {
            var documents = GetAvailableDocuments(drafts).Where(o => o.DepartmentsReferences.Any(o => o.Id == departmentId));
            return new DocumentDTO().CreateDTOs(documents).Cast<DocumentDTO>();
        }

        [HttpGet, Route("GetDocumentsByFilter")]
        public async Task<IEnumerable<DocumentDTO>> GetDocumentsByFilter(DocumentsFilterModel model)
        {
            var documents = GetAvailableDocuments().ToList();
            documents = model.FilterDocuments(documents, DB, this.EDMSubject);

            return new DocumentDTO().CreateDTOs(documents).Cast<DocumentDTO>();
        }


        [HttpGet, Route("GetDocument")]
        public async Task<DocumentDTO> GetDocument(bool drafts, int id)
        {
            var documents = GetAvailableDocuments(drafts);
            return (DocumentDTO)DBService.TryGetOne(documents, id, new DocumentDTO());
        }

        #endregion

        #region Создание документов

        [HttpPost, Route("CreateDocumentsParcel")]
        public async Task<DocumentsParcelDTO> CreateDocumentsParcel(DocumentsParcelDTO model)
        {
            return (DocumentsParcelDTO)DBService.TryCreateEntity(DB.DocumentsParcels, model, async (entity) =>
            {
                await HandleDocuments(entity.Documents, DBModelFillMode.Create);
            });
        }

        [HttpPost, Route("CreateDocuments")]
        public async Task<IEnumerable<DocumentDTO>> CreateDocuments(IEnumerable<DocumentDTO> models)
        {
            return DBService.TryCreateEntities(DB.Documents, models, async (entities) =>
            {
                await HandleDocuments(entities, DBModelFillMode.Create);
            }).Cast<DocumentDTO>();
        }


        #endregion

        #region Согласование документов

        [HttpPut, Route("MoveToApprovalRoute")]
        public async Task MoveToApprovalRoute(int documentId, int approvalRouteId, string comment = null)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForMoveToApproval(document);

            var route = DBService.TryGetOne(DB.ApprovalRoutes.Where(o => o.CompanyId == this.EDMSubjectId), approvalRouteId);
            var firstStage = DocApprovalService.GetFirstApprovalRouteStage(approvalRouteId);

            document.Approval.Strategy = new DocumentApprovalRouteStrategy(route.Id, firstStage.Id, comment);
            DBService.UpdateEntity(DB.Documents, document);
        }

        [HttpPut, Route("MoveToApproval")]
        public async Task MoveToApproval(int documentId, int departmentId, string? comment = null, [FromBody]List<int> allowedUserIds = null)
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
                foreach(var allowedUserId in allowedUserIds)
                {
                    var allowedUser = DBService.TryGetOne(DB.Users, allowedUserId);
                    if(allowedUser.DepartmentId != departmentId)
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

            var user = this.AuthorizedUser;

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

        #region Подписание документов

        [HttpPut, Route("SetSignDocumentResultWithDocFlow")]
        public async Task SetSignDocumentResultWithDocFlow(int documentId, DocumentSigningResultDTO model)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForSigningAvailablity(document);

            DocService.SetDocSigningResultWithDocFlow(document, this.EDMSubject, this.AuthorizedUser, model, false);
        }

        [HttpPut, Route("SetSignDocumentResult")]
        public async Task SetSignDocumentResult(int documentId, DocumentSigningResultDTO model)
        {

        }

        #endregion


        #region Аннулирование документов


        [HttpPut, Route("SetCancelDocumentResultWithDocFlow")]
        public async Task SetCancelDocumentResultWithDocFlow(int documentId, DocumentSigningResultDTO model)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForCancellationAvailablity(document);

            DocService.SetDocSigningResultWithDocFlow(document, this.EDMSubject, this.AuthorizedUser, model, true);
        }

        [HttpPut, Route("SetCancelDocumentResult")]
        public async Task SetCancelDocumentResult(int documentId, DocumentSigningResultDTO model)
        {

        }

        #endregion


        #region Проверка возможности подписи с субъектом ЭДО

      [SwaggerResponse(200,description: "Возвращает субъект ЭДО",  typeof(EDMSubjectDTO))]
        [SwaggerResponse(403, description: "Возвращает строку с описанием причины бана или с предложением добавить сначала субъект в контрагенты (если ему присылать могут только контрагенты)", typeof(string))]
        [HttpGet, Route("GetEDMSubjectForSigning")]
        public async Task<EDMSubjectDTO> GetEDMSubjectForSigning(string countryCode, string number)
        {
            var subject = DB.EDMSubjects.FirstOrDefault(o => o.CountryCode == countryCode && o.BusinessNumber == number && !o.IsDeleted && o.IsVerified);
            if(subject == null)
            {
                throw new Exception404("Субъект ЭДО с данными данными не найден");
            }

            switch (await CanSignWithEDMSubject(countryCode,number))
            {
                case EDMSubjectSigningAccessType.SubjectBannedUs:
                    
                    var bannedOurSubject = DB.BannedCounterparties.Include(o => o.Counterparty)
                                                        .ToList()
                                                        .FirstOrDefault(o => o.EDMSubjectId == subject.Id && !o.IsDeleted && o.Counterparty.IsThisSubject(this.EDMSubject));
                    throw new Exception403($"Контрагент вас заблокировал. Комментарий к блокировке: {bannedOurSubject.BanReason}");
                case EDMSubjectSigningAccessType.NeedToAddSubjectToCounterparties:
                    throw new Exception403($"Нельзя подписаться с данным контрагентом. Сначала пригласите контрагента к ЭДО и получите согласие, прежде чем продолжить");
            }
            return (EDMSubjectDTO)new EDMSubjectDTO().CreateDTO(subject);
        }

        [HttpGet, Route("CanSignWithEDMSubject")]
        public async Task<EDMSubjectSigningAccessType> CanSignWithEDMSubject(string countryCode, string number)
        {
            var subject = DB.EDMSubjects.FirstOrDefault(o => o.CountryCode == countryCode && o.BusinessNumber == number && !o.IsDeleted && o.IsVerified);
            if (subject == null)
            {
                throw new Exception404("Субъект ЭДО с данными данными не найден");
            }

            switch (subject.WhoCanSendDocumentsToUs)
            {
                case WhoCanSendDocumentsToUs.AllExceptingBlocked:

                    var banned = DB.BannedCounterparties.Include(o => o.Counterparty)
                                                        .Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
                    var bannedOurSubject = banned.FirstOrDefault(o => o.Counterparty.IsThisSubject(this.EDMSubject));
                    if (bannedOurSubject != null)
                    {
                        return EDMSubjectSigningAccessType.SubjectBannedUs;
                    }
                    break;
                case WhoCanSendDocumentsToUs.OnlyOurCounterparties:

                    var counterparties = DB.Counterparties.Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
                    var counterpartyOurSubject = counterparties.FirstOrDefault(o => o.IsThisSubject(this.EDMSubject));
                    if (counterpartyOurSubject == null)
                    {
                        return EDMSubjectSigningAccessType.NeedToAddSubjectToCounterparties;
                    }
                    break;
            }
            return EDMSubjectSigningAccessType.CanSign;
        }

        #endregion









        [HttpPut, Route("ReplaceDocumentsToDepartment")]
        public async Task ReplaceDocumentsToDepartment(int toDepartmentId, [FromBody] List<int> documentIds)
        {
            var documents = DB.Documents.Include(o => o.DepartmentsReferences)
                                        .AsEnumerable()
                                        .Where(o => documentIds.Contains(o.Id));


            var subjects = DB.EDMSubjects.Include(o => o.Department)
                                         .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var subject = DBService.TryGetOne(subjects, (int)this.EDMSubjectId);
            var toDepartment = DBService.TryGetOne(DepartmentsHelper.GetThisAndAllSubDepartments(subject.Department, true), toDepartmentId);


            foreach (var document in documents)
            {
                DepartmentsHelper.ReplaceDocumentDepartment((int)this.EDMSubjectId, document, toDepartment);
            }

            DBService.UpdateEntities(DB.Documents, documents);
        }





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



        private void CheckDocumentForSigningAvailablity(Document document)
        {
            if (!document.IsAvailableForSigning)
            {
                throw new Exception403("Данный документ нельзя подписать");
            }

            var ourSide = DocService.TryGetOurSigningSide(document, this.EDMSubject);
            if (DocService.IsSideSignedOrRejected(document, ourSide.Id, false))
            {
                throw new Exception400("Документ уже был подписан Вами");
            }
        }
        private void CheckDocumentForCancellationAvailablity(Document document)
        {
            if (!document.IsAvailableForCancellation)
            {
                throw new Exception403("Данный документ нельзя аннулировать");
            }
            else if (document.Cancellation.SignatureType != SignatureType.AlfateamEDM
                    && document.Cancellation.SignatureType != SignatureType.SignedByOtherEDM)
            {
                throw new Exception403("Аннулировать можно документы, которые были подписаны через ЭЦП");
            }
            else if (document.Cancellation.Status != DocumentCancellationResult.CancellationRequested)
            {
                throw new Exception403("Нельзя отказать в аннулировании документа, " +
                    "пока не запущен процесс аннулирования или уже произошел процесс аннулирования");
            }


            var ourSide = DocService.TryGetOurSigningSide(document, this.EDMSubject);
            if (DocService.IsSideSignedOrRejected(document, ourSide.Id, true))
            {
                throw new Exception400("Документ уже был подписан Вами");
            }
        }

        #endregion

        #region Private handle methods

        private async Task HandleDocuments(IEnumerable<Document> allDocuments, DBModelFillMode mode)
        {

            var mainDepartment = DB.EDMSubjects.Include(o => o.Department)
                                               .FirstOrDefault(o => o.Id == this.EDMSubjectId && !o.IsDeleted)
                                               ?.Department;


            foreach (var doc in allDocuments)
            {
                if (mode == DBModelFillMode.Create)
                {
                    doc.DepartmentsReferences.Add(mainDepartment);
                    doc.SigningSides.Add(new AlfateamEDMDocumentSigningSide()
                    {
                        SubjectId = (int)this.EDMSubjectId
                    });
                }

                //Если документ не черновик, то проверяем стороны подписания документа
                if (doc.DraftInfo == null)
                {
                    var otherEDMSides = doc.SigningSides.Where(o => !o.IsThisSubject(this.EDMSubject))
                                                        .Where(o => o is AlfateamEDMDocumentSigningSide)
                                                        .Cast<AlfateamEDMDocumentSigningSide>();
                    foreach (var side in otherEDMSides)
                    {
                        var sideSubject = DB.EDMSubjects.FirstOrDefault(o => o.Id == side.SubjectId);
                        if (await CanSignWithEDMSubject(sideSubject.CountryCode, sideSubject.BusinessNumber) != EDMSubjectSigningAccessType.CanSign)
                        {
                            throw new Exception403($"Мы не можем подписаться с контрагентом из {sideSubject.CountryCode} с номером {sideSubject.BusinessNumber}");
                        }
                    }
                }

            }

            var simpleDocuments = allDocuments.Where(o => o is DocumentWithFile)
                                              .Cast<DocumentWithFile>()
                                              .ToList();
            for (int i = 0; i < simpleDocuments.Count; i++)
            {
                await HandleNonFormalizedDocument(simpleDocuments[i], i);
            }
        }
        private async Task HandleNonFormalizedDocument(DocumentWithFile document, int counter)
        {
            document.DocumentPath = FilesService.TryUploadFile(counter, FileType.Document);
        }



        #endregion

        #region Private methods
        private IEnumerable<Document> GetAvailableDocuments(bool drafts = false)
        {
            return DocService.GetAvailableDocuments(EDMSubject, AuthorizedUser, drafts);
        }

 
        #endregion
    }
}
