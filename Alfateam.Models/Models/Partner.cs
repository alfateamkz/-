using Alfateam.Database.Abstraction;
using Alfateam.Database.Models.Localizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class Partner : BaseModel {

        public string? ImgPath { get; set; }



        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<PartnerLocalization> Localizations { get; set; } = new List<PartnerLocalization>();




        public string GetLocalizedTitle(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Title;
            if (string.IsNullOrEmpty(str))
            {
                str = Title;
            }
            return str;
        }
        public string GetLocalizedDescription(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Description;
            if (string.IsNullOrEmpty(str))
            {
                str = Description;
            }
            return str;
        }
    }
}
