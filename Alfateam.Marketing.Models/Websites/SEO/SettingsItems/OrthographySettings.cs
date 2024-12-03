using Alfateam.Core;
using Alfateam.Marketing.Models.General.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems
{
    public class OrthographySettings : AbsModel
    {
        public bool CheckOrthography { get; set; }
        public List<LanguageDictionary> Dictionaries { get; set; } = new List<LanguageDictionary>();
        public string WordsToIgnore { get; set; }
    }
}
