using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.API.Abstractions;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.General;
using Alfateam.CertificationCenter.Models.DTO.IssueRequests;
using Alfateam.CertificationCenter.Models.DTO.Verification;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.CertificationCenter.Models.Verification;
using Alfateam.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CertificationCenter.API.Controllers
{
    public class VerificationController : AbsAuthorizedController
    {
        public VerificationController(ControllerParams @params) : base(@params)
        {
        }

        #region Запросы на верификацию

        [HttpGet, Route("GetLastVerificationRequestStatus")]
        public async Task<VerificationRequestInfoDTO> GetLastVerificationRequestStatus()
        {
            var lastRequest = GetAvailableVerificationRequests().LastOrDefault();
            if (lastRequest != null)
            {
                return (VerificationRequestInfoDTO)new VerificationRequestInfoDTO().CreateDTO(lastRequest.StatusInfo);
            }
            return null;
        }

        [HttpGet, Route("GetVerificationRequests")]
        public async Task<IEnumerable<VerificationRequestDTO>> GetVerificationRequests()
        {
            var items = GetAvailableVerificationRequests();
            foreach (var item in items)
            {
                if(item is PersonalVerificationRequest personalVerificationRequest)
                {
                    personalVerificationRequest.Document = DB.SentDocuments.FirstOrDefault(o => o.Id == personalVerificationRequest.DocumentId);
                    personalVerificationRequest.BiometricIdentification = DB.SentBiometricIdentifications.FirstOrDefault(o => o.Id == personalVerificationRequest.BiometricIdentificationId);
                }      
            }
            return new VerificationRequestDTO().CreateDTOs(items).Cast<VerificationRequestDTO>();
        }

        [HttpPost, Route("SendPersonalVerificationRequest")]
        public async Task SendPersonalVerificationRequest(PersonalVerificationRequestDTO model)
        {
            var activeVerification = DB.VerificationRequests.Include(o => o.StatusInfo)
                                                            .FirstOrDefault(o => o.AlfateamIDFrom == this.AlfateamSession.User.Guid
                                                                              && o is PersonalVerificationRequest
                                                                              && o.StatusInfo.Status == VerificationRequestStatus.Waiting);
            if(activeVerification != null)
            {
                throw new Exception403("Уже есть активный запрос на верификацию. Пожалуйста подождите результатов запроса");
            }

            DBService.TryCreateEntity(DB.VerificationRequests, model, callback: (entity) =>
            {
                var verificationRequest = entity as PersonalVerificationRequest;

                this.ThrowIfGeoCoordinateNotCorrect("LatitudeFrom", model.LatitudeFrom);
                this.ThrowIfGeoCoordinateNotCorrect("LongitudeFrom", model.LongitudeFrom);


                UploadedFilesService.ThrowIfAnyFileNotAvailable(verificationRequest.Document.Images.Select(o => o.Id));
                UploadedFilesService.ThrowIfFileNotAvailable(verificationRequest.BiometricIdentification.VideoId);

                entity.AlfateamIDFrom = this.AlfateamSession.User.Guid;
                entity.StatusInfo = new VerificationRequestInfo
                {
                    Status = Models.Enums.VerificationRequestStatus.Waiting
                };
            },
            afterSuccessCallback: (entity) =>
            {
                var verificationRequest = entity as PersonalVerificationRequest;

                foreach (var image in verificationRequest.Document.Images)
                {
                    UploadedFilesService.BindFileWithEntity(image.Id, UploadedFileRelatedEntity.SentDocument, verificationRequest.Document.Id);
                }
                UploadedFilesService.BindFileWithEntity(verificationRequest.BiometricIdentification.VideoId, UploadedFileRelatedEntity.SentBiometricIdentification, verificationRequest.BiometricIdentification.Id);
            });
        }

        #endregion







        #region Private methods
        private IEnumerable<VerificationRequest> GetAvailableVerificationRequests()
        {
            return DB.VerificationRequests.Include(o => o.StatusInfo)
                                          .Where(o => o.AlfateamIDFrom == this.AlfateamSession.User.Guid && !o.IsDeleted);
        }

        #endregion
    }
}
