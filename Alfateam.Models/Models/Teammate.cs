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
    public class Teammate : BaseModel {

        public string? ImgPath { get; set; }





        public string? Title { get; set; }
        public string? MiddleDescription { get; set; }
        public string? Position { get; set; }

        public string GetLocalizedTitle(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Title;
            if (string.IsNullOrEmpty(str))
            {
                str = Title;
            }
            return str;
        }
        public string GetLocalizedMiddleDescription(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.MiddleDescription;
            if (string.IsNullOrEmpty(str))
            {
                str = MiddleDescription;
            }
            return str;
        }
        public string GetLocalizedPosition(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Position;
            if (string.IsNullOrEmpty(str))
            {
                str = Position;
            }
            return str;
        }

        public List<TeammateLocalization> Localizations { get; set; } = new List<TeammateLocalization>();

    }
}
