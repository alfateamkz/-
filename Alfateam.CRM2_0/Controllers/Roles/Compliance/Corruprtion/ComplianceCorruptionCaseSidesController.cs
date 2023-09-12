using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Corruprtion
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Compliance)]
    public class ComplianceCorruptionCaseSidesController : AbsController
    {
        public ComplianceCorruptionCaseSidesController(ControllerParams @params) : base(@params)
        {
        }


        #region Стороны коррупционного инцидиента

        [HttpGet, Route("GetSides")]
        public async Task<RequestResult> GetSides(int caseId)
        {
            var item = DB.CorruptionCases.Include(o => o.Sides)
                                         .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () =>
                {
                    item.Sides = item.Sides.Where(o => !o.IsDeleted).ToList();

                    var clientModels = CorruptionCaseSideClientModel.CreateItems(item.Sides);
                    return RequestResult<IEnumerable<CorruptionCaseSideClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetSide")]
        public async Task<RequestResult> GetSide(int caseId, int sideId)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var side = DB.CorruptionCaseSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndSide(item,side),
                () => RequestResult<CorruptionCaseSide>.AsSuccess(side)
            });
        }



        [HttpPost, Route("CreateSide")]
        public async Task<RequestResult> CreateSide(int caseId, CorruptionCaseSideCreateModel model)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseToEdit(item),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var side = model.Create();
                    item.Sides.Add(side);

                    UpdateModel(DB.CorruptionCases, item);
                    return RequestResult<CorruptionCaseSide>.AsSuccess(side);
                }
            });
        }

        [HttpPut, Route("UpdateSide")]
        public async Task<RequestResult> UpdateSide(int caseId, CorruptionCaseSideEditModel model)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var side = DB.CorruptionCaseSides.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndSideToEdit(item, side),
                () => TryUpdateModel(DB.CorruptionCaseSides, side, model),
            });
        }

        [HttpDelete, Route("DeleteSide")]
        public async Task<RequestResult> DeleteSide(int caseId, int sideId)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var side = DB.CorruptionCaseSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndSideToEdit(item, side),
                () => DeleteModel(DB.CorruptionCaseSides, side),
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


        private RequestResult CheckBaseCorruptionCaseAndSide(CorruptionCase item, CorruptionCaseSide side)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () => CheckBaseCorruptionCaseSide(side),
            });
        }
        private RequestResult CheckBaseCorruptionCaseAndSideToEdit(CorruptionCase item, CorruptionCaseSide side)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseToEdit(item),
                () => CheckBaseCorruptionCaseSide(side),
            });
        }




        private RequestResult CheckBaseCorruptionCaseSide(CorruptionCaseSide side)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(side != null,404,"Сторона с данным id не найдена"),
                () => RequestResult.FromBoolean(side.CorruptionCaseId == item.Id,403,"Сторона не принадлежит данному инциденту"),
            });
        }

        #endregion


    }
}
