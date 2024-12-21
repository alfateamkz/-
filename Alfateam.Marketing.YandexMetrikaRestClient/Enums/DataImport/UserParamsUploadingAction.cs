using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum UserParamsUploadingAction
    {
        [Description("update")]
        Update = 1,
        [Description("delete_keys")]
        DeleteKeys = 2,
    }
}
