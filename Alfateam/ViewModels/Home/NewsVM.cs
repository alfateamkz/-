using Alfateam.Database.Models;
using Alfateam.Database.Models.NewPosts;

namespace Alfateam.ViewModels.Home
{
    public class NewsVM
    {
        public List<NewPost> Posts { get; set; } = new List<NewPost>();

        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
