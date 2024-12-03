using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results
{
    public class SearchQueryParserResultByEngine : AbsModel
    {
        public SearchQueryParserEngine Engine { get; set; }
        public List<SearchQueryParserResultPosition> Results { get; set; } = new List<SearchQueryParserResultPosition>();


    }
}
