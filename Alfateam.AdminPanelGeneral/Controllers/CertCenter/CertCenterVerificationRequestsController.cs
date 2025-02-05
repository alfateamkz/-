using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.CertCenter;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.RequestSuccessDocs;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.Verification;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.CertCenter
{
    [Route("CertCenter/[controller]")]
    public class CertCenterVerificationRequestsController : AbsCertCenterController
    {
        public CertCenterVerificationRequestsController(ControllerParams @params) : base(@params)
        {
        }

        #region Запросы на верификацию

        [HttpGet, Route("GetVerificationRequests")]
        public async Task<ItemsWithTotalCount<VerificationRequestDTO>> GetVerificationRequests(CertCenterVerificationRequestsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<VerificationRequest, VerificationRequestDTO>(GetAvailableVerificationRequests(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                //if (!string.IsNullOrEmpty(filter.Query))
                //{
                //    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                //}

                //TODO: фильтр по юзеру

                if(filter.Status != null)
                {
                    condition &= entity.StatusInfo.Status == filter.Status;
                }


                return condition;
            });
        }

        [HttpGet, Route("GetVerificationRequest")]
        public async Task<VerificationRequestDTO> GetVerificationRequest(int id)
        {
            return (VerificationRequestDTO)DBService.TryGetOne(GetAvailableVerificationRequests(), id, new VerificationRequestDTO());
        }


        [HttpPut, Route("RejectVerificationRequest")]
        public async Task RejectVerificationRequest(int requestId, string comment)
        {
            var request = GetVerificationRequestOrThrowIfHandled(requestId);
            request.StatusInfo.Comment = comment;
            request.StatusInfo.Status = VerificationRequestStatus.Rejected;

            DBService.UpdateEntity(CertCenterDb.VerificationRequests, request);
        }

        [HttpPut, Route("ApprovePersonalVerificationRequest")]
        public async Task ApprovePersonalVerificationRequest(int requestId, PersonalVerificationRequestSuccessDocsDTO model)
        {
            var request = GetVerificationRequestOrThrowIfHandled(requestId);
            if(request is not PersonalVerificationRequest)
            {
                throw new Exception400("Id верный, но тип сущности не PersonalVerificationRequest");
            }

            request.StatusInfo.Status = VerificationRequestStatus.Approved;
            DBService.TryCreateEntity(CertCenterDb.PersonalVerificationRequestSuccessDocs, model, callback: (entity) =>
            {
                entity.PersonalVerificationRequestId = requestId;
            });
            DBService.UpdateEntity(CertCenterDb.VerificationRequests, request);

            //TODO: фактическое изменение данных в Alfateam ID
        }

        #endregion








        #region Private methods
        private IEnumerable<VerificationRequest> GetAvailableVerificationRequests()
        {
            var requests = CertCenterDb.VerificationRequests.Include(o => o.StatusInfo)
                                                            .Where(o => !o.IsDeleted);

            foreach(var request in requests)
            {
                if(request is PersonalVerificationRequest personal)
                {
                    personal.Document = CertCenterDb.SentDocuments.FirstOrDefault(o => o.Id == personal.DocumentId);
                    personal.BiometricIdentification = CertCenterDb.SentBiometricIdentifications.FirstOrDefault(o => o.Id == personal.BiometricIdentificationId);
                }
            }

            return requests;
        }

        private VerificationRequest GetVerificationRequestOrThrowIfHandled(int requestId)
        {
            var request = DBService.TryGetOne(GetAvailableVerificationRequests(), requestId);
            if (request.StatusInfo.Status != VerificationRequestStatus.Waiting)
            {
                throw new Exception403("Результат верификации был уже установлен");
            }
            return request;
        }

        #endregion
    }
}
