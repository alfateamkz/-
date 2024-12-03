using Alfateam.Core;
using Alfateam.Marketing.Models.Enums.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser
{
    public class SiteInfoParserFoundLink : AbsModel
    {
        public string URL { get; set; }
        public SiteInfoParserFoundLinkType Type { get; set; }
    }
}
