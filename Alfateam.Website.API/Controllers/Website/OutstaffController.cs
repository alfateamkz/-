using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Outstaff;
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
        public async Task<OutstaffMatrixDTO> GetOutstaffMatrix()
        {
            return OutstaffMatrixDTO.Create(DB.GetOutstaffMatrix(), LanguageId,CountryId);
        }

    }
}
