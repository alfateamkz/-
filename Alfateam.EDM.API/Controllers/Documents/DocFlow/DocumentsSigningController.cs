using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General.Subjects;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.EDM.API.Controllers.Documents.DocFlow
{
    public class DocumentsSigningController : AbsDocumentsController
    {
        public DocumentsSigningController(ControllerParams @params) : base(@params)
        {
        }


        #region Подписание документов

        [HttpPut, Route("SetSignDocumentResult")]
        public async Task SetSignDocumentResult(int documentId, DocumentSigningResultDTO model)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForSigningAvailablity(document);

            this.SetDocSigningResult(document, model, false);
        }

        [HttpPut, Route("SetCancelDocumentResult")]
        public async Task SetCancelDocumentResult(int documentId, DocumentSigningResultDTO model)
        {
            var document = DBService.TryGetOne(GetAvailableDocuments(), documentId);
            CheckDocumentForCancellationAvailablity(document);

            this.SetDocSigningResult(document, model, true);
        }

        #endregion





        #region Private CheckDocumentFor methods

        private void CheckDocumentForSigningAvailablity(Document document)
        {
            if (!document.IsAvailableForSigning)
            {
                throw new Exception403("Данный документ нельзя подписать");
            }

            var ourSide = DocService.TryGetOurSigningSide(document, EDMSubject);
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
            else if (document.Cancellation.SignatureType != SignatureType.AlfateamEDM)
            {
                throw new Exception403("Аннулировать можно документы, которые были подписаны через ЭЦП");
            }
            else if (document.Cancellation.Status != DocumentCancellationResult.CancellationRequested)
            {
                throw new Exception403("Нельзя отказать в аннулировании документа, " +
                    "пока не запущен процесс аннулирования или уже произошел процесс аннулирования");
            }


            var ourSide = DocService.TryGetOurSigningSide(document, EDMSubject);
            if (DocService.IsSideSignedOrRejected(document, ourSide.Id, true))
            {
                throw new Exception400("Документ уже был подписан Вами");
            }
        }

        #endregion


        #region Private signing and reject signing methods


        private void SetDocSigningResult(Document document,
                                         DocumentSigningResultDTO model,
                                         bool isCancellation)
        {
            if (model is DocumentRejectedResultDTO rejectResult)
            {
                SetRejectedResult(document, isCancellation, rejectResult);
            }
            else if (model is DocumentSuccessfullySignedResultDTO signedResult)
            {
                SetSignedResult(document, isCancellation, signedResult);
            }
        }



        private void SetRejectedResult(Document document,
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

                entity.SideId = DocService.TryGetOurSigningSide(document, this.EDMSubject).Id;
                (entity as DocumentRejectedResult).RejectedById = this.AuthorizedUser.Id;
            });


            document.StatusChangedAt = DateTime.UtcNow;
            DBService.UpdateEntity(DB.Documents, document);
        }

        private void SetSignedResult(Document document,
                                     bool isCancellation,
                                     DocumentSuccessfullySignedResultDTO signedResult)
        {
            this.ThrowIfDocSigTypeIncorrect(document, signedResult.Signature);
            var ourSide = DocService.TryGetOurSigningSide(document, this.EDMSubject);

            if (DocService.IsOnlyOurSideNotSigned(document, ourSide.Id, isCancellation))
            {
                CreateSignature(document, ourSide, signedResult, isCancellation);

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
                CreateSignature(document, ourSide, signedResult, isCancellation);
            }
        }






        private void CreateSignature(Document document,
                                     DocumentSigningSide ourSide,
                                     DocumentSigningResultDTO model,
                                     bool isCancellation)
        {
            DBService.TryCreateEntity(DB.DocumentSigningResults, model, callback: (entity) =>
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
                HandleSignature(document, signature);
            },
            afterSuccessCallback: (entity) =>
            {
                var signature = (entity as DocumentSuccessfullySignedResult).Signature;
                if(signature is ScanSignature scanSignature)
                {
                    UploadedFilesService.TryBindFileWithEntity(scanSignature.FileId);
                }   
            });
        }






        private void HandleSignature(Document document,
                                               Signature signature)
        {
            HandleSignatureBase(document,  signature);

            var sides = DB.DocumentSigningSides.Where(o => !o.IsDeleted && o.DocumentId == document.Id);
            var ourSide = sides.FirstOrDefault(o => o.IsThisSubject(this.EDMSubject));

            this.ThrowIfDocSigningSideAccessError(document, ourSide);
            signature.SideId = ourSide.Id;
        }

        private void HandleSignatureBase(Document document,
                                         Signature signature)
        {
            signature.SignedById = (int)this.AuthorizedUserId;

            if (signature is ScanSignature scanSignature)
            {
                UploadedFilesService.ThrowIfFileNotAvailable(scanSignature.FileId);
            }
            else if (signature is AlfateamEDMSignature alfateamEDMSignature)
            {
                string dataToVerify = ""; //json or file if DocumentWithFile
                ThrowIfAlfateamEDSIssue(alfateamEDMSignature, dataToVerify);
            }
        }


        #endregion

        #region Throw if signature or access problem

        private void ThrowIfDocSigTypeIncorrect(Document document, SignatureDTO signature)
        {
            if (document.Cancellation.SignatureType == SignatureType.AlfateamEDM && signature is not AlfateamEDMSignatureDTO)
            {
                throw new Exception400("Неверный тип подписи");
            }
            else if (document.Cancellation.SignatureType == SignatureType.TraditionalSignature && signature is not ScanSignatureDTO)
            {
                throw new Exception400("Неверный тип подписи");
            }
        }
        private void ThrowIfDocSigningSideAccessError(Document document, DocumentSigningSide side)
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
        private void ThrowIfAlfateamEDSIssue(AlfateamEDMSignature alfateamEDMSignature, string dataToVerify)
        {
            if (!CertCenterVerificationService.VerifyCert(dataToVerify, alfateamEDMSignature.Signature, alfateamEDMSignature.PublicKey))
            {
                throw new Exception403("Некорректная ЭЦП");
            }

            var subject = this.EDMSubject;
            var countryCode = subject.CountryCode;
            var identifier = subject.BusinessNumber;

            EDSFor edsFor = EDSFor.Individual;
            if (subject is Company)
            {
                edsFor = EDSFor.Business;
            }

            if (!CertCenterVerificationService.DoesCertificateBelongTo(alfateamEDMSignature.PublicKey, countryCode, identifier, edsFor))
            {
                throw new Exception403("ЭЦП не принадлежит субъекту ЭДО");
            }
            //TODO: Нужно еще проверять, есть ли доверенность
        }


        #endregion
    }
}
