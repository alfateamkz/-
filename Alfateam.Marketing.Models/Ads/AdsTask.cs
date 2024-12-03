using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Ads
{
    public class AdsTask : AbsModel
    {
        public AdsServiceAccount Account { get; set; }


        public List<Segment> IncludedSegments { get; set; } = new List<Segment>();
        public List<Segment> ExcludedSegments { get; set; } = new List<Segment>();
    }
}
