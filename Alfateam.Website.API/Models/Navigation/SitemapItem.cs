namespace Alfateam.Website.API.Models.Navigation
{
    /// <summary>
    /// Сущность элемента карты сайта
    /// </summary>
    public class SitemapItem
    {

        public SitemapItem()
        {

        }
        public SitemapItem(string title,string url)
        {
            Title = title;
            URL = url;
        }

        public string Title { get; set; }
        public string URL { get; set; }

        public DateTime LastModified { get; set; }
        public double Priority { get; set; }


        public List<SitemapItem> Sublelements { get; set; } = new List<SitemapItem>();  
    }
}
