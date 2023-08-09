namespace Alfateam.Website.API.Models.Navigation
{
    /// <summary>
    /// Сущность карты сайта
    /// </summary>
    public class Sitemap
    {
        public List<SitemapItem> Items { get; set; } = new List<SitemapItem>();
    }
}
