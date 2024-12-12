using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Abstractions.MailingAccounts;
using Alfateam.Marketing.API.Models.DTO.MailingAccounts;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using Alfateam.Marketing.Models.MailingAccounts;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Marketing.API.Controllers.Lettering
{
    public class LetteringAccountsController : AbsController
    {
        public LetteringAccountsController(ControllerParams @params) : base(@params)
        {
        }


        #region Аккаунты

        [HttpGet, Route("GetMailingAccounts")]
        public async Task<ItemsWithTotalCount<MailingAccountDTO>> GetMailingAccounts(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<MailingAccount, MailingAccountDTO>(GetAvailableAccounts(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetMailingAccount")]
        public async Task<MailingAccountDTO> GetMailingAccount(int id)
        {
            return (MailingAccountDTO)DBService.TryGetOne(GetAvailableAccounts(), id, new MailingAccountDTO());
        }





        [HttpPost, Route("CreateMailingAccount")]
        public async Task<MailingAccountDTO> CreateMailingAccount(MailingAccountDTO model)
        {
            return (MailingAccountDTO)DBService.TryCreateEntity(DB.MailingAccounts, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                AddHistoryAction("Добавление аккаунта для рассылки", $"Добавлен аккаунт для рассылки {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateMailingAccount")]
        public async Task<MailingAccountDTO> UpdateMailingAccount(MailingAccountDTO model)
        {
            var item = GetAvailableAccounts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (MailingAccountDTO)DBService.TryUpdateEntity(DB.MailingAccounts, model, item, afterSuccessCallback: (entity) =>
            {
                AddHistoryAction("Редактирование аккаунта для рассылки", $"Отредактирован аккаунт для рассылки с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteMailingAccount")]
        public async Task DeleteMailingAccount(int id)
        {
            var item = GetAvailableAccounts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.MailingAccounts, item);

            AddHistoryAction("Удаление аккаунта для рассылки", $"Удален аккаунт для рассылки {item.Title} с id={id}");
        }


        #endregion

        #region Категории аккаунтов

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<MailingAccountCategoryDTO>> GetCategories(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<MailingAccountCategory, MailingAccountCategoryDTO>(GetAvailableCategories(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<MailingAccountCategoryDTO> GetCategory(int id)
        {
            return (MailingAccountCategoryDTO)DBService.TryGetOne(GetAvailableCategories(), id, new MailingAccountCategoryDTO());
        }





        [HttpPost, Route("CreateCategory")]
        public async Task<MailingAccountCategoryDTO> CreateCategory(MailingAccountCategoryDTO model)
        {
            return (MailingAccountCategoryDTO)DBService.TryCreateEntity(DB.MailingAccountCategories, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                AddHistoryAction("Добавление аккаунта для рассылки", $"Добавлен аккаунт для рассылки {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<MailingAccountCategoryDTO> UpdateCategory(MailingAccountCategoryDTO model)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (MailingAccountCategoryDTO)DBService.TryUpdateEntity(DB.MailingAccountCategories, model, item, afterSuccessCallback: (entity) =>
            {
                AddHistoryAction("Редактирование аккаунта для рассылки", $"Отредактирован аккаунт для рассылки с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.MailingAccountCategories, item);

            AddHistoryAction("Удаление аккаунта для рассылки", $"Удален аккаунт для рассылки {item.Title} с id={id}");
        }


        #endregion










        #region Private methods

        private IEnumerable<MailingAccount> GetAvailableAccounts()
        {
            return DB.MailingAccounts.Where(o => !o.IsDeleted && o.BusinessCompanyId == CompanyId);
        }

        private IEnumerable<MailingAccountCategory> GetAvailableCategories()
        {
            return DB.MailingAccountCategories.Where(o => !o.IsDeleted && o.BusinessCompanyId == CompanyId);
        }

        #endregion
    }
}
