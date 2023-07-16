namespace CRMWeb.Helpers.Html
{
    public class BooleanToSelectHtmlHelper
    {
        public static string Convert(bool val)
        {
            string html = "";
            if (val)
            {
                html += $"<option selected value=\"true\">Да</option>\r\n";
                html += $"<option value=\"false\">Нет</option>\r\n";
            }
            else
            {
                html += $"<option value=\"true\">Да</option>\r\n";
                html += $"<option selected value=\"false\">Нет</option>\r\n";
            }
            return html;
        }
    }
}
