using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Push
{
    public enum PushBatchRequestBatchMessagesAndroidContentVisibility
    {
        [Description("secret")]
        Secret = 1,
        [Description("private")]
        Private = 2,
        [Description("public")]
        Public = 3,
    }
}
