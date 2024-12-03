using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.General.SEO
{
    public class LanguageDictionary : AbsModel
    {
        public string Title { get; set; }
        public string LanguageCode { get; set; }
        public string DictionaryPath { get; set; }
    }
}
