using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Corruprtion
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Compliance)]
    public class ComplianceCorruptionCasesController : AbsController
    {
        public ComplianceCorruptionCasesController(ControllerParams @params) : base(@params)
        {
        }

        #region Коррупционные инцидиенты

        [HttpGet, Route("GetCorruptionCases")]
        public async Task<RequestResult> GetCorruptionCases(bool actual, int offset, int count = 20)
        {
            var queryable = DB.CorruptionCases.Include(o => o.InitDetails)
                                              .Include(o => o.Result)
                                              .Where(o => o.ComplianceDepartmentId == this.DepartmentId);

            if (actual)
            {
                queryable = queryable.Where(o => o.ResultId == null);
            }
            else
            {
                queryable = queryable.Where(o => o.ResultId != null);
            }

            return GetMany<CorruptionCase, CorruptionCaseClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetCorruptionCase")]
        public async Task<RequestResult> GetCorruptionCase(int id)
        {
            var item = DB.CorruptionCases.Include(o => o.InitDetails)
                                         .Include(o => o.Result)
                                         .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () => RequestResult<CorruptionCase>.AsSuccess(item)
            });
        }


        [HttpPost, Route("CreateCorruptionCase")]
        public async Task<RequestResult> CreateCorruptionCase(CorruptionCaseCreateModel model)
        {
            return TryCreateModel(DB.CorruptionCases, model, (item) =>
            {
                item.ComplianceDepartmentId = (int)this.DepartmentId;
                return RequestResult<CorruptionCase>.AsSuccess(item);
            });
        }

        [HttpPut, Route("UpdateCorruptionCase")]
        public async Task<RequestResult> UpdateCorruptionCase(CorruptionCaseEditModel model)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseToEdit(item),
                () => TryUpdateModel(DB.CorruptionCases, item, model)
            });
        }

        [HttpDelete, Route("DeleteCorruptionCase")]
        public async Task<RequestResult> DeleteFraudDescription(int id)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseToEdit(item),
                () => DeleteModel(DB.CorruptionCases, item)
            });
        }

        #endregion

        #region Результат коррупционного инцидента

        [HttpPut, Route("SetCorruptionCaseResult")]
        public async Task<RequestResult> SetCorruptionCaseResult(int caseId, CorruptionCaseResultCreateModel model)
        {
            var authorizedUser = GetAuthorizedUser();

            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseToEdit(item),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    item.Result = model.Create();
                    item.Result.DecisionMakerId = authorizedUser.Id;
                    UpdateModel(DB.CorruptionCases, item);
                    return RequestResult<CorruptionCaseResult>.AsSuccess(item.Result);
                }
             });
        }



        #endregion




        #region Private check methods

        private RequestResult CheckBaseCorruptionCase(CorruptionCase item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Инцидент с данным id не найден"),
                () => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному инциденту"),
            });
        }
        private RequestResult CheckBaseCorruptionCaseToEdit(CorruptionCase item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () => RequestResult.FromBoolean(item.ResultId == null,403,"Инцидент уже закрыт. Редактирование невозможно"),
            });
        }

        #endregion
    }
}
