namespace Alfateam.Models.Helpers
{
    public class SlugHelper
    {

        static Dictionary<string, string> dictionaryChar = new Dictionary<string, string>()
        {
            {"а","a"},
            {"б","b"},
            {"в","v"},
            {"г","g"},
            {"д","d"},
            {"е","e"},
            {"ё","yo"},
            {"ж","zh"},
            {"з","z"},
            {"и","i"},
            {"й","y"},
            {"к","k"},
            {"л","l"},
            {"м","m"},
            {"н","n"},
            {"о","o"},
            {"п","p"},
            {"р","r"},
            {"с","s"},
            {"т","t"},
            {"у","u"},
            {"ф","f"},
            {"х","h"},
            {"ц","ts"},
            {"ч","ch"},
            {"ш","sh"},
            {"щ","sch"},
            {"ъ","'"},
            {"ы","yi"},
            {"ь",""},
            {"э","e"},
            {"ю","yu"},
            {"я","ya"},

            
            {"ә","a"},
            {"ғ","g"},
            {"қ","q"},
            {"ң","n"},
            {"ө","o"},
            {"ұ","u"},
            {"ү","u"},
            {"һ","h"},
            {"Һ","H"},
        }; 

        public static string TranslitToLatyn(string str)
        {
            var result = "";

            foreach (var ch in str.ToLower())
            {
                var ss = "";
                if (dictionaryChar.TryGetValue(ch.ToString(), out ss))
                {
                    result += ss;
                }
                else result += ch;
            }
            return result;
        }

        public static string GetLatynSlug(string str)
        {
            return TranslitToLatyn(str).Replace(" ","-")
                                       .Replace("/", "")
                                       .Replace("&", "")
                                       .Replace("=", "")
                                       .Replace("?", "");
        }
    }
}
