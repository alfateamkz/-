using System.Text;
using Triggero.Models.Attributes;
using Triggero.Models.Enums;

namespace GamblingFactory.Admin.Helpers.Html.Special
{
    public static class LocalizationObjectReflectionHelper
    {
        public static string GenerateHTML(object obj)
        {
            StringBuilder builder = new StringBuilder();


            var type = obj.GetType();
            var props = type.GetProperties();

            foreach(var attr in type.GetCustomAttributes(false))
            {
                if(attr is GeneratorMetadataAttribute metadata)
                {
                    builder.AppendLine($"<h3>{metadata.Title}</h3> \r\n");
                }
            }

            foreach(var prop in props)
            {
                var val = prop.GetValue(obj);

                var header = prop.Name;


                foreach(var attr in prop.GetCustomAttributes(false))
                {
                    if(attr is GeneratorFieldAttribute htmlAttr)
                    {
                        header = htmlAttr.Title;
                        if (htmlAttr.ControlType == GeneratorControlType.Hidden)
                        {
                            var valStr = val?.ToString();
                            if(val is DateTime date)
                            {
                                valStr = date.ToString("yyyy-MM-yyTHH:mm:ss.000Z");
                            }

                            string input = $"<input type=\"hidden\" name=\"{prop.Name}\" value=\"{valStr}\" />";
                            builder.AppendLine(input);
                        }
                        else if (htmlAttr.ControlType == GeneratorControlType.Text)
                        {
                            string input = $"<div class=\"mb-3\">\r\n            " +
                                $"              <label for=\"\" class=\"formlabel\">{header}</label>\r\n             " +
                                $"              <input type=\"text\" name=\"{prop.Name}\" required value=\'{val}\'  class=\"form-control\" placeholder=\"\">\r\n   " +
                                $"         </div>\r\n";
                            builder.AppendLine(input);
                        }
                        else if (htmlAttr.ControlType == GeneratorControlType.Textarea)
                        {
                            string input = $"<div class=\"mb-3\">\r\n            " +
                                $"              <label for=\"\" class=\"formlabel\">{header}</label>\r\n             " +
                                $"              <textarea type=\"text\" name=\"{prop.Name}\" required class=\"form-control\" rows=\"3\" placeholder=\"\">{val}</textarea>\r\n   " +
                                $"         </div>\r\n";
                            builder.AppendLine(input);
                        }


                        break;
                    }
                }

               

            }

            return builder.ToString();
        }
    }
}
