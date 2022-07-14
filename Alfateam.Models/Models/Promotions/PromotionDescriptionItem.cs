using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Promotions
{
    public class PromotionDescriptionItem
    {
        [Key]
        public int Id { get; set; }
        public List<TranslationItem> Texts { get; set; } = new List<TranslationItem>();
    }
}
