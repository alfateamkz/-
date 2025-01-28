using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Enums;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CertificationCenter.API.Services
{
    public class CancellationRequestsService
    {
        public CertCenterDbContext DB;
        public AbsDBService DBService;
        public AlfateamIDCodesService CodesService;
        public CancellationRequestsService(CertCenterDbContext db,
                                           AbsDBService dbService,
                                           AlfateamIDCodesService codesService)
        {
            DB = db;
            DBService = dbService;
            CodesService = codesService;
        }


        public void TrySendCancellationRequest(CancellationRequestDTO model)
        {
            DBService.TryCreateEntity(DB.CancellationRequests, model, callback: (entity) =>
            {
                this.ThrowIfGeoCoordinateNotCorrect("LatitudeFrom", model.LatitudeFrom);
                this.ThrowIfGeoCoordinateNotCorrect("LongitudeFrom", model.LongitudeFrom);

                entity.StatusInfo = new CancellationRequestInfo();
            });
        }




        public void ThrowIfCodeIsAlreadyConfirmed(VerificationType type, int cancellationRequestId, string alfateamId)
        {
            var request = DBService.TryGetOne(GetAvailableCancellations(alfateamId), cancellationRequestId);
            if (type == VerificationType.Email && request.AlfateamIDEmailVerificationId != null)
            {
                throw new Exception400("Код из письма уже подтвержден");
            }
            else if (type == VerificationType.Email && request.AlfateamIDSMSVerificationId != null)
            {
                throw new Exception400("Код из SMS уже подтвержден");
            }
        }
        public void VerifyCancellationRequestCode(User authorizedUser, int cancellationRequestId, VerificationType type, string code, string newContact)
        {
            var request = DBService.TryGetOne(GetAvailableCancellations(authorizedUser.Guid), cancellationRequestId);

            VerificationFor verificationActionFor = default;
            if(request is EDSCancellationRequest)
            {
                verificationActionFor = VerificationFor.CertCenter_AlfateamEDSCancellation;
            }
            else if (request is DigitalPOACancellationRequest)
            {
                verificationActionFor = VerificationFor.CertCenter_DigitalPOACancellation;
            }

            var verifiedCode = CodesService.VerifyCode(type, verificationActionFor, authorizedUser.GetContact(type), code);

            if (type == VerificationType.Email)
            {
                request.AlfateamIDEmailVerificationId = verifiedCode.Id;
            }
            else if (type == VerificationType.Phone)
            {
                request.AlfateamIDSMSVerificationId = verifiedCode.Id;
            }
        }






        public IEnumerable<CancellationRequest> GetAvailableCancellations(string alfateamId)
        {
            var cancellations = DB.CancellationRequests.Include(o => o.StatusInfo)
                                                       .Where(o => o.AlfateamIDFrom == alfateamId && !o.IsDeleted);

            foreach(var cancellation in cancellations)
            {
                if(cancellation is DigitalPOACancellationRequest digitalPOACancellation)
                {
                    digitalPOACancellation.DigitalPOAToCancel = DB.AlfateamDigitalPOA.FirstOrDefault(o => o.Id == digitalPOACancellation.DigitalPOAToCancelId);
                }
                else if (cancellation is EDSCancellationRequest EDSCancellation)
                {
                    EDSCancellation.EDSToCancel = DB.AlfateamEDSs.FirstOrDefault(o => o.Id == EDSCancellation.EDSToCancelId);
                }
            }

            return cancellations;
        }
        public IEnumerable<EDSCancellationRequest> GetAvailableEDSCancellations(string alfateamId)
        {
            return GetAvailableCancellations(alfateamId).Cast<EDSCancellationRequest>();
        }
        public IEnumerable<DigitalPOACancellationRequest> GetAvailablePOACancellations(string alfateamId)
        {
            return GetAvailableCancellations(alfateamId).Cast<DigitalPOACancellationRequest>();
        }



        #region Private methods

        private void ThrowIfGeoCoordinateNotCorrect(string fieldName, double value)
        {
            if (value < -180 || value > 180)
            {
                throw new Exception400($"Поле {fieldName} должно быть в диапазоне от -180 до 180");
            }
        }

        #endregion
    }
}
