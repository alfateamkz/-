using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Promotions
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? RightImgPath { get; set; }


        public List<TranslationItem> Captions { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Prices { get; set; } = new List<TranslationItem>();

        public List<PromotionDescriptionItem> Descriptions { get; set; } = new List<PromotionDescriptionItem>();
    }
}
