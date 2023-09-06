using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.JobVacancies;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.JobVacancies;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.JobVacancies;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.HR)]
    public class HRJobVacanciesController : AbsController
    {
        public HRJobVacanciesController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: добавить методы получения по цепочке вверх

        #region Вакансии

        [HttpGet, Route("GetJobVacancies")]
        public async Task<RequestResult> GetJobVacancies(int offset, int count = 20)
        {
            var includes = DB.JobVacancies.Include(o => o.Expierence)
                                          .Where(o => o.HRDepartmentId == this.DepartmentId);
            return GetMany<JobVacancy, JobVacancyClientModel>(includes, offset, count);
        }

        [HttpGet, Route("GetJobVacancy")]
        public async Task<RequestResult> GetJobVacancy(int id)
        {
            var includes = DB.JobVacancies.Include(o => o.Expierence)
                                          .Where(o => o.HRDepartmentId == this.DepartmentId);
            return TryGetModel(includes, id);
        }



        [HttpPost, Route("CreateJobVacancy")]
        public async Task<RequestResult> CreateJobVacancy(JobVacancyCreateModel model)
        {
            return TryCreateModel(DB.JobVacancies, model, (item) =>
            {
                item.HRDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }

        [HttpPut, Route("UpdateJobVacancy")]
        public async Task<RequestResult> UpdateJobVacancy(JobVacancyEditModel model)
        {
            return TryUpdateModel(DB.JobVacancies, model);
        }

        [HttpDelete, Route("DeleteJobVacancy")]
        public async Task<RequestResult> DeleteJobVacancy(int id)
        {
            return TryDeleteModel(DB.JobVacancies, id);
        }

        #endregion 
    }
}
