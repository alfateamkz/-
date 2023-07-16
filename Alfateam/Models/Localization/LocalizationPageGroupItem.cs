namespace Triggero.Web.Models.Localization
{
    public class LocalizationPageGroupItem
    {
        public LocalizationPageGroupItem(string title, string aspAction)
        {
            Title = title;
            AspAction = aspAction;
        }

        public string Title { get; set; }
        public string AspAction { get; set; }    
        public List<LocalizationPageItem> Pages { get; set; } = new List<LocalizationPageItem>();


        public string Id { get; } = Guid.NewGuid().ToString();

    }
}
