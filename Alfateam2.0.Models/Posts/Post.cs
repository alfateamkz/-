using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Posts
{
    /// <summary>
    /// Сущность новостной записи
    /// </summary>
    public class Post : AbsModel
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }

        public PostCategory Category { get; set; }
        public PostIndustry Industry { get; set; }


        public int Watches { get; set; }
        public List<Watch> WatchesList { get; set; } = new List<Watch>();



        public List<PostLocalization> Localizations { get; set; } = new List<PostLocalization>();
    }
}
