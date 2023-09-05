using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Roles.Accountance
{
    [AccessActionFilter(roles: UserRole.Accountant)]
    public class AccountanceController : AbsController
    {
        public AccountanceController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet,Route("GetAccounts")]
        public async Task<RequestResult> GetAccounts()
        {

        }
    }
}
