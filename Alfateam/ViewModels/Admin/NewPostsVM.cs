using Alfateam.Database.Models;
using Alfateam.Database.Models.Abstractions;
using Alfateam.Database.Models.NewPosts;

namespace Alfateam.ViewModels.Admin
{
    public class NewPostsVM
    {
        public int Id { get; set; }


        public List<Language> Languages { get; set; } = new List<Language>();
        public int LanguageId { get; set; }




        public List<PostHeading> Headings { get; set; } = new List<PostHeading>();
        public List<PostImage> Images { get; set; } = new List<PostImage>();
        public List<PostParagraph> Paragraphs { get; set; } = new List<PostParagraph>();
        public List<PostSlider> Sliders { get; set; } = new List<PostSlider>();
        public List<PostVideo> Videos { get; set; } = new List<PostVideo>();


        public List<PostItem> OrderedItems
        {
            get
            {
                var list = new List<PostItem>();
                list.AddRange(Headings);
                list.AddRange(Images);
                list.AddRange(Paragraphs);
                list.AddRange(Sliders);
                list.AddRange(Videos);

                list = list.OrderBy(o => o.Order).ToList();
                return list;
            }
        }

        public List<PostItem> OrderedItemsWithMedia
        {
            get
            {
                var list = new List<PostItem>();
                list.AddRange(Images);
                list.AddRange(Sliders);
                list.AddRange(Videos);

                list = list.OrderBy(o => o.Order).ToList();
                return list;
            }
        }
    }
}
