using Alfateam.Database.Abstraction;
using Alfateam.Database.Models.Localizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Promotions
{
    public class PromotionDescriptionItem : BaseModel {

        public List<PromotionDescriptionItemLocalization> Localizations { get; set; } = new List<PromotionDescriptionItemLocalization>();
        public string Text { get; set; }


        public string GetLocalizedText(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Text;
            if (string.IsNullOrEmpty(str))
            {
                str = Text;
            }
            return str;
        }
    }
}
