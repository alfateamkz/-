using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Helpers;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.API.Models.Filters;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Messenger.API.Controllers.Owner
{
    public class AccountsController : AbsController
    {
        public AccountsController(ControllerParams @params) : base(@params)
        {
        }



        [HttpGet, Route("GetAccounts")]
        public async Task<IEnumerable<AccountDTO>> GetAccounts([FromQuery] AccountsSearchFilter filter)
        {
            var items = filter.Filter(GetAvailableAccounts(), (item) => item.Title);
            return new AccountDTO().CreateDTOs(items).Cast<AccountDTO>();
        }

        [HttpGet, Route("GetAccount")]
        public async Task<AccountDTO> GetAccount(int id)
        {
            return (AccountDTO)DBService.TryGetOne(GetAvailableAccounts(), id, new AccountDTO());
        }




        [HttpPost, Route("CreateAccount")]
        public async Task<AccountDTO> CreateAccount(AccountDTO model)
        {
            return (AccountDTO)DBService.TryCreateEntity(DB.Accounts, model, (entity) =>
            {
                entity.CompanyWorkSpaceId = (int)this.WorkspaceID;
            });
        }

        [HttpPut, Route("UpdateAccount")]
        public async Task<AccountDTO> UpdateAccount(AccountDTO model)
        {
            var account = DBService.TryGetOne(GetAvailableAccounts(), model.Id);
            return (AccountDTO)DBService.TryUpdateEntity(DB.Accounts, model, account);
        }

        [HttpDelete, Route("DeleteAccount")]
        public async Task DeleteAccount(int id)
        {
            var account = DBService.TryGetOne(GetAvailableAccounts(), id);

            AccountsPool.TryRemoveAccount(account);
            DBService.DeleteEntity(DB.Accounts, account);
        }









        #region Private methods

        private IEnumerable<Account> GetAvailableAccounts()
        {
            var user = this.AuthorizedUser;

            if (user.AllowedAccountsAccess.IsAllAccountsAccess)
            {
                return DB.Accounts.Where(o => !o.IsDeleted && o.CompanyWorkSpaceId == this.WorkspaceID);
            }
            else
            {
                return user.AllowedAccountsAccess.AllowedAccounts.Where(o => !o.IsDeleted);
            }

        }


        #endregion
    }
}
