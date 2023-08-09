using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ContentItems
{
    public class AudioContentItem : ContentItem
    {
        public string AudioPath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public override bool AreSame(ContentItem other)
        {
            var areSame = base.AreSame(other);
            if (areSame)
            {
                var audio = other as AudioContentItem;

                areSame &= AudioPath == audio.AudioPath;
                areSame &= Title == audio.Title;
                areSame &= Description == audio.Description;
            }
            return areSame;
        }
    }
}
