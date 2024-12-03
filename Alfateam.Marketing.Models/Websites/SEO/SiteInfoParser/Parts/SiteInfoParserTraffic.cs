using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserTraffic : AbsModel
    {
        public int VisitsCount { get; set; }

        public double DirectTrafficPercent { get; set; }
        public double DirectTrafficCount { get; set; }


        public double SearchTrafficPercent { get; set; }
        public double SearchTrafficCount { get; set; }



        public double MediaTrafficPercent { get; set; }
        public double MediaTrafficCount { get; set; }


        public double RelevantTrafficPercent { get; set; }
        public double RelevantTrafficCount { get; set; }


        public double SocialMediaTrafficPercent { get; set; }
        public double SocialMediaTrafficCount { get; set; }



        public double EmailTrafficPercent { get; set; }
        public double EmailTrafficCount { get; set; }



        public string MainCountryCode { get; set; }
        public string Host { get; set; }
        public string? MainThematicCategory { get; set; }
    }
}
