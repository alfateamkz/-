using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.ServicePages;
using Alfateam2._0.Models.ServicePages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class ServicePagesController : AbsController
    {
        public ServicePagesController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetServicePages")]
        public async Task<IEnumerable<ServicePageDTO>> GetServicePages(int offset, int count = 20)
        {
            var items = GetServicePagesList().Skip(offset).Take(count).ToList();
            return new ServicePageDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<ServicePageDTO>();
        }

        [HttpGet, Route("GetServicePage")]
        public async Task<ServicePageDTO> GetServicePage(int id)
        {
            var page = GetServicePagesList().FirstOrDefault(o => o.Id == id);
            return (ServicePageDTO)new ServicePageDTO().CreateDTOWithLocalization(page, LanguageId);
        }







        #region Private get included methods
        private IEnumerable<ServicePage> GetServicePagesList()
        {
            return DB.ServicePages.IncludeAvailability()
                                  .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                  .Include(o => o.Localizations).ThenInclude(o => o.ServiceRibbonItems)
                                  .Include(o => o.Localizations).ThenInclude(o => o.Reviews)
                                  .Include(o => o.MainLanguage)
                                  .Include(o => o.ServiceRibbonItems)
                                  .Include(o => o.StackIcons)
                                  .Include(o => o.Reviews)
                                  .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                  .ToList();
        }

        #endregion
    }
}
