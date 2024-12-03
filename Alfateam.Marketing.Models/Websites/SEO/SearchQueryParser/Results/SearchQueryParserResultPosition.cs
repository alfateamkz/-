using Alfateam.Core;
using Alfateam.Marketing.Models.Enums.SEO.SearchQueryParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results
{
    public class SearchQueryParserResultPosition : AbsModel
    {
        public int Position {  get; set; }
        public string URL { get; set; }
        public SearchQueryParserResultType ResultType { get; set; }
        public SearchQueryParserLinkType LinkType { get; set; }


        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? HighlightedText { get; set; }
        public string? AdditionalLinks { get; set; }
        public string? AdditionalInfo { get; set; }


        public double? RatingInSnippet { get; set; }
        public DateTime? Date { get; set; }


        public string? BreadCrumps { get; set; }

        public string Host { get; set; }
    }
}
