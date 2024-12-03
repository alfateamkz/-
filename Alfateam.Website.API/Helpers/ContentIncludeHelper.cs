using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.DB;
using Alfateam2._0.Models.ContentItems;

namespace Alfateam.Website.API.Helpers
{
    public static class ContentIncludeHelper
    {
        public static void IncludeHierarchy(WebsiteDBContext db, IEnumerable<Content> contents)
        {
            foreach (var content in contents)
            {
                content.Items = content.Items.Where(o => !o.IsDeleted).ToList();
                foreach (var slider in content.Items.Where(o => o is ImageSliderContentItem).Cast<ImageSliderContentItem>())
                {
                    slider.Images = db.ContentItems.Where(o => o.ImageSliderContentItemId == slider.Id && !o.IsDeleted)
                                                   .AsEnumerable()
                                                   .Where(o => o is ImageContentItem)
                                                   .Cast<ImageContentItem>()
                                                   .ToList();
                }
            }
        }
    }
}
