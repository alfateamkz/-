namespace Alfateam.Extensions
{
    public static class StringExtensions
    {
        public static string MakeShortText(this string value)
        {
            if(value.Length > 100)
            {
                return value.Substring(0, 100) + "...";
            }
            else
            {
                return value.Substring(0, value.Length) + "...";
            }
        }
    }
}
