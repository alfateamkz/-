using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.EDM.API.Helpers;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Services
{
    public class DocumentsService
    {
        private EDMDbContext DB;
        private AbsDBService DBService;
        private AbsFilesService FilesService;
        public DocumentsService(EDMDbContext db, AbsDBService dbService, AbsFilesService filesService)
        {
            DB = db;
            DBService = dbService;
            FilesService = filesService;
        }


        public IEnumerable<Document> GetAvailableDocuments(EDMSubject ourEDMSubject, User authorizedUser, bool drafts = false)
        {
            List<Department> departments = new List<Department>();

            var dbDocuments = DB.Documents.Include(o => o.DepartmentsReferences)
                                          .Include(o => o.Approval)
                                          .Include(o => o.CancellationApproval)
                                          .Include(o => o.Signing)
                                          .Include(o => o.Cancellation)
                                          .Include(o => o.ReadEntries)
                                          .Include(o => o.SigningSides)
                                          .Include(o => o.DraftInfo).ThenInclude(o => o.Department)
                                          .Where(o => !o.IsDeleted);

            switch (authorizedUser.DocumentsAccess.Type)
            {
                case DocumentsAccessType.AllDepartments:

                    departments = DB.Departments.Where(o => !o.IsDeleted && o.EDMSubjectId == ourEDMSubject.Id).ToList();
                    break;
                case DocumentsAccessType.OnlyUserDepartment:

                    var department = DB.Departments.FirstOrDefault(o => o.Id == authorizedUser.DepartmentId);
                    departments = new List<Department> { department };
                    break;
                case DocumentsAccessType.OnlyUserDepartmentAndSubsidiary:

                    var rootDepartment = DB.Departments.FirstOrDefault(o => o.Id == authorizedUser.DepartmentId);

                    departments = DepartmentsHelper.GetThisAndAllSubDepartments(rootDepartment, true);
                    break;
                case DocumentsAccessType.OnlySelectedDepartments:

                    departments = DB.Departments.Where(o => !o.IsDeleted && o.DocumentsAccessId == authorizedUser.DocumentsAccess.Id).ToList();
                    break;
            }

            DepartmentsHelper.HideSoftDeletedDepartments(departments);


            var documents = new List<Document>();

            if (drafts)
            {
                documents = dbDocuments.Where(o => o.DraftInfo != null && o.DraftInfo.Department.EDMSubjectId == ourEDMSubject.Id)
                                       .ToList()
                                       .Where(o => departments.Any(a => a.Id == o.DraftInfo.DepartmentId))
                                       .ToList();
            }
            else
            {
                documents = dbDocuments.AsEnumerable()
                                       .Where(o => o.SigningSides.Any(o => o.IsThisSubject(ourEDMSubject)))
                                       .ToList();
            }


            return documents;
        }
        public Counterparty? GetCounterpartyFromSide(int edmSubjectId, DocumentSigningSide side)
        {
            var counterparties = DB.Counterparties.Where(o => o.EDMSubjectId == edmSubjectId).ToList();
            return counterparties.FirstOrDefault(o => o.IsThisDocumentSigningSide(side));
        }




        public List<DocumentSigningSide> GetUnsignedSides(Document document, bool isCancellationSigning)
        {
            var unsignedSides = new List<DocumentSigningSide>();

            var signingResults = DB.DocumentSigningResults.Where(o => o.DocumentSigningMetadataId == document.Signing.Id);
            if (isCancellationSigning)
            {
                signingResults = DB.DocumentSigningResults.Where(o => o.DocumentCancellationMetadataId == document.Cancellation.Id);
            }


            foreach (var side in document.SigningSides.Where(o => !o.IsDeleted))
            {
                if (!signingResults.Any(o => o.SideId == side.Id))
                {
                    unsignedSides.Add(side);
                }
            }

            return unsignedSides;
        }
        public DocumentSigningSide TryGetOurSigningSide(Document document, EDMSubject ourEDMSubject)
        {
            var ourSide = document.SigningSides.FirstOrDefault(o => !o.IsDeleted && o.IsThisSubject(ourEDMSubject));
            if(ourSide == null)
            {
                throw new Exception403("Субъект ЭДО не находится в списке сторон подписания документа");
            }
            return ourSide;
        }
        public bool IsSideSignedOrRejected(Document document, int sideId, bool isCancellationSigning)
        {
            return !GetUnsignedSides(document, isCancellationSigning).Any(o => o.Id == sideId);
        }
        public bool IsOnlyOurSideNotSigned(Document document, int sideId, bool isCancellationSigning)
        {
            return GetUnsignedSides(document, isCancellationSigning).Count == 1 
                && !IsSideSignedOrRejected(document, sideId, isCancellationSigning);
        }



        public void ThrowIfDocSigTypeIncorrect(Document document, SignatureDTO signature)
        {
            if (document.Cancellation.SignatureType == SignatureType.AlfateamEDM && signature is not AlfateamEDMSignatureDTO)
            {
                throw new Exception400("Неверный тип подписи");
            }
            else if (document.Cancellation.SignatureType == SignatureType.SignedByOtherEDM && signature is not MarkedAsElectronicallySignatureDTO)
            {
                throw new Exception400("Неверный тип подписи");
            }
            else if (document.Cancellation.SignatureType == SignatureType.TraditionalSignature && signature is not ScanSignatureDTO)
            {
                throw new Exception400("Неверный тип подписи");
            }
            else if (document.Cancellation.SignatureType == SignatureType.TraditionalSignatureWithoutDF && signature is not ScanSignatureWithoutDocFlowDTO)
            {
                throw new Exception400("Неверный тип подписи");
            }
        }
        public void ThrowIfDocSigningSideAccessError(Document document, DocumentSigningSide side)
        {
            if (side == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }

            var sides = DB.DocumentSigningSides.Where(o => !o.IsDeleted && o.DocumentId == document.Id);
            if (!sides.Any(o => o.Id == side.Id))
            {
                throw new Exception403("Текущая сторона подписания не принадлежит данному документу");
            }
        }
      
        
        


        public void SetDocSigningResultWithDocFlow(Document document, 
                                                   EDMSubject ourEDMSubject, 
                                                   User authorizedUser, 
                                                   DocumentSigningResultDTO model, 
                                                   bool isCancellation)
        {
            if (model is DocumentRejectedResultDTO rejectResult)
            {
                SetRejectedResult(document, ourEDMSubject, authorizedUser, isCancellation, rejectResult);
            }
            else if (model is DocumentSuccessfullySignedResultDTO signedResult)
            {
                SetSignedResult(document, ourEDMSubject, authorizedUser, isCancellation, signedResult);
            }
        }
       
        
        private void SetDocSigningResultWithoutDocFlow(Document document,
                                                       DocumentSigningResultDTO model,
                                                       bool isCancellation)
        {

        }






        #region Приватные методы для подписания документа

        private void SetRejectedResult(Document document,
                                       EDMSubject ourEDMSubject,
                                       User authorizedUser,
                                       bool isCancellation,
                                       DocumentRejectedResultDTO rejectResult)
        {
            DBService.TryCreateEntity(DB.DocumentSigningResults, rejectResult, (entity) =>
            {
                if (isCancellation)
                {
                    entity.DocumentCancellationMetadataId = document.Cancellation.Id;
                    document.Cancellation.Status = DocumentCancellationResult.CancellationRejected;
                }
                else
                {
                    entity.DocumentSigningMetadataId = document.Signing.Id;
                    document.Signing.Status = DocumentSigningResultType.SigningRejected;
                }

                entity.SideId = this.TryGetOurSigningSide(document, ourEDMSubject).Id;
                (entity as DocumentRejectedResult).RejectedById = authorizedUser.Id;
            });


            document.StatusChangedAt = DateTime.UtcNow;
            DBService.UpdateEntity(DB.Documents, document);
        }

        private void SetSignedResult(Document document,
                                     EDMSubject ourEDMSubject,
                                     User authorizedUser,
                                     bool isCancellation,
                                     DocumentSuccessfullySignedResultDTO signedResult)
        {
            this.ThrowIfDocSigTypeIncorrect(document, signedResult.Signature);
            var ourSide = this.TryGetOurSigningSide(document, ourEDMSubject);

            if (this.IsOnlyOurSideNotSigned(document, ourSide.Id, isCancellation))
            {
                CreateSignature(document, ourSide, ourEDMSubject, authorizedUser, signedResult, isCancellation);

                if (isCancellation)
                {
                    document.Cancellation.Status = DocumentCancellationResult.Cancelled;
                }
                else
                {
                    document.Signing.Status = DocumentSigningResultType.Signed;
                }

                document.StatusChangedAt = DateTime.UtcNow;
                DBService.UpdateEntity(DB.Documents, document);
            }
            else
            {
                CreateSignature(document, ourSide, ourEDMSubject, authorizedUser, signedResult, isCancellation);
            }
        }






        private void CreateSignature(Document document, 
                                     DocumentSigningSide ourSide, 
                                     EDMSubject ourEDMSubject, 
                                     User authorizedUser, 
                                     DocumentSigningResultDTO model, 
                                     bool isCancellation)
        {
            DBService.TryCreateEntity(DB.DocumentSigningResults, model, async (entity) =>
            {
                if (isCancellation)
                {
                    entity.DocumentCancellationMetadataId = document.Cancellation.Id;
                }
                else
                {
                    entity.DocumentSigningMetadataId = document.Signing.Id;
                }

                entity.SideId = ourSide.Id;

                var signature = (entity as DocumentSuccessfullySignedResult).Signature;
                await HandleSignatureBaseWithDocFlow(document, ourEDMSubject, authorizedUser, signature);

                if (signature is AlfateamEDMSignature edmSignature)
                {
                    edmSignature.SignedById = authorizedUser.Id;
                }
                else if (signature is ScanSignature scanSignature)
                {
                    scanSignature.SignedById = authorizedUser.Id;
                }
            });
        }






        private async Task HandleSignatureBaseWithDocFlow(Document document, 
                                                          EDMSubject ourEDMSubject, 
                                                          User authorizedUser, 
                                                          Signature signature)
        {
            await HandleSignatureBase(document, authorizedUser, signature);

            var sides = DB.DocumentSigningSides.Where(o => !o.IsDeleted && o.DocumentId == document.Id);
            var ourSide = sides.FirstOrDefault(o => o.IsThisSubject(ourEDMSubject));

            this.ThrowIfDocSigningSideAccessError(document, ourSide);
            signature.SideId = ourSide.Id;
        }
        private async Task HandleSignatureBaseWithoutDocFlow(Document document, 
                                                             User authorizedUser, 
                                                             Signature signature,
                                                             DocumentSigningSide side)
        {
            await HandleSignatureBase(document, authorizedUser, signature);

            this.ThrowIfDocSigningSideAccessError(document, side);
            signature.SideId = side.Id;
        }
        private async Task HandleSignatureBase(Document document, 
                                              User authorizedUser, 
                                              Signature signature)
        {
            if (signature is AlfateamEDMSignature edmSignature)
            {
                edmSignature.SignedById = authorizedUser.Id;
            }
            else if (signature is MarkedAsElectronicallySignature markedAsElectronicallySignature)
            {
                DBService.TryGetOne(DB.EDMProviders, markedAsElectronicallySignature.EDMProviderId);
            }
            else if (signature is ScanSignature scanSignature)
            {
                scanSignature.SignedById = authorizedUser.Id;
                scanSignature.ScanPath = await FilesService.TryUploadFile("signedDoc", FileType.Document);
            }
            else if (signature is ScanSignatureWithoutDocFlow scanSignatureWithoutDocFlow)
            {
                scanSignatureWithoutDocFlow.ScanPath = await FilesService.TryUploadFile("signedDoc", FileType.Document);
            }
        }

        #endregion
    }
}
