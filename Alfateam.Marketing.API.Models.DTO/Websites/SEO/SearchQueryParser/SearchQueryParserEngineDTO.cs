using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SearchQueryParser
{
    public class SearchQueryParserEngineDTO : DTOModelAbs<SearchQueryParserEngine>
    {
        public SearchEngineType SearchEngineType { get; set; }
    }
}
