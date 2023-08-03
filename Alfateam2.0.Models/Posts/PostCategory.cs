using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Items.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Posts
{
    /// <summary>
    /// Категория новостных статей
    /// </summary>
    public class PostCategory : AbsModel
    {
        public string Title { get; set; }


        public List<PostCategoryLocalization> Localizations { get; set; } = new List<PostCategoryLocalization>();
    }
}
