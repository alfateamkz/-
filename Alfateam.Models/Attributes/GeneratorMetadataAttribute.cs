using System;
using System.Collections.Generic;
using System.Text;

namespace Triggero.Models.Attributes
{
    public class GeneratorMetadataAttribute : Attribute
    {
        public GeneratorMetadataAttribute(string title)
        {
            Title = title;
        }
        public string Title { get; set; }
    }
}
