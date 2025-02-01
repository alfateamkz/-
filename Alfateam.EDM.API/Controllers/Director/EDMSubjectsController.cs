using Alfateam.Core;
using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General.Subjects;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.EDM.API.Controllers.Director
{

    [RequiredRole(UserRole.Owner)]
    public class EDMSubjectsController : AbsAuthorizedController
    {
        public EDMSubjectsController(ControllerParams @params) : base(@params)
        {
        }

        #region Субъекты ЭДО

        [HttpGet, Route("GetSubjects")]
        public async Task<ItemsWithTotalCount<EDMSubjectDTO>> GetSubjects([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<EDMSubject, EDMSubjectDTO>(GetAvailableSubjects(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.ToString().Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetSubject")]
        public async Task<EDMSubjectDTO> GetSubject(int id)
        {
            return (EDMSubjectDTO)DBService.TryGetOne(GetAvailableSubjects(), id, new EDMSubjectDTO());
        }

        [HttpPost, Route("CreateSubject")]
        public async Task<EDMSubjectDTO> CreateSubject(EDMSubjectDTO model)
        {
            return (EDMSubjectDTO)DBService.TryCreateEntity(DB.EDMSubjects, model, (entity) =>
            {
                entity.BusinessId = (int)this.BusinessId;
                entity.Department = new EDM.Models.General.Department
                {
                    Title = "Головное подразделение",
                    IsRoot = true,
                };
            });
        }



        [HttpPut, Route("UpdateSubject")]
        public async Task<EDMSubjectDTO> UpdateSubject(EDMSubjectDTO model)
        {
            var subject = DBService.TryGetOne(GetAvailableSubjects(), model.Id);
            return (EDMSubjectDTO)DBService.TryUpdateEntity(DB.EDMSubjects, model, subject);
        }

        [HttpPut, Route("UploadLogo")]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем logoFile")]
        public async Task<string> UploadLogo(int subjectId)
        {
            var subject = DBService.TryGetOne(GetAvailableSubjects(), subjectId);
            subject.LogoPath = FilesService.TryUploadFile("logoFile", FileType.Image);
            DBService.UpdateEntity(DB.EDMSubjects, subject);

            return subject.LogoPath;
        }




        [HttpDelete, Route("DeleteSubject")]
        public async Task DeleteSubject(int id)
        {
            var subject = DBService.TryGetOne(GetAvailableSubjects(), id);
            var allDepartments = DB.Departments.Include(o => o.Documents)
                                               .Where(o => o.EDMSubjectId == id && !o.IsDeleted);
            if (allDepartments.SelectMany(o => o.Documents).Any(o => !o.IsDeleted))
            {
                throw new Exception403("Невозможно удалить субъект документооборота, т.к. он уже участвовал в документообороте");
            }

            DBService.TryDeleteEntity(DB.EDMSubjects, subject); 
        }

        #endregion








        #region Private methods
        private IEnumerable<EDMSubject> GetAvailableSubjects()
        {
            return DB.EDMSubjects.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
        }


        #endregion
    }
}
