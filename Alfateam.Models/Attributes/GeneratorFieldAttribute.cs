using System;
using System.Collections.Generic;
using System.Text;
using Triggero.Models.Enums;

namespace Triggero.Models.Attributes
{
    /// <summary>
    /// Атрибуты для генератора форм 
    /// </summary>
    public class GeneratorFieldAttribute : Attribute
    {
        public GeneratorFieldAttribute(string title)
        {
            Title = title;
        }
        public GeneratorFieldAttribute(string title, GeneratorControlType type)
        {
            Title = title;
            ControlType = type;
        }

        public string Title { get; set; }
        public GeneratorControlType ControlType { get; set; } = GeneratorControlType.Text;
    }
}
