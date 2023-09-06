using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Accountance;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.EditModels.Roles.Accountance;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Accountance
{
    [AccessActionFilter(roles: UserRole.Accountant)]
    [DepartmentFilter]
    public class AccountanceController : AbsController
    {
        public AccountanceController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: добавить методы получения по цепочке вверх

        #region Счета

        [HttpGet,Route("GetAccounts")]
        public async Task<RequestResult> GetAccounts(int offset, int count = 20)
        {
            return GetMany<Account, AccountClientModel>(DB.Accounts.Where(o => o.AccountanceDepartmentId == this.DepartmentId), offset, count);
        }

        [HttpGet, Route("GetAccount")]
        public async Task<RequestResult> GetAccount(int id)
        {
            return TryGetModel(DB.Accounts.Where(o => o.AccountanceDepartmentId == this.DepartmentId), id);
        }

        [HttpPost, Route("CreateAccount")]
        public async Task<RequestResult> CreateAccount(AccountCreateModel model)
        {
            return TryCreateModel(DB.Accounts, model, (item) =>
            {
                item.AccountanceDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }

        [HttpPut, Route("UpdateAccount")]
        public async Task<RequestResult> UpdateAccount(AccountEditModel model)
        {
            return TryUpdateModel(DB.Accounts, model);
        }


        [HttpDelete, Route("DeleteAccount")]
        public async Task<RequestResult> DeleteAccount(int id)
        {
            var account = DB.Accounts.Include(o => o.Transactions)
                                      .FirstOrDefault(o => o.AccountanceDepartmentId == this.DepartmentId
                                                      && o.Id == id);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(account != null, 404, "Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(!account.Transactions.Any(o => !o.IsDeleted), 403, "Невозможно удалить счет, т.к. он имеет транзакции"),
                () => DeleteModel(DB.Accounts, account)
            });

        }

        #endregion
    }
}
