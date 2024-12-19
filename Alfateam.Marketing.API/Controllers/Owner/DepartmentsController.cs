using Alfateam.Core.Exceptions;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Helpers;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.General;
using Alfateam.Marketing.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers.Owner
{
    [Route("Owner/[controller]")]
    public class DepartmentsController : AbsController
    {
        public DepartmentsController(ControllerParams @params) : base(@params)
        {
        }


        #region CRUD операции с подразделениями

        [HttpGet, Route("GetDepartmentsTree")]
        public async Task<DepartmentDTO> GetDepartmentsTree()
        {
            var workspace = TryGetCompanyIncluded();

            DepartmentsHelper.HideSoftDeletedDepartments(workspace.Department);
            return (DepartmentDTO)new DepartmentDTO().CreateDTO(workspace.Department);
        }


        [HttpPost, Route("CreateDepartment")]
        public async Task<DepartmentDTO> CreateDepartment(int parentDepartmentId, DepartmentDTO model)
        {
            TryGetCompanyDepartment(TryGetCompanyIncluded(), parentDepartmentId);
            return (DepartmentDTO)DBService.TryCreateEntity(DB.Departments, model, (entity) =>
            {
                entity.DepartmentId = parentDepartmentId;
            });
        }

        [HttpPut, Route("UpdateDepartment")]
        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO model)
        {
            var department = TryGetCompanyDepartment(TryGetCompanyIncluded(), model.Id);
            return (DepartmentDTO)DBService.TryUpdateEntity(DB.Departments, model, department);
        }


        [HttpDelete, Route("DeleteDepartment")]
        public async Task DeleteDepartment(int id)
        {
            var company = TryGetCompanyIncluded();
            var department = TryGetCompanyDepartment(company, id);

            if (department.IsRoot)
            {
                throw new Exception403("Невозможно удалить головное подразделение");
            }

            DepartmentsHelper.HideSoftDeletedDepartments(department);
            DBService.UpdateEntity(DB.BusinessCompanies, company);
        }

        #endregion









        #region Private methods
        private BusinessCompany TryGetCompanyIncluded()
        {
            var companies = DB.BusinessCompanies.Include(o => o.Department)
                                                .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            return DBService.TryGetOne(companies, (int)this.CompanyId);
        }

        private Department TryGetCompanyDepartment(BusinessCompany company, int departmentId)
        {
            var allDepartments = DB.Departments.Where(o => o.BusinessCompanyId == company.Id && !o.IsDeleted);
            return DBService.TryGetOne(allDepartments, departmentId);
        }

        #endregion
    }
}
