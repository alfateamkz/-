using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Abstractions.Interfaces;
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
    public class Post : AvailabilityModel, IValidatableModel
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }

        public PostCategory Category { get; set; }
        public int CategoryId { get; set; }


        public PostIndustry Industry { get; set; }
        public int IndustryId { get; set; }


        public int Watches { get; set; }
        public List<Watch> WatchesList { get; set; } = new List<Watch>();



      
        public List<PostLocalization> Localizations { get; set; } = new List<PostLocalization>();

        public bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ImgPath);
            isValid &= !string.IsNullOrEmpty(ShortDescription);
            isValid &= Content != null;
            isValid &= CategoryId > 0;
            isValid &= IndustryId > 0;
            isValid &= MainLanguageId > 0;

            foreach (var localization in Localizations)
            {
                isValid &= !string.IsNullOrEmpty(localization.Title);
                isValid &= !string.IsNullOrEmpty(localization.ImgPath);
                isValid &= !string.IsNullOrEmpty(localization.ShortDescription);
                isValid &= localization.Content != null;

                if (!isValid) break;
            }


            return isValid;
        }

    }
}
