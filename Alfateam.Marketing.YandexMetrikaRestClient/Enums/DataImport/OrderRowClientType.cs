using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum OrderRowClientType
    {
        [Description("CONTACT")]
        Contact = 1,
        [Description("COMPANY")]
        Company = 2,
    }
}
