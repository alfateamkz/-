using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum ClientIdType
    {
        [Description("USER_ID")]
        UserId = 1,
        [Description("CLIENT_ID")]
        ClientId = 2,
        [Description("YCLID")]
        YClId = 3,
    }
}
