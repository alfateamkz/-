using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results
{
    public class SearchQueryParserResult : AbsModel
    {
        public SearchQueryParserQuery Query { get; set; }
        public List<SearchQueryParserResultByEngine> ByEngines { get; set; } = new List<SearchQueryParserResultByEngine>();
        
    }
}
