﻿using Alfateam.Core.Exceptions;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Filters;
using Alfateam.TicketSystem.API.Helpers;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models.DTO.General;
using Alfateam.TicketSystem.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.TicketSystem.API.Controllers.Owner
{
    [Route("Owner/[controller]")]
    [RequiredRole(UserRole.Owner)]
    public class DepartmentsController : AbsAuthorizedController
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
