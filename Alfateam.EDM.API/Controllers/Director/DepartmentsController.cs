using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Helpers;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.EDM.API.Controllers.Director
{
    [MustBeCompany]
    [RequiredRole(UserRole.Owner)]
    public class DepartmentsController : AbsAuthorizedController
    {
        public DepartmentsController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetDepartmentsTree")]
        public async Task<DepartmentDTO> GetDepartmentsTree()
        {
            var subjects = DB.EDMSubjects.Include(o => o.Department)
                                         .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var subject = DBService.TryGetOne(subjects, (int)this.EDMSubjectId);

            DepartmentsHelper.HideSoftDeletedDepartments(subject.Department);
            return (DepartmentDTO)new DepartmentDTO().CreateDTO(subject.Department);
        }


        [HttpPost, Route("CreateDepartment")]
        public async Task<DepartmentDTO> CreateDepartment(int parentDepartmentId, DepartmentDTO model)
        {
            var subjects = DB.EDMSubjects.Include(o => o.Department)
                                    .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var subject = DBService.TryGetOne(subjects, (int)this.EDMSubjectId);

            var allDepartments = DB.Departments.Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
            DBService.TryGetOne(allDepartments, parentDepartmentId);

            return (DepartmentDTO)DBService.TryCreateEntity(DB.Departments, model, (entity) =>
            {
                entity.DepartmentId = parentDepartmentId;
            });
        }

        [HttpPut, Route("UpdateDepartment")]
        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO model)
        {
            var subjects = DB.EDMSubjects.Include(o => o.Department)
                                         .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var subject = DBService.TryGetOne(subjects, (int)this.EDMSubjectId);

            var allDepartments = DB.Departments.Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
            var department = DBService.TryGetOne(allDepartments, model.Id);

            return (DepartmentDTO)DBService.TryUpdateEntity(DB.Departments, model, department);
        }


        [HttpDelete, Route("DeleteDepartment")]
        public async Task DeleteDepartment(int id)
        {
            var subjects = DB.EDMSubjects.Include(o => o.Department).ThenInclude(o => o.Documents)
                                         .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var subject = DBService.TryGetOne(subjects, (int)this.EDMSubjectId);


            var allDepartments = DB.Departments.Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
            var department = DBService.TryGetOne(allDepartments, id);

            if (department.IsRoot)
            {
                throw new Exception403("Невозможно удалить головное подразделение");
            }

            DepartmentsHelper.HideSoftDeletedDepartments(department);
            var thisDepAndSubDepartments = DepartmentsHelper.GetThisAndAllSubDepartments(department, true);


            var documentsToReplace = new List<Document>();
            foreach(var dep in thisDepAndSubDepartments)
            {
                documentsToReplace.AddRange(dep.Documents);
                dep.Documents = new List<Document>();
            }
            subject.Department.Documents.AddRange(documentsToReplace);

            DBService.DeleteEntities(DB.Departments, thisDepAndSubDepartments);
            DBService.UpdateEntity(DB.EDMSubjects, subject);
        }






    }
}
