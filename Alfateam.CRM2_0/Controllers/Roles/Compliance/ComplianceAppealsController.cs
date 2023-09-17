using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceAppealsController : AbsController
    {
        public ComplianceAppealsController(ControllerParams @params) : base(@params)
        {
        }

        #region Обращения в комплаенс-службу

        [HttpGet, Route("GetAppeals")]
        public async Task<RequestResult> GetAppeals(bool actual, int offset, int count = 20)
        {
            var queryable = DB.Appeals.Include(o => o.From)
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

            return GetMany<Appeal, AppealClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetAppeal")]
        public async Task<RequestResult> GetAppeal(int id)
        {
            var item = DB.CorruptionCases.Include(o => o.InitDetails)
                                         .Include(o => o.Result)
                                         .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(item),
                () => RequestResult<CorruptionCase>.AsSuccess(item)
            });
        }


        #endregion

        #region Действия по обращению

        [HttpGet, Route("GetAppealActions")]
        public async Task<RequestResult> GetAppealActions(int id)
        {
            var appeal = DB.Appeals.Include(o => o.Actions)
                                   .FirstOrDefault(o => o.Id == id);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(appeal),
                () =>
                {
                    var clientModels = AppealActionClientModel.CreateItems(appeal.Actions);
                    return RequestResult<IEnumerable<AppealActionClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetAppealAction")]
        public async Task<RequestResult> GetAppealAction(int appealId, int actionId)
        {
            var appeal = DB.Appeals.FirstOrDefault(o => o.Id == appealId);
            var action = DB.AppealActions.FirstOrDefault(o => o.Id == actionId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppealAndAction(item,action),
                () => RequestResult<AppealAction>.AsSuccess(action)
            });
        }


        [HttpPost, Route("CreateAppealAction")]
        public async Task<RequestResult> CreateAppealAction(int appealId, AppealActionCreateModel model)
        {
            var appeal = DB.Appeals.FirstOrDefault(o => o.Id == appealId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppealToEdit(item),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var action = model.Create();
                    appeal.Actions.Add(action);

                    UpdateModel(DB.Appeals, appeal);
                    return RequestResult<AppealAction>.AsSuccess(action);
                }
            });
        }


        #endregion

        #region Результат обращения

        [HttpPut, Route("SetAppealResult")]
        public async Task<RequestResult> SetAppealResult(int appealId, AppealResultCreateModel model)
        {
            var appeal = DB.Appeals.FirstOrDefault(o => o.Id == appealId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppealToEdit(appeal),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var result = model.Create();
                    appeal.Result = result;

                    UpdateModel(DB.Appeals, appeal);
                    return RequestResult<AppealResult>.AsSuccess(result);
                }
            });
        }

        [HttpPut, Route("SetAppealResultLocked")]
        public async Task<RequestResult> SetAppealResultLocked(int appealId)
        {
            var appeal = DB.Appeals.FirstOrDefault(o => o.Id == appealId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(appeal),
                () => RequestResult.FromBoolean(appeal.ResultId != null, 400, "Результат еще не задан"),
                () => RequestResult.FromBoolean(!appeal.Result.IsLockedForEdit, 403, "Результат обращения закрыт для редактирования"),
                () =>
                {
                    appeal.Result.IsLockedForEdit = true;
                    return UpdateModel(DB.Appeals, appeal);
                }
            });
        }

        #endregion

        #region Действия по результату обращения

        [HttpGet, Route("GetAppealResultActions")]
        public async Task<RequestResult> GetAppealResultActions(int id)
        {
            var appeal = DB.Appeals.Include(o => o.Result).ThenInclude(o => o.Actions)
                                   .FirstOrDefault(o => o.Id == id);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(appeal),
                () => RequestResult.FromBoolean(appeal.ResultId != null, 400, "Результат еще не задан"),
                () =>
                {
                    var clientModels = AppealResultActionClientModel.CreateItems(appeal.Result.Actions);
                    return RequestResult<IEnumerable<AppealResultActionClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetAppealResultAction")]
        public async Task<RequestResult> GetAppealResultAction(int appealId, int actionId)
        {
            var appeal = DB.Appeals.FirstOrDefault(o => o.Id == appealId);
            var action = DB.AppealResultActions.FirstOrDefault(o => o.Id == actionId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppealAndResultAction(appeal, action),
                () => RequestResult<AppealResultAction>.AsSuccess(action)
            });
        }


        [HttpPost, Route("CreateAppealResultAction")]
        public async Task<RequestResult> CreateAppealResultAction(int appealId, AppealResultActionCreateModel model)
        {
            var appeal = DB.Appeals.FirstOrDefault(o => o.Id == appealId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(appeal),
                () => RequestResult.FromBoolean(appeal.ResultId != null, 400, "Результат еще не задан"),
                () => RequestResult.FromBoolean(!appeal.Result.IsLockedForEdit, 403, "Результат обращения закрыт для редактирования"),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var action = model.Create();
                    appeal.Result.Actions.Add(action);

                    UpdateModel(DB.Appeals, appeal);
                    return RequestResult<AppealResultAction>.AsSuccess(action);
                }
            });
        }


        [HttpPut, Route("SetAppealResultActionStatus")]
        public async Task<RequestResult> SetAppealResultActionStatus(int appealId, int actionId, AppealResultActionStatus status)
        {
            var appeal = DB.Appeals.FirstOrDefault(o => o.Id == appealId);
            var action = DB.AppealResultActions.FirstOrDefault(o => o.Id == actionId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppealAndResultActionToEdit(appeal, action),
                () =>
                {
                    action.Status = status;
                    return UpdateModel(DB.AppealResultActions, action);
                }
            });
        }

        #endregion







        #region Private check methods

        private RequestResult CheckBaseAppeal(Appeal item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Обращение с данным id не найдено"),
                () => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному обращению"),
            });
        }
        private RequestResult CheckBaseAppealToEdit(Appeal item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(item),
                () => RequestResult.FromBoolean(item.ResultId == null,403,"Обращение уже обработано. Редактирование невозможно"),
            });
        }



        private RequestResult CheckBaseAppealAndAction(Appeal item, AppealAction action)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(item),
                () => CheckBaseAction(item, action),
            });
        }
        private RequestResult CheckBaseAppealAndActionToEdit(Appeal item, AppealAction action)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppealToEdit(item),
                () => CheckBaseAction(item, action),
            });
        }



        private RequestResult CheckBaseAppealAndResultAction(Appeal item, AppealResultAction action)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppeal(item),
                () => RequestResult.FromBoolean(appeal.ResultId != null, 400, "Результат еще не задан"),
                () => CheckBaseResultAction(item, action),
            });
        }
        private RequestResult CheckBaseAppealAndResultActionToEdit(Appeal item, AppealResultAction action)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAppealAndResultAction(item,action),
                () => RequestResult.FromBoolean(!appeal.Result.IsLockedForEdit, 403, "Результат обращения закрыт для редактирования"),
            });
        }



        private RequestResult CheckBaseAction(Appeal item, AppealAction action)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(action != null,404,"Действие с данным id не найдено"),
                () => RequestResult.FromBoolean(action.AppealId == item.Id,403,"Действие не принадлежит данному обращению"),
            });
        }
        private RequestResult CheckBaseResultAction(Appeal item, AppealResultAction action)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(action != null,404,"Действие с данным id не найдено"),
                () => RequestResult.FromBoolean(action.AppealResultId == item.ResultId,403,"Действие не принадлежит данному обращению"),
            });
        }

        #endregion
    }
}
