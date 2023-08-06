using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Events;
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
        public EventsController(WebsiteDBContext db) : base(db)
        {
        }

        [HttpGet, Route("GetEvents")]
        public async Task<IEnumerable<EventClientModel>> GetEvents(int offset, int count = 20)
        {
            var items = GetEvents().Skip(offset).Take(count).ToList();
            return EventClientModel.CreateItems(items, LanguageId);
        }
        [HttpGet, Route("GetEventsByFilter")]
        public async Task<IEnumerable<EventClientModel>> GetEventsByFilter(EventsSearchFilter filter)
        {
            var events = GetEvents();

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
            return EventClientModel.CreateItems(events.ToList(), LanguageId);
        }

        [HttpGet, Route("GetEvent")]
        public async Task<EventClientModel> GetEvent(int id)
        {
            var item = GetEvents().FirstOrDefault(o => o.Id == id);
            return EventClientModel.Create(item, LanguageId);
        }




        [HttpGet, Route("GetEventCategories")]
        public async Task<IEnumerable<EventCategoryClientModel>> GetEventCategories()
        {
            var items = DB.EventCategories.Include(o => o.Localizations)
                                          .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                          .ToList();
            return EventCategoryClientModel.CreateItems(items,LanguageId);
        }
        [HttpGet, Route("GetEventFormats")]
        public async Task<IEnumerable<EventFormatClientModel>> GetEventFormats()
        {
            var items = DB.EventFormats.Include(o => o.Localizations)
                                       .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                       .ToList();
            return EventFormatClientModel.CreateItems(items, LanguageId);
        }



        #region Private methods
        public IQueryable<Event> GetEvents()
        {
            return DB.Events.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Format).ThenInclude(o => o.Localizations)
                            .Include(o => o.TimeZone)
                            .Include(o => o.Localizations)
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}
