using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.SitePagesTexts
{
    public class ErrorPages : BaseModel {


        public List<TranslationItem> Texts403 { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Texts404 { get; set; } = new List<TranslationItem>();




        public List<TranslationItem> TextsNuhuyaTitle { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> TextsNuhuyaDescription { get; set; } = new List<TranslationItem>();
    }
}
