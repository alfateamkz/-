using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Audiences.Import
{
    public enum ImportANewAudienceActionType
    {
        [Description("add")]
        Add = 1,
        [Description("remove")]
        Remove = 2,
        [Description("overwrite")]
        Overwrite = 3,
    }
}
