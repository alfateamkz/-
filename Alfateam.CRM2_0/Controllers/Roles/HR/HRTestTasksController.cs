using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.TestTasks;
using Alfateam.CRM2_0.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{
    [AccessActionFilter(roles: UserRole.HR)]
    public class HRTestTasksController : AbsController
    {
        public HRTestTasksController(ControllerParams @params) : base(@params)
        {
        }


        [HttpPost, Route("CreateTestTask")]
        public async Task<RequestResult> CreateTestTask(int candidateId, CandidateTestTaskEditModel model)
        {
            return TryCreateModel(DB.HRManuals, model);
        }

    }
}
