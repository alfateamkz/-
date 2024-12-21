using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum ContentIdType
    {
        [Description("user_id")]
        UserId = 1,
        [Description("client_id")]
        ClientId = 2
    }
}
