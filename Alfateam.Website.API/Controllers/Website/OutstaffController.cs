using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.Outstaff;
using Alfateam2._0.Models.Outstaff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            var matrix = DB.OutstaffMatrices.Include(o => o.Columns)
                                            .Include(o => o.Items).ThenInclude(o => o.Grades).ThenInclude(o => o.Prices).ThenInclude(o => o.CostPerHour).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                            .Include(o => o.Items).ThenInclude(o => o.Grades).ThenInclude(o => o.Prices).ThenInclude(o => o.CostPerHour).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                            .FirstOrDefault();

            return OutstaffMatrixClientModel.Create(matrix,LanguageId,CountryId);
        }

    }
}
