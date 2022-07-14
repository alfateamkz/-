using Alfateam.Database.Models;

namespace Alfateam.ViewModels.Home
{
    public class NewsVM
    {
        public List<Post> Posts { get; set; } = new List<Post>();

        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
