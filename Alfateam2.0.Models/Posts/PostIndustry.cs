using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Abstractions.Interfaces;
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
    /// Категория индустрии новостных статей
    /// </summary>
    public class PostIndustry : AvailabilityModel, IValidatableModel
    {
        public string Title { get; set; }


        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<PostIndustryLocalization> Localizations { get; set; } = new List<PostIndustryLocalization>();


        public bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(Title);
            foreach (var localization in Localizations)
            {
                isValid &= !string.IsNullOrEmpty(localization.Title);
            }

            return isValid;
        }
    }
}
