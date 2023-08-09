using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ContentItems
{
    public class TextContentItem : ContentItem
    {
        public string Content { get; set; }

        public override bool AreSame(ContentItem other)
        {
            var areSame = base.AreSame(other);
            if (areSame)
            {
                var text = other as TextContentItem;

                areSame &= Content == text.Content;
            }
            return areSame;
        }
    }
}
