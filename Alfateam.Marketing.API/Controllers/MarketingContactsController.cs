using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO;
using Alfateam.Marketing.API.Models.SearchFilters;
using Alfateam.Marketing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers
{
    public class MarketingContactsController : AbsController
    {
        public MarketingContactsController(ControllerParams @params) : base(@params)
        {
        }



        #region Контакты

        [HttpGet, Route("GetMarketingContacts")]
        public async Task<ItemsWithTotalCount<MarketingContactDTO>> GetMarketingContacts(MarketingContactsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<MarketingContact, MarketingContactDTO>(GetAvailableMarketingContacts(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Contact.Contact.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.ContactType != null)
                {
                    condition &= entity.Contact.Type == filter.ContactType;
                }
                if (filter.FromAlfateamSalesCRM != null)
                {
                    condition &= entity.FromAlfateamSalesCRM = (bool)filter.FromAlfateamSalesCRM;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetMarketingContact")]
        public async Task<MarketingContactDTO> GetMarketingContact(int id)
        {
            return (MarketingContactDTO)DBService.TryGetOne(GetAvailableMarketingContacts(), id, new MarketingContactDTO());
        }





        [HttpPost, Route("CreateMarketingContact")]
        public async Task<MarketingContactDTO> CreateMarketingContact(MarketingContactDTO model)
        {
            return (MarketingContactDTO)DBService.TryCreateEntity(DB.MarketingContacts, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление контакта", $"Добавлен контакт{entity.Contact.Contact}");
            });
        }

        [HttpPut, Route("UpdateMarketingContact")]
        public async Task<MarketingContactDTO> UpdateMarketingContact(MarketingContactDTO model)
        {
            var item = GetAvailableMarketingContacts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (MarketingContactDTO)DBService.TryUpdateEntity(DB.MarketingContacts, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование контакта", $"Отредактирован контакт с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteMarketingContact")]
        public async Task DeleteMarketingContact(int id)
        {
            var item = GetAvailableMarketingContacts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.MarketingContacts, item);

            this.AddHistoryAction("Удаление контакта", $"Удален контакт {item.Contact.Contact} с id={id}");
        }






        #endregion








        #region Private methods

        private IEnumerable<MarketingContact> GetAvailableMarketingContacts()
        {
            var contacts = DB.MarketingContacts.Include(o => o.Contact)
                                               .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId)
                                               .ToList();

            //TODO: сделать подгрузку из CRM продажи, если имеется продукт


            return contacts;
        }

        #endregion
    }
}
