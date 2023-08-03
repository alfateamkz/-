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
    /// Категория индустрии новостных статей
    /// </summary>
    public class PostIndustry : AbsModel
    {
        public string Title { get; set; }


        public List<PostIndustryLocalization> Localizations { get; set; } = new List<PostIndustryLocalization>();
    }
}
