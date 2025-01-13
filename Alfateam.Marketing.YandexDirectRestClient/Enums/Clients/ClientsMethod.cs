using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Clients
{
    public enum ClientsMethod
    {
        [Description("get")]
        Get = 1,
        [Description("update")]
        Update = 2,
    }
}
