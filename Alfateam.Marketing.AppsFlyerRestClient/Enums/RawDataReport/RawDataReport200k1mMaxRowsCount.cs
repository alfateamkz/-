using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport
{
    public enum RawDataReport200k1mMaxRowsCount
    {
        [Description("200000")]
        UpTo200K = 1,
        [Description("1000000")]
        UpTo1M = 2,
    }
}
