using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Diagnostics
{
    public enum SiteProblemSeverityEnum
    {
        [Description("FATAL")]
        Fatal = 1,
        [Description("CRITICAL")]
        Critical = 2,
        [Description("POSSIBLE_PROBLEM")]
        PossibleProblem = 3,
        [Description("RECOMMENDATION")]
        Recommendation = 4
    }
}
