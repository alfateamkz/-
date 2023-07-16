
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MarkupCreator.EnumToTupleConverters
{

    public static class EnumToTupleConverter<T> where T:Enum
    {
        public static List<Tuple<T, string>> GetTuples()
        {
            List<Tuple<T, string>> tuples = new List<Tuple<T, string>>();
            Array Values = Enum.GetValues(typeof(T));
            foreach (var Value in Values)
            {
                var attributes = Value.GetType().GetField(Value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                var attribute = attributes[0] as DescriptionAttribute;
                tuples.Add(new Tuple<T, string>((T)Value, (string)attribute.Description));
            }
            return tuples;
        }

        public static Tuple<T, string> GetElementByEnumValue(T enumValue)
        {
            Array Values = Enum.GetValues(typeof(T));
            foreach (var Value in Values)
            {
                var attributes = Value.GetType().GetField(Value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                var attribute = attributes[0] as DescriptionAttribute;

                var enumValueAttributes = Value.GetType().GetField(Value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                var enumValueAttribute = attributes[0] as DescriptionAttribute;
                if (attribute.Description == enumValueAttribute.Description)
                {
                    return new Tuple<T, string>((T)Value, (string)attribute.Description);
                }
            }

            return null;
        }

    }
}
