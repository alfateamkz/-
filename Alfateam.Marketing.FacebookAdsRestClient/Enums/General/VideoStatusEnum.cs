using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.General
{
    public enum VideoStatusEnum
    {
        [Description("ready")]
        Ready = 1,
        [Description("processing")]
        Processing = 2,
        [Description("error")]
        Error = 3,
    }
}
