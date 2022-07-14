using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        public List<TranslationItem> Titles { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Descriptions { get; set; } = new List<TranslationItem>();
        public string? ImgPath { get; set; }


        public string GetLocalizedTitle(string langCode)
        {
            var found = Titles.FirstOrDefault(o => o.Language.Code == langCode);

            if(found == null)
                found = Titles.FirstOrDefault(o => o.Language.Code == "RU");
            return found.Text;
        }
        public string GetLocalizedDescription(string langCode)
        {
            var found = Descriptions.FirstOrDefault(o => o.Language.Code == langCode);

            if (found == null)
                found = Descriptions.FirstOrDefault(o => o.Language.Code == "RU");
            return found.Text;
        }
    }
}
