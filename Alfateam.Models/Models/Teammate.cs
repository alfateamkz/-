using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class Teammate
    {
        [Key]
        public int Id { get; set; }
        public List<TranslationItem> Titles { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> MiddleDescriptions { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Positions { get; set; } = new List<TranslationItem>();
        public string? ImgPath { get; set; }
    }
}
