using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? ImgPath { get; set; }


        public List<TranslationItem> Captions { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Contents { get; set; } = new List<TranslationItem>();

        public int Watches { get; set; }
    }
}
