using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserWaybackMachine : AbsModel
    {
        public int IndexedURLsCount { get; set; }

        public bool Indexation { get; set; }
        public DateTime? FirstCrawled { get; set; }
        public DateTime? LastCrawled { get; set; }
        public bool? LastCapturedURL { get; set; }
    }
}
