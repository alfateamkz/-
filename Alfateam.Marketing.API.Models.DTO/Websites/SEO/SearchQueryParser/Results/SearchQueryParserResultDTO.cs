using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SearchQueryParser.Results
{
    public class SearchQueryParserResultDTO : DTOModelAbs<SearchQueryParserResult>
    {
        [ForClientOnly]
        public SearchQueryParserQueryDTO Query { get; set; }
        [ForClientOnly]
        public List<SearchQueryParserResultByEngineDTO> ByEngines { get; set; } = new List<SearchQueryParserResultByEngineDTO>();
    }
}
