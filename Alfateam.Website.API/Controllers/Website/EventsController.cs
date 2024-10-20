using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.Filters;
using Alfateam2._0.Models.Events;
using Alfateam2._0.Models.Localization.Items.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace Alfateam.Website.API.Controllers.Website
{
    public class EventsController : AbsController
    {
        public EventsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetEvents")]
        public async Task<IEnumerable<EventDTO>> GetEvents(int offset, int count = 20)
        {
            var items = GetEventsWithIncludes().Skip(offset).Take(count).ToList();
            return new EventDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<EventDTO>();
        }
  
        [HttpGet, Route("GetEventsByFilter")]
        public async Task<IEnumerable<EventDTO>> GetEventsByFilter(ClientEventsSearchFilter filter)
        {
            var events = GetEventsWithIncludes();

            if(filter.CategoryId > 0)
            {
                events = events.Where(o => o.Category.Id == filter.CategoryId);
            }
            if (filter.FormatId > 0)
            {
                events = events.Where(o => o.Format.Id == filter.FormatId);
            }
            if (!string.IsNullOrEmpty(filter.Query))
            {
                events = events.Where(o => o.Title.Contains(filter.Query,StringComparison.OrdinalIgnoreCase));
            }

            events = events.Skip(filter.Offset).Take(filter.Count);
            return new EventDTO().CreateDTOsWithLocalization(events, LanguageId).Cast<EventDTO>();
        }

        [HttpGet, Route("GetEvent")]
        public async Task<EventDTO> GetEvent(int id)
        {
            var item = GetEventsWithIncludes().FirstOrDefault(o => o.Id == id);
            return (EventDTO) new EventDTO().CreateDTOWithLocalization(item, LanguageId);
        }




        [HttpGet, Route("GetEventCategories")]
        public async Task<IEnumerable<EventCategoryDTO>> GetEventCategories()
        {
            var items = GetEventCategoriesWithIncludes();
            return new EventCategoryDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<EventCategoryDTO>();
        }
        [HttpGet, Route("GetEventFormats")]
        public async Task<IEnumerable<EventFormatDTO>> GetEventFormats()
        {
            var items = GetEventFormatsWithIncludes();
            return new EventFormatDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<EventFormatDTO>();
        }



        #region Private methods
        private IEnumerable<Event> GetEventsWithIncludes()
        {
            return DB.Events.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Format).ThenInclude(o => o.Localizations)
                            .Include(o => o.TimeZone)
                            .Include(o => o.Localizations)
                            .ToList()
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        private IEnumerable<EventCategory> GetEventCategoriesWithIncludes()
        {
            return DB.EventCategories.IncludeAvailability()
                                     .Include(o => o.Localizations)
                                     .ToList()
                                     .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        private IEnumerable<EventFormat> GetEventFormatsWithIncludes()
        {
            return DB.EventFormats.IncludeAvailability()
                                  .Include(o => o.Localizations)
                                  .ToList()
                                  .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}
