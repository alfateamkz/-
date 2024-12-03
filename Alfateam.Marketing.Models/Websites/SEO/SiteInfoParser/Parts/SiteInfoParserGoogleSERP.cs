using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserGoogleSERP : AbsModel
    {
        public int IndexedURLsCount { get; set; }
        public bool Indexation { get; set; }
    }
}
