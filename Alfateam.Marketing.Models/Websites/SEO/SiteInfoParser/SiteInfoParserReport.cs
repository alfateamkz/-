using Alfateam.Core;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser
{
    public class SiteInfoParserReport : AbsModel
    {
        public string URL { get; set; }

        public List<SiteInfoParserURLResponse> Responses { get; set; } = new List<SiteInfoParserURLResponse>();
        public string ContentType { get; set; }
        public int ServerResponseTimeInMs { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? H1_Value { get; set; }


        public List<SiteInfoParserFoundLink> FoundLinks { get; set; } = new List<SiteInfoParserFoundLink>();

        public SiteInfoParserDNS DNS { get; set; }
        public SiteInfoParserWhois Whois { get; set; }
        public SiteInfoParserWaybackMachine WaybackMachine { get; set; }


        public SiteInfoParserGoogleSERP GoogleSERP { get; set; }
        public SiteInfoParserBingSERP BingSERP { get; set; }
        public SiteInfoParserYahooSERP YahooSERP { get; set; }



        public SiteInfoParserSchemaMarkupValidator SchemaMarkupValidator { get; set; }
        public SiteInfoParserTraffic Traffic { get; set; }


    }
}
