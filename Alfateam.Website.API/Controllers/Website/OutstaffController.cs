using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.Outstaff;
using Alfateam2._0.Models.Outstaff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Controllers.Website
{
    public class OutstaffController : AbsController
    {
        public OutstaffController(WebsiteDBContext db) : base(db)
        {
        }

        [HttpGet, Route("GetOutstaffMatrix")]
        public async Task<OutstaffMatrixClientModel> GetOutstaffMatrix()
        {
            return OutstaffMatrixClientModel.Create(DB.GetOutstaffMatrix(), LanguageId,CountryId);
        }

    }
}
