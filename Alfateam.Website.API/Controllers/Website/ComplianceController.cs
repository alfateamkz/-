using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class ComplianceController : AbsController
    {
        public ComplianceController(WebsiteDBContext db) : base(db)
        {
        }


        [HttpGet, Route("GetComplianceDocuments")]
        public async Task<IEnumerable<ComplianceDocumentClientModel>> GetComplianceDocuments()
        {
            var items = DB.ComplianceDocuments.IncludeAvailability()
                                              .Include(o => o.Localizations)
                                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                              .ToList();
            return ComplianceDocumentClientModel.CreateItems(items, LanguageId);
        }
    }
}
