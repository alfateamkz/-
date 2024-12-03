using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserWhois : AbsModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string RootDomain { get; set; }
    }
}
