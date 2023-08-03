using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ContentItems
{
    public class ImageContentItem : ContentItem
    {
        public string ImgPath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
