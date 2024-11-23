using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Customers.Categories;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Sales.API.Models.DTO.Customers;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Sales.API.Models.DTO.Customers.Other;

namespace Alfateam.Sales.API.Controllers.Customers
{
    [Route("Customers/[controller]")]
    public class CompaniesController : AbsController
    {
        public CompaniesController(ControllerParams @params) : base(@params)
        {
        }


        #region Компании

        [HttpGet, Route("GetCompanies")]
        public async Task<ItemsWithTotalCount<CompanyDTO>> GetCompanies(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Company, CompanyDTO>(GetAvailableCompanies(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Info.LegalName.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCompany")]
        public async Task<CompanyDTO> GetCompany(int id)
        {
            return (CompanyDTO)DBService.TryGetOne(GetAvailableCompanies(), id, new CompanyDTO());
        }



        [HttpPost, Route("CreateCompany")]
        public async Task<CompanyDTO> CreateCompany(CompanyDTO model)
        {
            return (CompanyDTO)DBService.TryCreateEntity(DB.Companies, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                entity.CreatedById = this.AuthorizedUser.Id;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление клиента", $"Добавлен клиент {entity.Info.LegalName}");
            });
        }

        [HttpPut, Route("UpdateCompany")]
        public async Task<CompanyDTO> UpdateCompany(CompanyDTO model)
        {
            var item = GetAvailableCompanies().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CompanyDTO)DBService.TryUpdateEntity(DB.Companies, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование клиента", $"Отредактирован клиент с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCompany")]
        public async Task DeleteCompany(int id)
        {
            var item = GetAvailableCompanies().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Companies, item);

            this.AddHistoryAction("Удаление клиента", $"Удален клиент {item.Info.LegalName} с id={id}");
        }


        #endregion

        #region Категории компаний

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<CompanyCategoryDTO>> GetCategories(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<CompanyCategory, CompanyCategoryDTO>(GetAvailableCategories(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<CompanyCategoryDTO> GetCategory(int id)
        {
            return (CompanyCategoryDTO)DBService.TryGetOne(GetAvailableCategories(), id, new CompanyCategoryDTO());
        }





        [HttpPost, Route("CreateCategory")]
        public async Task<CompanyCategoryDTO> CreateCategory(CompanyCategoryDTO model)
        {
            return (CompanyCategoryDTO)DBService.TryCreateEntity(DB.CompanyCategories, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории клиентов", $"Добавлена категория клиентов {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<CompanyCategoryDTO> UpdateCategory(CompanyCategoryDTO model)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CompanyCategoryDTO)DBService.TryUpdateEntity(DB.CompanyCategories, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории клиентов", $"Отредактирована категории клиентов с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.CompanyCategories, item);

            this.AddHistoryAction("Удаление категории клиентов", $"Удален категория клиентов {item.Title} с id={id}");
        }



        #endregion

        #region Виды деятельности компаний

        [HttpGet, Route("GetFieldsOfActivity")]
        public async Task<ItemsWithTotalCount<CompanyFieldOfActivityDTO>> GetFieldsOfActivity(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<CompanyFieldOfActivity, CompanyFieldOfActivityDTO>(GetAvailableFieldsOfActivity(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetFieldOfActivity")]
        public async Task<CompanyFieldOfActivityDTO> GetFieldOfActivity(int id)
        {
            return (CompanyFieldOfActivityDTO)DBService.TryGetOne(GetAvailableFieldsOfActivity(), id, new CompanyFieldOfActivityDTO());
        }





        [HttpPost, Route("CreateFieldOfActivity")]
        public async Task<CompanyFieldOfActivityDTO> CreateFieldOfActivity(CompanyFieldOfActivityDTO model)
        {
            return (CompanyFieldOfActivityDTO)DBService.TryCreateEntity(DB.CompanyFieldsOfActivity, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление вида деятельности компаний", $"Добавлен вид деятельности компаний {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateFieldOfActivity")]
        public async Task<CompanyFieldOfActivityDTO> UpdateFieldOfActivity(CompanyFieldOfActivityDTO model)
        {
            var item = GetAvailableFieldsOfActivity().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CompanyFieldOfActivityDTO)DBService.TryUpdateEntity(DB.CompanyFieldsOfActivity, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование вида деятельности компаний", $"Отредактирован вид деятельности компаний с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteFieldOfActivity")]
        public async Task DeleteFieldOfActivity(int id)
        {
            var item = GetAvailableFieldsOfActivity().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.CompanyFieldsOfActivity, item);

            this.AddHistoryAction("Удаление категории клиентов", $"Удален категория клиентов {item.Title} с id={id}");
        }


        #endregion






        #region Private methods

        private IEnumerable<Company> GetAvailableCompanies()
        {
            return DB.Companies.Include(o => o.Category)
                               .Include(o => o.CreatedBy)
                               .Include(o => o.Contacts)
                               .Include(o => o.FieldOfActivity)
                               .Include(o => o.Info)
                               .Include(o => o.Details)
                               .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<CompanyCategory> GetAvailableCategories()
        {
            return DB.CompanyCategories.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<CompanyFieldOfActivity> GetAvailableFieldsOfActivity()
        {
            return DB.CompanyFieldsOfActivity.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
