using MarkupCreator.Helpers.Converters;
using System;

namespace CRMWeb.Helpers
{
    public class EnumToHtmlHelper<T> where T: Enum
    {
        public static string Convert(T enumValue)
        {
            string html = "";

            var enumValues = EnumToListConverter<T>.GetEnumValuesList();
            var values = EnumToListConverter.GetEnumStringValuesList(enumValue.GetType());

            int counter = 0;
            foreach(var value in values)
            {
                var a = enumValues[counter];
                if (enumValue.ToString() == value)
                {
                    html += $"<option selected value=\"{System.Convert.ToInt32(a)}\">{value}</option>\r\n";
                }
                else
                {
                    html += $"<option value=\"{System.Convert.ToInt32(a)}\">{value}</option>\r\n";
                }
                counter++;
            }
            return html;
        }

        public static string Convert()
        {
            string html = "";

            var enumValues = EnumToListConverter<T>.GetEnumValuesList();
            var values = EnumToListConverter.GetEnumStringValuesList(typeof(T));

            int counter = 0;
            foreach (var value in values)
            {
                var a = enumValues[counter];
                if (counter == 0)
                {
                    html += $"<option selected value=\"{System.Convert.ToInt32(a)}\">{value}</option>\r\n";
                }
                else
                {
                    html += $"<option value=\"{System.Convert.ToInt32(a)}\">{value}</option>\r\n";
                }
                counter++;
            }
            return html;
        }
    }
}
