using Alfateam.Core;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser
{
    public class SearchQueryParserReport : AbsModel
    {
        public List<SearchQueryParserEngine> SearchEngines { get; set; } = new List<SearchQueryParserEngine>();
        public List<SearchQueryParserQuery> SearchQueries { get; set; } = new List<SearchQueryParserQuery>();



        public int SearchFirstResultsCount { get; set; }


        public bool ParseExtendedResults { get; set; }
        public bool ParseSpecialElements { get; set; }
        public bool ParsePaidResults { get; set; }




        public List<SearchQueryParserResult> ParsedResults { get; set; } = new List<SearchQueryParserResult>();
    }
}
