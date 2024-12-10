using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SearchQueryParser
{
    public class SearchQueryParserQueryDTO : DTOModelAbs<SearchQueryParserQuery>
    {
        public string Query { get; set; }
    }
}
