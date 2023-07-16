using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarkupCreator.Helpers.Converters
{
    public static class EnumDescriptionHelper
    {
        public static string GetDescription(Enum value)
        {
            Array Values = Enum.GetValues(value.GetType());
            foreach (var Value in Values)
            {
                var attributes = Value.GetType().GetField(Value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                var attribute = attributes[0] as DescriptionAttribute;

                if (Value?.ToString() == value.ToString())
                {
                    return attribute.Description;
                }

            }
            return null;
        }
    }
}
