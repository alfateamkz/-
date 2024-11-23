using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Sales.API.Models.DTO.Customers.Categories;
using Alfateam.Sales.API.Models.DTO.Customers;

namespace Alfateam.Sales.API.Controllers.Customers
{
    [Route("Customers/[controller]")]
    public class PersonContactsController : AbsController
    {
        public PersonContactsController(ControllerParams @params) : base(@params)
        {
        }

        #region Клиенты

        [HttpGet, Route("GetPersonContacts")]
        public async Task<ItemsWithTotalCount<PersonContactDTO>> GetPersonContacts(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<PersonContact, PersonContactDTO>(GetAvailableCustomers(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.FIO.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetPersonContact")]
        public async Task<PersonContactDTO> GetPersonContact(int id)
        {
            return (PersonContactDTO)DBService.TryGetOne(GetAvailableCustomers(), id, new PersonContactDTO());
        }



        [HttpPost, Route("CreatePersonContact")]
        public async Task<PersonContactDTO> CreatePersonContact(PersonContactDTO model)
        {
            return (PersonContactDTO)DBService.TryCreateEntity(DB.PersonContacts, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                entity.CreatedById = this.AuthorizedUser.Id;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление клиента", $"Добавлен клиент {entity.FIO}");
            });
        }

        [HttpPut, Route("UpdatePersonContact")]
        public async Task<PersonContactDTO> UpdatePersonContact(PersonContactDTO model)
        {
            var item = GetAvailableCustomers().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PersonContactDTO)DBService.TryUpdateEntity(DB.PersonContacts, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование клиента", $"Отредактирован клиент с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeletePersonContact")]
        public async Task DeletePersonContact(int id)
        {
            var item = GetAvailableCustomers().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.PersonContacts, item);

            this.AddHistoryAction("Удаление клиента", $"Удален клиент {item.FIO} с id={id}");
        }



        #endregion

        #region Категории клиентов

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<PersonContactCategoryDTO>> GetCategories(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<PersonContactCategory, PersonContactCategoryDTO>(GetAvailableCustomerCategories(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<PersonContactCategoryDTO> GetCategory(int id)
        {
            return (PersonContactCategoryDTO)DBService.TryGetOne(GetAvailableCustomerCategories(), id, new PersonContactCategoryDTO());
        }





        [HttpPost, Route("CreateCategory")]
        public async Task<PersonContactCategoryDTO> CreateCategory(PersonContactCategoryDTO model)
        {
            return (PersonContactCategoryDTO)DBService.TryCreateEntity(DB.PersonContactCategories, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории клиентов", $"Добавлена категория клиентов {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<PersonContactCategoryDTO> UpdateCategory(PersonContactCategoryDTO model)
        {
            var item = GetAvailableCustomerCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PersonContactCategoryDTO)DBService.TryUpdateEntity(DB.PersonContactCategories, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории клиентов", $"Отредактирована категории клиентов с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCustomerCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.PersonContactCategories, item);

            this.AddHistoryAction("Удаление категории клиентов", $"Удален категория клиентов {item.Title} с id={id}");
        }



        #endregion






        #region Private methods

        private IEnumerable<PersonContact> GetAvailableCustomers()
        {
            return DB.PersonContacts.Include(o => o.Category)
                                    .Include(o => o.CreatedBy)
                                    .Include(o => o.Contacts)
                                    .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);

            //var user = this.AuthorizedUser;

            //if (user.Role == UserRole.Owner)
            //{
            //    return DB.Customers.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
            //}
            //return DB.Customers.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId && o.CreatedById == user.Id);
        }
        private IEnumerable<PersonContactCategory> GetAvailableCustomerCategories()
        {
            return DB.PersonContactCategories.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
