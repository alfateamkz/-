using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.CertCenter;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.RequestSuccessDocs;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.CertificationCenter.Models.Verification;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.CertCenter
{
    public class CertCenterIssueRequestsController : AbsCertCenterController
    {
        public CertCenterIssueRequestsController(ControllerParams @params) : base(@params)
        {
        }


        #region Запросы на выпуск

        [HttpGet, Route("GetIssueRequests")]
        public async Task<ItemsWithTotalCount<IssueRequestDTO>> GetIssueRequests(CertCenterIssueRequestsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<IssueRequest, IssueRequestDTO>(GetAvailableRequests(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                //if (!string.IsNullOrEmpty(filter.Query))
                //{
                //    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                //}

                //TODO: фильтр по юзеру

                if (filter.Status != null)
                {
                    condition &= entity.StatusInfo.Status == filter.Status;
                }


                return condition;
            });
        }

        [HttpGet, Route("GetIssueRequest")]
        public async Task<IssueRequestDTO> GetIssueRequest(int id)
        {
            return (IssueRequestDTO)DBService.TryGetOne(GetAvailableRequests(), id, new IssueRequestDTO());
        }

        [HttpPut, Route("RejectIssueRequest")]
        public async Task RejectIssueRequest(int requestId, string comment)
        {
            var request = GetRequestOrThrowIfHandled(requestId);
            request.StatusInfo.Comment = comment;
            request.StatusInfo.Status = IssueRequestStatus.Rejected;

            DBService.UpdateEntity(CertCenterDb.IssueRequests, request);
        }

        [HttpPut, Route("ApproveDigitalPOAIssueRequest")]
        public async Task ApproveDigitalPOAIssueRequest(int requestId, DigitalPOAIssueRequestSuccessDocsDTO model)
        {
            var request = GetRequestOrThrowIfHandled(requestId);
            if (request is not DigitalPOAIssueRequest)
            {
                throw new Exception400("Id верный, но тип сущности не DigitalPOAIssueRequest");
            }

            request.StatusInfo.Status = IssueRequestStatus.Approved;
            DBService.TryCreateEntity(CertCenterDb.DigitalPOAIssueRequestSuccessDocs, model, callback: (entity) =>
            {
                entity.DigitalPOAIssueRequestId = requestId;
            });
            DBService.UpdateEntity(CertCenterDb.IssueRequests, request);

            //TODO: фактический выпуск электронной доверенности
        }

        [HttpPut, Route("ApproveAlfateamEDMIssueRequest")]
        public async Task ApproveAlfateamEDMIssueRequest(int requestId, EDSIssueRequestSuccessDocsDTO model)
        {
            var request = GetRequestOrThrowIfHandled(requestId);
            if (request is not EDSIssueRequest)
            {
                throw new Exception400("Id верный, но тип сущности не EDSIssueRequest");
            }

            request.StatusInfo.Status = IssueRequestStatus.Approved;
            DBService.TryCreateEntity(CertCenterDb.EDSIssueRequestSuccessDocs, model, callback: (entity) =>
            {
                entity.EDSIssueRequestId = requestId;
            });
            DBService.UpdateEntity(CertCenterDb.IssueRequests, request);

            //TODO: фактический выпуск ЭЦП
        }


        #endregion




        #region Private methods
        private IEnumerable<IssueRequest> GetAvailableRequests()
        {
            var requests = CertCenterDb.IssueRequests.Include(o => o.StatusInfo)
                                                     .Where(o => !o.IsDeleted);

            foreach (var request in requests)
            {
                if (request is DigitalPOAIssueRequest personal)
                {
                    personal.PersonForDocument = CertCenterDb.SentDocuments.FirstOrDefault(o => o.Id == personal.PersonForDocumentId);
                    personal.PersonForBiometricIdentification = CertCenterDb.SentBiometricIdentifications.FirstOrDefault(o => o.Id == personal.PersonForBiometricIdentificationId);
                }
                else if(request is EDSIssueRequest eds)
                {
                    eds.PersonalDocument = CertCenterDb.SentDocuments.FirstOrDefault(o => o.Id == eds.PersonalDocumentId);
                    eds.PersonalBiometricIdentification = CertCenterDb.SentBiometricIdentifications.FirstOrDefault(o => o.Id == eds.PersonalBiometricIdentificationId);
                    eds.CompanyDocument = CertCenterDb.SentDocuments.FirstOrDefault(o => o.Id == eds.CompanyDocumentId);
                }
            }

            return requests;
        }
        private IssueRequest GetRequestOrThrowIfHandled(int requestId)
        {
            var request = DBService.TryGetOne(GetAvailableRequests(), requestId);
            if (request.StatusInfo.Status != IssueRequestStatus.Waiting)
            {
                throw new Exception403("Результат запроса был уже установлен");
            }
            return request;
        }

        #endregion
    }
}
