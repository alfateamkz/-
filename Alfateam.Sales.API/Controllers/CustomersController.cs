using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models;
using Alfateam.Sales.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers
{
    public class CustomersController : AbsController
    {
        public CustomersController(ControllerParams @params) : base(@params)
        {
        }


        #region Клиенты

        [HttpGet, Route("GetCustomers")]
        public async Task<ItemsWithTotalCount<CustomerDTO>> GetCustomers(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Customer, CustomerDTO>(GetAvailableCustomers(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.FIO.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCustomer")]
        public async Task<CustomerDTO> GetCustomer(int id)
        {
            return (CustomerDTO)DBService.TryGetOne(GetAvailableCustomers(), id, new CustomerDTO());
        }



        [HttpPost, Route("CreateCustomer")]
        public async Task<CustomerDTO> CreateCustomer(CustomerDTO model)
        {
            return (CustomerDTO)DBService.TryCreateEntity(DB.Customers, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                entity.CreatedById = this.AuthorizedUser.Id;
            }, 
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление клиента", $"Добавлен клиент {entity.FIO}");
            });
        }

        [HttpPut, Route("UpdateCustomer")]
        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO model)
        {
            var item = GetAvailableCustomers().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CustomerDTO)DBService.TryUpdateEntity(DB.Customers, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование клиента", $"Отредактирован клиент с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCustomer")]
        public async Task DeleteCustomer(int id)
        {
            var item = GetAvailableCustomers().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Customers, item);

            this.AddHistoryAction("Удаление клиента", $"Удален клиент {item.FIO} с id={id}");
        }



        #endregion

        #region Категории клиентов

        [HttpGet, Route("GetCustomerCategories")]
        public async Task<ItemsWithTotalCount<CustomerCategoryDTO>> GetSaleFunnelStageTypes(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<CustomerCategory, CustomerCategoryDTO>(GetAvailableCustomerCategories(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCustomerCategory")]
        public async Task<CustomerCategoryDTO> GetCustomerCategory(int id)
        {
            return (CustomerCategoryDTO)DBService.TryGetOne(GetAvailableCustomerCategories(), id, new CustomerCategoryDTO());
        }





        [HttpPost, Route("CreateCustomerCategory")]
        public async Task<CustomerCategoryDTO> CreateCustomerCategory(CustomerCategoryDTO model)
        {
            return (CustomerCategoryDTO)DBService.TryCreateEntity(DB.CustomerCategories, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории клиентов", $"Добавлена категория клиентов {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateCustomerCategory")]
        public async Task<CustomerCategoryDTO> UpdateCustomerCategory(CustomerCategoryDTO model)
        {
            var item = GetAvailableCustomerCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CustomerCategoryDTO)DBService.TryUpdateEntity(DB.CustomerCategories, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории клиентов", $"Отредактирована категории клиентов с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCustomerCategory")]
        public async Task DeleteCustomerCategory(int id)
        {
            var item = GetAvailableCustomerCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.CustomerCategories, item);

            this.AddHistoryAction("Удаление категории клиентов", $"Удален категория клиентов {item.Title} с id={id}");
        }



        #endregion






        #region Private methods

        private IEnumerable<Customer> GetAvailableCustomers()
        {
            return DB.Customers.Include(o => o.Category)
                               .Include(o => o.CompanyInfo)
                               .Include(o => o.CreatedBy)
                               .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);

            //var user = this.AuthorizedUser;

            //if (user.Role == UserRole.Owner)
            //{
            //    return DB.Customers.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
            //}
            //return DB.Customers.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId && o.CreatedById == user.Id);
        }
        private IEnumerable<CustomerCategory> GetAvailableCustomerCategories()
        {
            return DB.CustomerCategories.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion

    }
}
