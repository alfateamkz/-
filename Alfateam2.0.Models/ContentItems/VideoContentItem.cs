using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ContentItems
{
    public class VideoContentItem : ContentItem
    {
        public string VideoPath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }


        public override bool AreSame(ContentItem other)
        {
            var areSame = base.AreSame(other);
            if (areSame)
            {
                var video = other as VideoContentItem;

                areSame &= VideoPath == video.VideoPath;
                areSame &= Title == video.Title;
                areSame &= Description == video.Description;
            }
            return areSame;
        }
    }

}
