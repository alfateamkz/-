using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums;
using Alfateam.Database.Models.Localizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Promotions
{
    public class Promotion : BaseModel {


        public string? RightImgPath { get; set; }
        public PromotionPuzzleType PromotionPuzzleType { get; set; } = PromotionPuzzleType.Puzzle1;





        public string? Caption { get; set; }
        public string? Price { get; set; }
        public List<PromotionLocalization> Localizations { get; set; } = new List<PromotionLocalization>();
        public List<PromotionDescriptionItem> Descriptions { get; set; } = new List<PromotionDescriptionItem>();




        public string GetLocalizedCaption(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Caption;
            if (string.IsNullOrEmpty(str))
            {
                str = Caption;
            }
            return str;
        }
        public string GetLocalizedPrice(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Price;
            if (string.IsNullOrEmpty(str))
            {
                str = Price;
            }
            return str;
        }



    }
}
