using Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser
{
    public class SiteInfoParserReportDTO : DTOModelAbs<SiteInfoParserReport>
    {
        public string URL { get; set; }

        public List<SiteInfoParserURLResponseDTO> Responses { get; set; } = new List<SiteInfoParserURLResponseDTO>();
        public string ContentType { get; set; }
        public int ServerResponseTimeInMs { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? H1_Value { get; set; }


        public List<SiteInfoParserFoundLinkDTO> FoundLinks { get; set; } = new List<SiteInfoParserFoundLinkDTO>();

        public SiteInfoParserDNSDTO DNS { get; set; }
        public SiteInfoParserWhoisDTO Whois { get; set; }
        public SiteInfoParserWaybackMachineDTO WaybackMachine { get; set; }


        public SiteInfoParserGoogleSERPDTO GoogleSERP { get; set; }
        public SiteInfoParserBingSERPDTO BingSERP { get; set; }
        public SiteInfoParserYahooSERPDTO YahooSERP { get; set; }



        public SiteInfoParserSchemaMarkupValidatorDTO SchemaMarkupValidator { get; set; }
        public SiteInfoParserTrafficDTO Traffic { get; set; }
    }
}
