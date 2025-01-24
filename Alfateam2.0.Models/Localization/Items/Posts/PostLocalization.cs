using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Posts
{
    public class PostLocalization : LocalizableModel
    {

        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{PostId}";



        /// <summary>
        /// Автоматическое поле. Id новости 
        /// </summary>
        public int PostId { get; set; }
    }
}
