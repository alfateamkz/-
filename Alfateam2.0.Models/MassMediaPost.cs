using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models
{
    /// <summary>
    /// Сущность поста в разделе "Мы в СМИ"
    /// </summary>
    public class MassMediaPost : AvailabilityModel
    {
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public string URL { get; set; }


        public int ClicksCount { get; set; }



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<MassMediaPostLocalization> Localizations { get; set; } = new List<MassMediaPostLocalization>();

        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(ImgPath);
            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ShortDescription);
            isValid &= !string.IsNullOrEmpty(URL);

            isValid &= ClicksCount >= 0;
            isValid &= MainLanguageId > 0;

            return isValid;
        }
    }
}
