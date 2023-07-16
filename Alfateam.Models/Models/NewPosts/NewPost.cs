using Alfateam.Database.Abstraction;
using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.NewPosts
{
    public class NewPost : BaseModel {




        public Language Language { get; set; }
        public int LanguageId { get; set; }



        public bool IsDeleted { get; set; }
        public int Watches { get; set; }


        public List<PostHeading> Headings { get; set; } = new List<PostHeading>();
        public List<PostImage> Images { get; set; } = new List<PostImage>();
        public List<PostParagraph> Paragraphs { get; set; } = new List<PostParagraph>();
        public List<PostSlider> Sliders { get; set; } = new List<PostSlider>();
        public List<PostVideo> Videos { get; set; } = new List<PostVideo>();

        [NotMapped]
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


    }
}
