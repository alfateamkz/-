using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace MarkupCreator.Helpers.Converters
{
    public static class EnumToListConverter<T> where T : Enum
    {
        public static List<T> GetEnumValuesList()
        {
            List<T> tuples = new List<T>();
            Array Values = Enum.GetValues(typeof(T));
            foreach (var Value in Values)
            {
                tuples.Add((T)Value);
            }
            return tuples;
        }
        public static ObservableCollection<T> GetEnumValuesObservableCollection()
        {
            return new ObservableCollection<T>(GetEnumValuesList());
        }

        public static T GetEnumByStringDescription(string description)
        {
            Array Values = Enum.GetValues(typeof(T));
            foreach (var Value in Values)
            {
                var attributes = Value.GetType().GetField(Value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                var attribute = attributes[0] as DescriptionAttribute;

                if (attribute.Description == description)
                {
                    return (T)Value;
                }
            }
            return (T)Values.GetValue(0);
        }
  
    }
    public static class EnumToListConverter
    {
        public static object GetEnumByStringDescription(Type enumType, string description)
        {
            Array Values = Enum.GetValues(enumType);
            foreach (var Value in Values)
            {
                var attributes = Value.GetType().GetField(Value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                var attribute = attributes[0] as DescriptionAttribute;

                if (attribute.Description == description)
                {
                    return Value;
                }
            }
            return Values.GetValue(0);
        }

        public static List<string> GetEnumStringValuesList(Type enumType)
        {
            List<string> tuples = new List<string>();
            Array Values = Enum.GetValues(enumType);
            foreach (var Value in Values)
            {
                var attributes = Value.GetType().GetField(Value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                var attribute = attributes[0] as DescriptionAttribute;
                tuples.Add(attribute.Description);
            }
            return tuples;
        }
    }
}
