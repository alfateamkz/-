using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Corruprtion
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Compliance)]
    public class ComplianceCorruptionCaseActionsController : AbsController
    {
        public ComplianceCorruptionCaseActionsController(ControllerParams @params) : base(@params)
        {
        }

        #region Действия по коррупционному инциденту

        [HttpGet, Route("GetActions")]
        public async Task<RequestResult> GetActions(int caseId)
        {
            var item = DB.CorruptionCases.Include(o => o.Actions).ThenInclude(o => o.Side)
                                         .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () =>
                {
                    item.Actions = item.Actions.Where(o => !o.IsDeleted).ToList();

                    var clientModels = CorruptionCaseActionClientModel.CreateItems(item.Actions);
                    return RequestResult<IEnumerable<CorruptionCaseActionClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetAction")]
        public async Task<RequestResult> GetAction(int caseId, int actionId)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var action = DB.CorruptionCaseActions.FirstOrDefault(o => o.Id == actionId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndAction(item,action),
                () => RequestResult<CorruptionCaseAction>.AsSuccess(action)
            });
        }


        [HttpPost, Route("CreateAction")]
        public async Task<RequestResult> CreateAction(int caseId, CorruptionCaseActionCreateModel model)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseToEdit(item),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var action = model.Create();
                    item.Actions.Add(action);

                    UpdateModel(DB.CorruptionCases, item);
                    return RequestResult<CorruptionCaseAction>.AsSuccess(action);
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

        private RequestResult CheckBaseCorruptionCaseAndAction(CorruptionCase item, CorruptionCaseAction action)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () => RequestResult.FromBoolean(action != null,404,"Действие с данным id не найдено"),
                () => RequestResult.FromBoolean(action.CorruptionCaseId == item.Id,403,"Действие не принадлежит текущему коррупционному инциденту"),
            });
        }

        #endregion
    }
}
