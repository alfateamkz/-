using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum AgencyClientsMethod
    {
        [Description("add")]
        Add = 1,
        [Description("get")]
        Get = 2,
        [Description("update")]
        Update = 3,
    }
}
