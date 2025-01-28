using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.API.Abstractions;
using Alfateam.CertificationCenter.API.Services;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.DTO;
using Alfateam.CertificationCenter.Models.DTO.Cancellation;
using Alfateam.CertificationCenter.Models.DTO.IssueRequests;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.Core.Exceptions;
using Alfateam.DB.Services.Models;
using Alfateam.ID.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CertificationCenter.Controllers
{
    public class DigitalPOAController : AbsAuthorizedController
    {
        public DigitalPOAController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение доверенностей и запросов на выпуск\аннулирование

        [HttpGet, Route("GetPOAList")]
        public async Task<IEnumerable<AlfateamDigitalPOADTO>> GetPOAList()
        {
            return new AlfateamDigitalPOADTO().CreateDTOs(GetAvailablePOAList()).Cast<AlfateamDigitalPOADTO>();
        }

        [HttpGet, Route("GetPOA")]
        public async Task<AlfateamDigitalPOADTO> GetPOA(int edsId)
        {
            return (AlfateamDigitalPOADTO)DBService.TryGetOne(GetAvailablePOAList(), edsId, new AlfateamDigitalPOADTO());
        }

        [HttpGet, Route("DownloadPOA")]
        public async Task DownloadPOA(int edsId)
        {
            //TODO: фактическое скачивание электронной доверенности
        }

        [HttpGet, Route("GetPOAIssueRequests")]
        public async Task<IEnumerable<DigitalPOAIssueRequestDTO>> GetPOAIssueRequests()
        {
            var items = DB.IssueRequests.Where(o => o.AlfateamIDFrom == this.AlfateamSession.User.Guid && !o.IsDeleted).Cast<DigitalPOAIssueRequest>();
            foreach(var item in items)
            {
                item.PersonForDocument = DB.SentDocuments.FirstOrDefault(o => o.Id == item.PersonForDocumentId);
                item.PersonForBiometricIdentification = DB.SentBiometricIdentifications.FirstOrDefault(o => o.Id == item.PersonForBiometricIdentificationId);
            }

            return new DigitalPOAIssueRequestDTO().CreateDTOs(items).Cast<DigitalPOAIssueRequestDTO>();
        }

        [HttpGet, Route("GetPOACancellationRequests")]
        public async Task<IEnumerable<DigitalPOACancellationRequestDTO>> GetPOACancellationRequests()
        {
            return new DigitalPOACancellationRequestDTO().CreateDTOs(CancellationRequestsService.GetAvailablePOACancellations(this.AlfateamSession.User.Guid))
                                                         .Cast<DigitalPOACancellationRequestDTO>();
        }

        #endregion

        #region Отправка запроса на выпуск доверенности

        [HttpPost, Route("SendIssueRequest")]
        public async Task SendIssueRequest(DigitalPOAIssueRequestDTO model)
        {
            DBService.TryCreateEntity(DB.IssueRequests, model, callback: (entity) =>
            {
                var issueRequest = entity as DigitalPOAIssueRequest;

                this.ThrowIfGeoCoordinateNotCorrect("LatitudeFrom", model.LatitudeFrom);
                this.ThrowIfGeoCoordinateNotCorrect("LongitudeFrom", model.LongitudeFrom);


                UploadedFilesService.ThrowIfAnyFileNotAvailable(issueRequest.PersonForDocument.Images.Select(o => o.Id));
                UploadedFilesService.ThrowIfFileNotAvailable(issueRequest.PersonForBiometricIdentification.VideoId);

                entity.AlfateamIDFrom = this.AlfateamSession.User.Guid;
                entity.StatusInfo = new IssueRequestInfo
                {
                    Status = Models.Enums.IssueRequestStatus.Waiting
                };
            },
            afterSuccessCallback: (entity) =>
            {
                var issueRequest = entity as DigitalPOAIssueRequest;

                foreach (var image in issueRequest.PersonForDocument.Images)
                {
                    UploadedFilesService.BindFileWithEntity(image.Id, UploadedFileRelatedEntity.SentDocument, issueRequest.PersonForDocument.Id);
                }
                UploadedFilesService.BindFileWithEntity(issueRequest.PersonForBiometricIdentification.VideoId, UploadedFileRelatedEntity.SentBiometricIdentification, issueRequest.PersonForBiometricIdentification.Id);
            });
        }

        #endregion

        #region Отправка запроса на аннулирование доверенности

        [HttpPost, Route("SendCancellationRequest")]
        public async Task SendCancellationRequest(DigitalPOACancellationRequestDTO model)
        {
            DBService.TryGetOne(GetAvailablePOAList(), model.DigitalPOAToCancelId);
            CancellationRequestsService.TrySendCancellationRequest(model);
        }

    



        [HttpPut, Route("SendCancellationRequestCode")]
        public async Task SendCancellationRequestCode(int cancellationRequestId, VerificationType type)
        {
            CancellationRequestsService.ThrowIfCodeIsAlreadyConfirmed(type, cancellationRequestId, this.AlfateamSession.User.Guid);
            CodesService.SendCode(new AlfateamIDSendCodeParams
            {
                Type = type,
                Contact = this.AlfateamSession.User.GetContact(type),
                ActionFor = VerificationFor.CertCenter_DigitalPOACancellation,
                LetterTitle = "Подтверждение аннулирования доверенности",
                MessageText = "Код для подтверждения аннулирования доверенности в Alfateam ID:",
            });
        }

        [HttpPut, Route("VerifyCancellationRequestCode")]
        public async Task VerifyCancellationRequestCode(int cancellationRequestId, VerificationType type, string code, string newContact)
        {
            var user = this.AlfateamSession.User;
            var request = DBService.TryGetOne(CancellationRequestsService.GetAvailablePOACancellations(user.Guid), cancellationRequestId);
            CancellationRequestsService.VerifyCancellationRequestCode(user, cancellationRequestId, type, code, newContact);

            if (request.AlfateamIDSMSVerificationId != null && request.AlfateamIDEmailVerificationId != null)
            {
                request.StatusInfo.Status = CancellationRequestStatus.Approved;

                //TODO: фактическое аннулирование доверенности
            }
            DBService.UpdateEntity(DB.CancellationRequests, request);
        }

        #endregion









        #region Private methods
        private IEnumerable<AlfateamDigitalPOA> GetAvailablePOAList()
        {
            return DB.AlfateamDigitalPOA.Where(o => o.OwnerAlfateamID == this.AlfateamSession.User.Guid && !o.IsDeleted);
        }


        #endregion
    }
}
