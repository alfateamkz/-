using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Autoposting;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting;
using Alfateam.Sales.Models.Customers.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Marketing.API.Controllers.Autoposting
{
    public class AutopostingAccountsController : AbsController
    {
        public AutopostingAccountsController(ControllerParams @params) : base(@params)
        {
        }

        #region Аккаунты

        [HttpGet, Route("GetAutopostingAccounts")]
        public async Task<ItemsWithTotalCount<AutopostingAccountDTO>> GetAutopostingAccounts(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<AutopostingAccount, AutopostingAccountDTO>(GetAvailableAccounts(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetAutopostingAccount")]
        public async Task<AutopostingAccountDTO> GetAutopostingAccount(int id)
        {
            return (AutopostingAccountDTO)DBService.TryGetOne(GetAvailableAccounts(), id, new AutopostingAccountDTO());
        }





        [HttpPost, Route("CreateAutopostingAccount")]
        public async Task<AutopostingAccountDTO> CreateAutopostingAccount(AutopostingAccountDTO model)
        {
            return (AutopostingAccountDTO)DBService.TryCreateEntity(DB.AutopostingAccounts, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление аккаунта для автопостинга", $"Добавлен аккаунт для автопостинга {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateAutopostingAccount")]
        public async Task<AutopostingAccountDTO> UpdateAutopostingAccount(AutopostingAccountDTO model)
        {
            var item = GetAvailableAccounts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (AutopostingAccountDTO)DBService.TryUpdateEntity(DB.AutopostingAccounts, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование аккаунта для автопостинга", $"Отредактирован аккаунт для автопостинга с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteAutopostingAccount")]
        public async Task DeleteAutopostingAccount(int id)
        {
            var item = GetAvailableAccounts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.AutopostingAccounts, item);

            this.AddHistoryAction("Удаление аккаунта для автопостинга", $"Удален аккаунт для автопостинга {item.Title} с id={id}");
        }


        #endregion

        #region Категории аккаунтов

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<AutopostingAccountCategoryDTO>> GetCategories(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<AutopostingAccountCategory, AutopostingAccountCategoryDTO>(GetAvailableCategories(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<AutopostingAccountCategoryDTO> GetCategory(int id)
        {
            return (AutopostingAccountCategoryDTO)DBService.TryGetOne(GetAvailableCategories(), id, new AutopostingAccountCategoryDTO());
        }





        [HttpPost, Route("CreateCategory")]
        public async Task<AutopostingAccountCategoryDTO> CreateCategory(AutopostingAccountCategoryDTO model)
        {
            return (AutopostingAccountCategoryDTO)DBService.TryCreateEntity(DB.AutopostingAccountCategories, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление аккаунта для автопостинга", $"Добавлен аккаунт для автопостинга {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<AutopostingAccountCategoryDTO> UpdateCategory(AutopostingAccountCategoryDTO model)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (AutopostingAccountCategoryDTO)DBService.TryUpdateEntity(DB.AutopostingAccountCategories, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование аккаунта для автопостинга", $"Отредактирован аккаунт для автопостинга с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.AutopostingAccountCategories, item);

            this.AddHistoryAction("Удаление аккаунта для автопостинга", $"Удален аккаунт для автопостинга {item.Title} с id={id}");
        }


        #endregion







        #region Private methods

        private IEnumerable<AutopostingAccount> GetAvailableAccounts()
        {
            return DB.AutopostingAccounts.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private IEnumerable<AutopostingAccountCategory> GetAvailableCategories()
        {
            return DB.AutopostingAccountCategories.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
