

using Newtonsoft.Json;

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
        public SitemapItem(string relativeURL, string title)
        {
            Title = title;
            RelativeURL = relativeURL;
        }

        public string Title { get; set; }
        public string RelativeURL { get; set; }

        public string URL => GetFullURLRecursively(this);

        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public double Priority { get; set; } = 0.8;


        public List<SitemapItem> Sublelements { get; set; } = new List<SitemapItem>();


        public void AddElement(SitemapItem item)
        {
            Sublelements.Add(item);
            item.Parent = this;
        }


        [JsonIgnore]
        public SitemapItem? Parent { get; set; }


        private string GetFullURLRecursively(SitemapItem item)
        {
            string url = item.RelativeURL;

            if(item.Parent != null)
            {
                url = GetFullURLRecursively(item.Parent) + "/" + url;
            }

            return url;
        }
    }
}
