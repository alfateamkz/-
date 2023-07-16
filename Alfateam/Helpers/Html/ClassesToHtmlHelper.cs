using System.Collections.Generic;

namespace CRMWeb.Helpers.Html
{
    public class ClassesToHtmlHelper<T> where T : class
    {
        public static string Convert(IEnumerable<T> list,T item)
        {
            string html = "";

            foreach (var value in list)
            {
                int id = (int)value.GetType().GetProperty("Id").GetValue(value);
                int itemId = (int)value.GetType().GetProperty("Id").GetValue(item);

                if (id == itemId)
                {
                    html += $"<option selected value=\"{id}\">{value}</option>\r\n";
                }
                else
                {
                    html += $"<option value=\"{id}\">{value}</option>\r\n";
                }
            }
            return html;
        }

        public static string Convert(IEnumerable<T> list, int itemId)
        {
            string html = "";

            foreach (var value in list)
            {
                int id = (int)value.GetType().GetProperty("Id").GetValue(value);

                if (id == itemId)
                {
                    html += $"<option selected value=\"{id}\">{value}</option>\r\n";
                }
                else
                {
                    html += $"<option value=\"{id}\">{value}</option>\r\n";
                }
            }
            return html;
        }

        public static string Convert(IEnumerable<T> list)
        {
            string html = "";

            foreach (var value in list)
            {
                int id = (int)value.GetType().GetProperty("Id").GetValue(value);
                html += $"<option value=\"{id}\">{value}</option>\r\n";
            }
            return html;
        }
    }
}
