using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SearchQueryParser.Results
{
    public class SearchQueryParserResultByEngineDTO : DTOModelAbs<SearchQueryParserResultByEngine>
    {
        [ForClientOnly]
        public SearchQueryParserEngineDTO Engine { get; set; }
        [ForClientOnly]
        public List<SearchQueryParserResultPositionDTO> Results { get; set; } = new List<SearchQueryParserResultPositionDTO>();
    }
}
