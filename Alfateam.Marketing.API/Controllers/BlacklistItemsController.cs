using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO;
using Alfateam.Marketing.API.Models.DTO.Autoposting;
using Alfateam.Marketing.API.Models.SearchFilters;
using Alfateam.Marketing.Models;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers
{
    public class BlacklistItemsController : AbsController
    {
        public BlacklistItemsController(ControllerParams @params) : base(@params)
        {
        }


        #region Черный список контактов

        [HttpGet, Route("GetBlacklistItems")]
        public async Task<ItemsWithTotalCount<BlacklistItemDTO>> GetBlacklistItems(BlacklistItemsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BlacklistItem, BlacklistItemDTO>(GetAvailableBlacklistItems(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Contact.Contact.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.ContactType != null)
                {
                    condition &= entity.Contact.Type == filter.ContactType;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetBlacklistItem")]
        public async Task<BlacklistItemDTO> GetBlacklistItem(int id)
        {
            return (BlacklistItemDTO)DBService.TryGetOne(GetAvailableBlacklistItems(), id, new BlacklistItemDTO());
        }





        [HttpPost, Route("CreateBlacklistItem")]
        public async Task<BlacklistItemDTO> CreateBlacklistItem(BlacklistItemDTO model)
        {
            return (BlacklistItemDTO)DBService.TryCreateEntity(DB.BlacklistItems, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление контакта в ЧС", $"Добавлен контакт в ЧС {entity.Contact.Contact}");
            });
        }

        [HttpPut, Route("UpdateBlacklistItem")]
        public async Task<BlacklistItemDTO> UpdateBlacklistItem(BlacklistItemDTO model)
        {
            var item = GetAvailableBlacklistItems().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BlacklistItemDTO)DBService.TryUpdateEntity(DB.BlacklistItems, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование контакта в ЧС", $"Отредактирован контакт в ЧС с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteBlacklistItem")]
        public async Task DeleteBlacklistItem(int id)
        {
            var item = GetAvailableBlacklistItems().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.BlacklistItems, item);

            this.AddHistoryAction("Удаление контакта в ЧС", $"Удален контакт в ЧС {item.Contact.Contact} с id={id}");
        }





        #endregion








        #region Private methods

        private IEnumerable<BlacklistItem> GetAvailableBlacklistItems()
        {
            return DB.BlacklistItems.Include(o => o.Contact)
                                    .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
