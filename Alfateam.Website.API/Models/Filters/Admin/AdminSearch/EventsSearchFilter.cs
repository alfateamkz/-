﻿using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Filters.AdminSearch
{
    public class EventsSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }
        public int? FormatId { get; set; }

        public IEnumerable<Event> Filter(IEnumerable<Event> items)
        {
            IEnumerable<Event> filtered = new List<Event>(items);
            if(CategoryId != null)
            {
                filtered = filtered.Where(o => o.CategoryId == CategoryId);
            }
            if (FormatId != null)
            {
                filtered = filtered.Where(o => o.FormatId == FormatId);
            }

            return filtered;
            //return this.FilterBase(filtered, queryPredicate);
        }
    }
}
