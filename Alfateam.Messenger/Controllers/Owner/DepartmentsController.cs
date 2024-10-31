using Alfateam.Core.Exceptions;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Helpers;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.General;
using Alfateam.Messenger.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Messenger.API.Controllers.Owner
{
    public class DepartmentsController : AbsController
    {
        public DepartmentsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetDepartmentsTree")]
        public async Task<DepartmentDTO> GetDepartmentsTree()
        {
            var workspace = TryGetWorkSpaceIncluded();

            DepartmentsHelper.HideSoftDeletedDepartments(workspace.Department);
            return (DepartmentDTO)new DepartmentDTO().CreateDTO(workspace.Department);
        }


        [HttpPost, Route("CreateDepartment")]
        public async Task<DepartmentDTO> CreateDepartment(int parentDepartmentId, DepartmentDTO model)
        {
            TryGetWorkSpaceDepartment(TryGetWorkSpaceIncluded(), parentDepartmentId);
            return (DepartmentDTO)DBService.TryCreateEntity(DB.Departments, model, (entity) =>
            {
                entity.DepartmentId = parentDepartmentId;
            });
        }

        [HttpPut, Route("UpdateDepartment")]
        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO model)
        {
            var department = TryGetWorkSpaceDepartment(TryGetWorkSpaceIncluded(), model.Id);
            return (DepartmentDTO)DBService.TryUpdateEntity(DB.Departments, model, department);
        }


        [HttpDelete, Route("DeleteDepartment")]
        public async Task DeleteDepartment(int id)
        {
            var workspace = TryGetWorkSpaceIncluded();
            var department = TryGetWorkSpaceDepartment(workspace, id);

            if (department.IsRoot)
            {
                throw new Exception403("Невозможно удалить головное подразделение");
            }

            DepartmentsHelper.HideSoftDeletedDepartments(department);        
            DBService.UpdateEntity(DB.CompanyWorkSpaces, workspace);
        }







        #region Private methods
        private CompanyWorkSpace TryGetWorkSpaceIncluded()
        {
            var workspaces = DB.CompanyWorkSpaces.Include(o => o.Department)
                                      .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            return DBService.TryGetOne(workspaces, (int)this.WorkspaceID);
        }

        private Department TryGetWorkSpaceDepartment(CompanyWorkSpace workspace, int departmentId)
        {
            var allDepartments = DB.Departments.Where(o => o.CompanyWorkSpaceId == workspace.Id && !o.IsDeleted);
            return DBService.TryGetOne(allDepartments, departmentId);
        }

        #endregion
    }
}
