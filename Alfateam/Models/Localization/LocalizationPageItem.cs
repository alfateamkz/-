namespace Triggero.Web.Models.Localization
{
    public class LocalizationPageItem
    {
        public LocalizationPageItem(Enum enumType)
        {
            Type = enumType;
        }

        public Enum Type { get; set; }



        public string LanguagesStr { get; set; }

    }
}
