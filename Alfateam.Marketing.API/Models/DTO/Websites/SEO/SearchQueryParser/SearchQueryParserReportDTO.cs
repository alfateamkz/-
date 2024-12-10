using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.API.Models.DTO.Websites.SEO.SearchQueryParser.Results;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SearchQueryParser
{
    public class SearchQueryParserReportDTO : DTOModelAbs<SearchQueryParserReport>
    {
        [ForClientOnly]
        public List<SearchQueryParserEngineDTO> SearchEngines { get; set; } = new List<SearchQueryParserEngineDTO>();
      
        [ForClientOnly]
        public List<SearchQueryParserQueryDTO> SearchQueries { get; set; } = new List<SearchQueryParserQueryDTO>();



        public int SearchFirstResultsCount { get; set; }


        public bool ParseExtendedResults { get; set; }
        public bool ParseSpecialElements { get; set; }
        public bool ParsePaidResults { get; set; }



        [ForClientOnly]
        public List<SearchQueryParserResultDTO> ParsedResults { get; set; } = new List<SearchQueryParserResultDTO>();
    }
}
