using Alfateam.CertGenerators;
using Alfateam.CertGenerators.Enums;
using Alfateam.CertGenerators.Models;
using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.API.Abstractions;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.DTO;
using Alfateam.CertificationCenter.Models.DTO.Cancellation;
using Alfateam.CertificationCenter.Models.DTO.IssueRequests;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.DB.Services.Models;
using Alfateam.ID.Models.Enums;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace Alfateam.CertificationCenter.Controllers
{
    public class EDSController : AbsAuthorizedController
    {
        public EDSController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение ЭЦП и запросов на выпуск\аннулирование

        [HttpGet, Route("GetEDSList")]
        public async Task<IEnumerable<AlfateamEDSDTO>> GetEDSList()
        {
            return new AlfateamEDSDTO().CreateDTOs(GetAvailableEDSList()).Cast<AlfateamEDSDTO>();
        }

        [HttpGet, Route("GetEDS")]
        public async Task<AlfateamEDSDTO> GetEDS(int edsId)
        {
            return (AlfateamEDSDTO)DBService.TryGetOne(GetAvailableEDSList(), edsId, new AlfateamEDSDTO());
        }

        [HttpGet, Route("GetEDSIssueRequests")]
        public async Task<IEnumerable<EDSIssueRequestDTO>> GetEDSIssueRequests()
        {
            return new EDSIssueRequestDTO().CreateDTOs(GetAvailableIssueRequests()).Cast<EDSIssueRequestDTO>();
        }

        [HttpGet, Route("GetEDSCancellationRequests")]
        public async Task<IEnumerable<EDSCancellationRequestDTO>> GetPOACancellationRequests()
        {
            return new EDSCancellationRequestDTO().CreateDTOs(CancellationRequestsService.GetAvailableEDSCancellations(this.AlfateamSession.User.Guid))
                                                  .Cast<EDSCancellationRequestDTO>();
        }






        #endregion

        #region Отправка запроса на выпуск ЭЦП

        [HttpPost, Route("SendIssueRequest")]
        public async Task SendIssueRequest(EDSIssueRequestDTO model)
        {
            DBService.TryCreateEntity(DB.IssueRequests, model, callback: (entity) =>
            {
                var issueRequest = entity as EDSIssueRequest;

                this.ThrowIfGeoCoordinateNotCorrect("LatitudeFrom", model.LatitudeFrom);
                this.ThrowIfGeoCoordinateNotCorrect("LongitudeFrom", model.LongitudeFrom);


                UploadedFilesService.ThrowIfAnyFileNotAvailable(issueRequest.PersonalDocument.Images.Select(o => o.Id));
                UploadedFilesService.ThrowIfFileNotAvailable(issueRequest.PersonalBiometricIdentification.VideoId);
                if(issueRequest.EDSFor == EDSFor.Business)
                {
                    UploadedFilesService.ThrowIfAnyFileNotAvailable(issueRequest.CompanyDocument.Images.Select(o => o.Id));
                }

                entity.AlfateamIDFrom = this.AlfateamSession.User.Guid;
                entity.StatusInfo = new IssueRequestInfo
                {
                    Status = Models.Enums.IssueRequestStatus.Waiting
                };
            }, 
            afterSuccessCallback: (entity) =>
            {
                var issueRequest = entity as EDSIssueRequest;

                foreach (var image in issueRequest.PersonalDocument.Images)
                {
                    UploadedFilesService.TryBindFileWithEntity(image.Id);
                }
                UploadedFilesService.TryBindFileWithEntity(issueRequest.PersonalBiometricIdentification.VideoId);

                if (issueRequest.EDSFor == EDSFor.Business)
                {
                    foreach (var image in issueRequest.CompanyDocument.Images)
                    {
                        UploadedFilesService.TryBindFileWithEntity(image.Id);
                    }
                }
            });
        }

        [HttpGet, Route("IssueEDS")]
        public async Task<byte[]> IssueEDS(int requestId,string certPassword)
        {
            var request = DBService.TryGetOne(GetAvailableIssueRequests(), requestId);
            if(request.StatusInfo.Status == IssueRequestStatus.Issued)
            {
                throw new Exception403("Сертификат уже был ранее выпущен. Если вы потеряли сертификат или забыли пароль, " +
                    "то СРОЧНО аннулируйте текущий сертификат и отправьте запрос на выпуск нового сертификата");
            }
            if (request.StatusInfo.Status != IssueRequestStatus.Approved)
            {
                throw new Exception403("Запрос на выпуск сертификата не был еще подтвержден или был отклонен");
            }

            var authorizedUser = this.AlfateamSession.User;

            GenerateCertificateInfo generatedEDS = null;

            Gender edsOwnerGender = default;
            switch (request.SuccessDocs.PersonalDocumentRecognizedInfo.Gender)
            {
                case DocumentOwnerGender.M:
                    edsOwnerGender = Gender.M;
                    break;
                case DocumentOwnerGender.F:
                    edsOwnerGender = Gender.F;
                    break;
                default:
                    throw new Exception400("Какой-то полупокер");
            }

            var physicalParams = new AlfateamEDSGeneratorPhysicalParams
            {
                Password = certPassword,
                DateOfBirth = request.SuccessDocs.PersonalDocumentRecognizedInfo.BirthDate,
                Name = request.SuccessDocs.PersonalDocumentRecognizedInfo.Name,
                Surname = request.SuccessDocs.PersonalDocumentRecognizedInfo.Surname,
                GivenName = request.SuccessDocs.PersonalDocumentRecognizedInfo.Patronynic,
                CountryOfResidence = request.SuccessDocs.PersonalDocumentRecognizedInfo.DocumentCountryCode,
                CountryCodeOfCitizenship = request.SuccessDocs.PersonalDocumentRecognizedInfo.CitizenshipCountryCode,
                EmailAddress = authorizedUser.Email,
                TelephoneNumber = authorizedUser.Phone,
                PlaceOfBirth = "",
                UniqueIdentifier = request.SuccessDocs.PersonalDocumentRecognizedInfo.DocumentNumber,
                Gender = edsOwnerGender
            };

            if (request.EDSFor == EDSFor.Individual)
            {
                generatedEDS = AlfateamEDSGenerator.GenerateAlfateamEDSForPhysical(physicalParams);
            }
            else if(request.EDSFor == EDSFor.Business)
            {
                generatedEDS = AlfateamEDSGenerator.GenerateAlfateamEDSForOrganization(new AlfateamEDSGeneratorOrganizationParams(physicalParams)
                {
                    CommonName = request.SuccessDocs.CompanyDocumentRecognizedInfo.CompanyName,
                    Title = request.SuccessDocs.CompanyDocumentRecognizedInfo.CompanyFullName,
                    Organization = request.SuccessDocs.CompanyDocumentRecognizedInfo.CompanyFullName,
                    CountryCode = request.SuccessDocs.CompanyDocumentRecognizedInfo.CompanyCountryCode,
                    StateOrProvinceName = request.SuccessDocs.CompanyDocumentRecognizedInfo.LegalAddressState,
                    OrganizationUnitName = request.SuccessDocs.CompanyDocumentRecognizedInfo.CompanyMainSector,
                    Street = request.SuccessDocs.CompanyDocumentRecognizedInfo.LegalAddressStreetAndHouse,
                    LocalityName = request.SuccessDocs.CompanyDocumentRecognizedInfo.LegalAddressCity,
                    OrganizationIdentifier = request.SuccessDocs.CompanyDocumentRecognizedInfo.BusinessNumber,
                    PostalCode = request.SuccessDocs.CompanyDocumentRecognizedInfo.PostalAddressZIP,
                    PostalAddress = request.SuccessDocs.CompanyDocumentRecognizedInfo.PostalAddress,
                    Role = "",
                });
            }

            request.StatusInfo.Status = IssueRequestStatus.Issued;
            var alfateamEDSEntity = new AlfateamEDS
            {
                EDSSerialNumber = generatedEDS.PFX.SerialNumber,
                For = request.EDSFor,
                OwnerAlfateamID = request.AlfateamIDFrom,
                IssuerStringInfo = generatedEDS.PFX.Issuer,
                OwnerStringInfo = generatedEDS.PFX.Subject,
                ValidBefore = generatedEDS.PFX.NotAfter,
                ValidFrom = generatedEDS.PFX.NotBefore,
                PublicKey = generatedEDS.PFX.GetPublicKeyString(),
            };
            DBService.CreateEntity(DB.AlfateamEDSs, alfateamEDSEntity);
            DBService.UpdateEntity(DB.IssueRequests, request);

            return generatedEDS.PFX.Export(X509ContentType.Pfx, certPassword);
        }

        #endregion

        #region Отправка запроса на аннулирование ЭЦП

        [HttpPost, Route("SendCancellationRequest")]
        public async Task SendCancellationRequest(EDSCancellationRequestDTO model)
        {
            DBService.TryGetOne(GetAvailableEDSList(), model.EDSToCancelId);
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
                ActionFor = VerificationFor.CertCenter_AlfateamEDSCancellation,
                LetterTitle = "Подтверждение аннулирования ЭЦП",
                MessageText = "Код для подтверждения аннулирования ЭЦП в Alfateam ID:",
            });
        }

        [HttpPut, Route("VerifyCancellationRequestCode")]
        public async Task VerifyCancellationRequestCode(int cancellationRequestId, VerificationType type, string code, string newContact)
        {
            var user = this.AlfateamSession.User;
            var request = DBService.TryGetOne(CancellationRequestsService.GetAvailableEDSCancellations(user.Guid), cancellationRequestId);
            CancellationRequestsService.VerifyCancellationRequestCode(user, cancellationRequestId, type, code, newContact);

            if (request.AlfateamIDSMSVerificationId != null && request.AlfateamIDEmailVerificationId != null)
            {
                request.StatusInfo.Status = CancellationRequestStatus.Approved;
                request.EDSToCancel.RevokedAt = DateTime.UtcNow;
            }
            DBService.UpdateEntity(DB.CancellationRequests, request);
        }


        #endregion








        #region Private methods
        private IEnumerable<AlfateamEDS> GetAvailableEDSList()
        {
            return DB.AlfateamEDSs.Where(o => o.OwnerAlfateamID == this.AlfateamSession.User.Guid && !o.IsDeleted);
        }
        private IEnumerable<EDSIssueRequest> GetAvailableIssueRequests()
        {
            var items = DB.IssueRequests.Where(o => o.AlfateamIDFrom == this.AlfateamSession.User.Guid && !o.IsDeleted).Cast<EDSIssueRequest>();
            foreach (var item in items)
            {
                item.PersonalDocument = DB.SentDocuments.FirstOrDefault(o => o.Id == item.PersonalDocumentId);
                item.PersonalBiometricIdentification = DB.SentBiometricIdentifications.FirstOrDefault(o => o.Id == item.PersonalBiometricIdentificationId);
                item.CompanyDocument = DB.SentDocuments.FirstOrDefault(o => o.Id == item.CompanyDocumentId);

                item.SuccessDocs = DB.EDSIssueRequestSuccessDocs.Include(o => o.PersonalDocumentRecognizedInfo)
                                                                .Include(o => o.CompanyDocumentRecognizedInfo)
                                                                .FirstOrDefault(o => o.Id == item.SuccessDocsId);

            }

            return items;
        }
        #endregion
    }
}
