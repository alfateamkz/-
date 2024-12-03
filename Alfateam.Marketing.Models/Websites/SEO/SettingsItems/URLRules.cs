using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions.SEO;
using Alfateam.Marketing.Models.Enums.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems
{
    public class URLRules : AbsModel
    {
        public bool UseRules { get; set; }
        public bool GoToFilteredURLs { get; set; }

        public URLRulesType Type { get; set; }


        public List<URLRule> Rules { get; set; } = new List<URLRule>();

    }
}
