using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Alfateam2._0.Models.Portfolios;
using Alfateam.Website.API.Models;

namespace Alfateam.Website.API.Controllers.Website
{
    public class OutstaffController : AbsController
    {
        public OutstaffController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetOutstaffMatrix")]
        public async Task<OutstaffMatrixDTO> GetOutstaffMatrix()
        {
            return new OutstaffMatrixDTO().CreateDTOWithLocalization(DB.GetOutstaffMatrix(), (int)LanguageId, (int)CountryId, (int)CurrencyId);
        }

    }
}
