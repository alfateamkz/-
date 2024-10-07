using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.EDM.API.Controllers.Director
{
    [MustBeCompany]
    [RequiredRole(UserRole.Owner)]
    public class ApprovalRoutesController : AbsAuthorizedController
    {
        public ApprovalRoutesController(ControllerParams @params) : base(@params)
        {
        }

        #region Маршруты согласования 

        [HttpGet, Route("GetApprovalRoutes")]
        public async Task<IEnumerable<ApprovalRouteDTO>> GetApprovalRoutes()
        {
            var routes = DB.ApprovalRoutes.Where(o => !o.IsDeleted && o.CompanyId == this.EDMSubjectId);
            return new ApprovalRouteDTO().CreateDTOs(routes).Cast<ApprovalRouteDTO>();
        }

        [HttpGet, Route("GetApprovalRoute")]
        public async Task<ApprovalRouteDTO> GetApprovalRoute(int id)
        {
            var routes = DB.ApprovalRoutes.Where(o => !o.IsDeleted && o.CompanyId == this.EDMSubjectId);
            return (ApprovalRouteDTO)DBService.TryGetOne(routes, id, new ApprovalRouteDTO());
        }

        [HttpPost, Route("CreateApprovalRoute")]
        public async Task<ApprovalRouteDTO> CreateApprovalRoute(ApprovalRouteDTO model)
        {
            return (ApprovalRouteDTO)DBService.TryCreateEntity(DB.ApprovalRoutes, model, (entity) =>
            {
                entity.CompanyId = (int)this.EDMSubjectId;
            });
        }

        [HttpPut, Route("UpdateApprovalRoute")]
        public async Task<ApprovalRouteDTO> UpdateApprovalRoute(ApprovalRouteDTO model)
        {
            var routes = DB.ApprovalRoutes.Where(o => !o.IsDeleted && o.CompanyId == this.EDMSubjectId);
            var route = DBService.TryGetOne(routes, model.Id);

            return (ApprovalRouteDTO)DBService.TryUpdateEntity(DB.ApprovalRoutes, model, route);
        }

        [HttpDelete, Route("DeleteApprovalRoute")]
        public async Task DeleteApprovalRoute(int id)
        {
            var routes = DB.ApprovalRoutes.Where(o => !o.IsDeleted && o.CompanyId == this.EDMSubjectId);
            var route = DBService.TryGetOne(routes, id);

            DBService.TryDeleteEntity(DB.ApprovalRoutes, route);
        }

        #endregion

        #region Этапы маршрутов согласования

        [HttpGet, Route("GetApprovalRouteStages")]
        public async Task<IEnumerable<ApprovalRouteStageDTO>> GetApprovalRouteStages(int approvalRouteId)
        {
            CheckApprovalRouteAccess(approvalRouteId);

            var stages = DB.ApprovalRouteStages.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            return new ApprovalRouteStageDTO().CreateDTOs(stages).Cast<ApprovalRouteStageDTO>();
        }

        [HttpGet, Route("GetApprovalRouteStage")]
        public async Task<ApprovalRouteStageDTO> GetApprovalRouteStage(int approvalRouteId,int id)
        {
            CheckApprovalRouteAccess(approvalRouteId);

            var stages = DB.ApprovalRouteStages.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            return (ApprovalRouteStageDTO)DBService.TryGetOne(stages, id, new ApprovalRouteStageDTO());
        }

        [HttpPost, Route("CreateApprovalRouteStage")]
        public async Task<ApprovalRouteStageDTO> CreateApprovalRouteStage(ApprovalRouteStageDTO model)
        {
            CheckApprovalRouteAccess(model.ApprovalRouteId);
            return (ApprovalRouteStageDTO)DBService.TryCreateEntity(DB.ApprovalRouteStages, model);
        }

        [HttpPut, Route("UpdateApprovalRouteStage")]
        public async Task<ApprovalRouteStageDTO> UpdateApprovalRouteStage(int approvalRouteId, ApprovalRouteStageDTO model)
        {
            CheckApprovalRouteAccess(model.ApprovalRouteId);

            var stages = DB.ApprovalRouteStages.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            var stage = DBService.TryGetOne(stages, model.Id);

            return (ApprovalRouteStageDTO)DBService.TryUpdateEntity(DB.ApprovalRouteStages, model, stage);
        }

        [HttpDelete, Route("DeleteApprovalRouteStage")]
        public async Task DeleteApprovalRouteStage(int approvalRouteId, int id)
        {
            CheckApprovalRouteAccess(approvalRouteId);

            var stages = DB.ApprovalRouteStages.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            var stage = DBService.TryGetOne(stages, id);

            DBService.TryDeleteEntity(DB.ApprovalRouteStages, stage);
        }


        #endregion

        #region Действия на этапах маршрутов согласования

        [HttpGet, Route("GetApprovalRouteStageActions")]
        public async Task<IEnumerable<ApprovalRouteStageActionDTO>> GetApprovalRouteStageActions(int approvalRouteId, int stageId)
        {
            CheckApprovalRouteStageAccess(approvalRouteId, stageId);

            var actions = DB.ApprovalRouteStageActions.Where(o => !o.IsDeleted && o.ApprovalRouteStageId == stageId);
            return new ApprovalRouteStageActionDTO().CreateDTOs(actions).Cast<ApprovalRouteStageActionDTO>();
        }

        [HttpGet, Route("GetApprovalRouteStageAction")]
        public async Task<ApprovalRouteStageActionDTO> GetApprovalRouteStageAction(int approvalRouteId, int stageId, int id)
        {
            CheckApprovalRouteStageAccess(approvalRouteId, stageId);

            var actions = DB.ApprovalRouteStageActions.Where(o => !o.IsDeleted && o.ApprovalRouteStageId == stageId);
            return (ApprovalRouteStageActionDTO)DBService.TryGetOne(actions, id, new ApprovalRouteStageActionDTO());
        }

        [HttpPost, Route("CreateApprovalRouteStageAction")]
        public async Task<ApprovalRouteStageActionDTO> CreateApprovalRouteStageAction(int approvalRouteId, ApprovalRouteStageActionDTO model)
        {
            CheckApprovalRouteStageAccess(approvalRouteId, model.ApprovalRouteStageId);
            return (ApprovalRouteStageActionDTO)DBService.TryCreateEntity(DB.ApprovalRouteStageActions, model);
        }

        [HttpPut, Route("UpdateApprovalRouteStageAction")]
        public async Task<ApprovalRouteStageActionDTO> UpdateApprovalRouteStageAction(int approvalRouteId, int stageId, ApprovalRouteStageActionDTO model)
        {
            CheckApprovalRouteStageAccess(approvalRouteId, stageId);

            var actions = DB.ApprovalRouteStageActions.Where(o => !o.IsDeleted && o.ApprovalRouteStageId == stageId);
            var action = DBService.TryGetOne(actions, model.Id);

            return (ApprovalRouteStageActionDTO)DBService.TryUpdateEntity(DB.ApprovalRouteStageActions, model, action);
        }

        [HttpDelete, Route("DeleteApprovalRouteStageAction")]
        public async Task DeleteApprovalRouteStageAction(int approvalRouteId, int stageId, int id)
        {
            CheckApprovalRouteStageAccess(approvalRouteId, stageId);

            var actions = DB.ApprovalRouteStageActions.Where(o => !o.IsDeleted && o.ApprovalRouteStageId == stageId);
            var action = DBService.TryGetOne(actions, id);

            DBService.TryDeleteEntity(DB.ApprovalRouteStageActions, action);
        }

        #endregion

        #region Действия после подписания документа в маршруте согласования

        [HttpGet, Route("GetAfterDocSigningActions")]
        public async Task<IEnumerable<AfterDocSigningActionDTO>> GetAfterDocSigningActions(int approvalRouteId)
        {
            CheckApprovalRouteAccess(approvalRouteId);

            //TODO: includings of derived types

            var stages = DB.AfterDocSigningAction.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            return new AfterDocSigningActionDTO().CreateDTOs(stages).Cast<AfterDocSigningActionDTO>();
        }

        [HttpGet, Route("GetAfterDocSigningAction")]
        public async Task<AfterDocSigningActionDTO> GetAfterDocSigningAction(int approvalRouteId, int id)
        {
            CheckApprovalRouteAccess(approvalRouteId);

            //TODO: includings of derived types

            var stages = DB.AfterDocSigningAction.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            return (AfterDocSigningActionDTO)DBService.TryGetOne(stages, id, new AfterDocSigningActionDTO());
        }

        [HttpPost, Route("CreateAfterDocSigningAction")]
        public async Task<AfterDocSigningActionDTO> CreateAfterDocSigningAction(AfterDocSigningActionDTO model)
        {
            CheckApprovalRouteAccess(model.ApprovalRouteId);
            return (AfterDocSigningActionDTO)DBService.TryCreateEntity(DB.AfterDocSigningAction, model);
        }

        [HttpPut, Route("UpdateAfterDocSigningAction")]
        public async Task<AfterDocSigningActionDTO> UpdateAfterDocSigningAction(int approvalRouteId, AfterDocSigningActionDTO model)
        {
            CheckApprovalRouteAccess(model.ApprovalRouteId);

            var actions = DB.AfterDocSigningAction.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            var action = DBService.TryGetOne(actions, model.Id);

            return (AfterDocSigningActionDTO)DBService.TryUpdateEntity(DB.AfterDocSigningAction, model, action);
        }

        [HttpDelete, Route("DeleteAfterDocSigningAction")]
        public async Task DeleteAfterDocSigningAction(int approvalRouteId, int id)
        {
            CheckApprovalRouteAccess(approvalRouteId);

            var actions = DB.AfterDocSigningAction.Where(o => !o.IsDeleted && o.ApprovalRouteId == approvalRouteId);
            var action = DBService.TryGetOne(actions, id);

            DBService.TryDeleteEntity(DB.AfterDocSigningAction, action);
        }

        #endregion






        #region Private methods


        private void CheckApprovalRouteAccess(int approvalRouteId)
        {
            DBService.TryGetOne(DB.ApprovalRoutes.Where(o => !o.IsDeleted && o.CompanyId == this.EDMSubjectId), approvalRouteId);
        }
        private void CheckApprovalRouteStageAccess(int approvalRouteId,int stageId)
        {
            DBService.TryGetOne(DB.ApprovalRouteStages, stageId);
            CheckApprovalRouteAccess(approvalRouteId);
        }



        #endregion
    }
}
