using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Operations
{
    public enum OperationEAction
    {
        [Description("cut_fragment")]
        CutFragment = 1,
        [Description("cut_parameter")]
        CutParameter = 2,
        [Description("cut_all_parameters")]
        CutAllParameters = 3,
        [Description("merge_https_and_http")]
        MergeHTTPSAndHTTP = 4,
        [Description("to_lower")]
        ToLower = 5,
        [Description("replace_domain")]
        ReplaceDomain = 6
    }
}
