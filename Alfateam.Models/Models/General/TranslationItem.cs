using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class TranslationItem
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        public Language Language { get; set; }
        public int LanguageId { get; set; }
    }
}
