using Alfateam.Marketing.Models.Abstractions.SEO;
using Alfateam.Marketing.Models.Enums.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems.Rules
{
    public class StringURLRule : URLRule
    {
        public string Value { get; set; }
        public URLComparisonType Type { get; set; }
    }
}
