using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ContentItems
{
    public class ImageSliderContentItem : ContentItem
    {
        public List<ImageContentItem> Images { get; set; } = new List<ImageContentItem>();

        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
