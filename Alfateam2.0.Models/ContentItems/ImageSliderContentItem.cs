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

        public override bool AreSame(ContentItem other)
        {
            var areSame = base.AreSame(other);
            if (areSame)
            {
                var slider = other as ImageSliderContentItem;

                areSame &= Title == slider.Title;
                areSame &= Description == slider.Description;

                if(Images.Count != slider.Images.Count)
                {
                    return false;
                }

                for (int i = 0; i < Images.Count; i++)
                {
                    var thisImg = Images[i];
                    var thatImg = slider.Images[i];

                    areSame &= thisImg.AreSame(thatImg);
                }

            }
            return areSame;
        }
    }
}
