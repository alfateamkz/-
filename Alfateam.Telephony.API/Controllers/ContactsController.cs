using Alfateam.Core;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO.Contacts;
using Alfateam.Telephony.API.Models.SearchFilters;
using Alfateam.Telephony.Models.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Telephony.API.Controllers
{
    public class ContactsController : AbsAuthorizedController
    {
        public ContactsController(ControllerParams @params) : base(@params)
        {
        }


        #region Контакты

        [HttpGet, Route("GetContacts")]
        public async Task<ItemsWithTotalCount<ContactDTO>> GetContacts(ContactsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Contact, ContactDTO>(GetAvailableContacts(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Phone.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                              || entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.CategoryId != null)
                {
                    condition &= entity.CategoryId == filter.CategoryId;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetContact")]
        public async Task<ContactDTO> GetContact(int id)
        {
            return (ContactDTO)DBService.TryGetOne(GetAvailableContacts(), id, new ContactDTO());
        }



        [HttpPost, Route("CreateContact")]
        public async Task<ContactDTO> CreateContact(ContactDTO model)
        {
            return (ContactDTO)DBService.TryCreateEntity(DB.Contacts, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление контакта", $"Добавлен контакт {entity.Phone}");
            });
        }

        [HttpPut, Route("UpdateContact")]
        public async Task<ContactDTO> UpdateContact(ContactDTO model)
        {
            var item = GetAvailableContacts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ContactDTO)DBService.TryUpdateEntity(DB.Contacts, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование контакта", $"Отредактирован контакт с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteContact")]
        public async Task DeleteContact(int id)
        {
            var item = GetAvailableContacts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Contacts, item);

            this.AddHistoryAction("Удаление контакта", $"Удален контакт {item.Phone} с id={id}");
        }


        #endregion

        #region Категории контактов

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<ContactCategoryDTO>> GetCategories(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ContactCategory, ContactCategoryDTO>(GetAvailableCategories(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<ContactCategoryDTO> GetCategory(int id)
        {
            return (ContactCategoryDTO)DBService.TryGetOne(GetAvailableCategories(), id, new ContactCategoryDTO());
        }





        [HttpPost, Route("CreateCategory")]
        public async Task<ContactCategoryDTO> CreateCategory(ContactCategoryDTO model)
        {
            return (ContactCategoryDTO)DBService.TryCreateEntity(DB.ContactCategories, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории контактов", $"Добавлена категория контактов {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<ContactCategoryDTO> UpdateCategory(ContactCategoryDTO model)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ContactCategoryDTO)DBService.TryUpdateEntity(DB.ContactCategories, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории контактов", $"Отредактирована категории контактов с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.ContactCategories, item);

            this.AddHistoryAction("Удаление категории контактов", $"Удален категория контактов {item.Title} с id={id}");
        }



        #endregion








        #region Private methods


        private IEnumerable<Contact> GetAvailableContacts()
        {
            return DB.Contacts.Include(o => o.Category)
                              .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<ContactCategory> GetAvailableCategories()
        {
            return DB.ContactCategories.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion


    }
}
