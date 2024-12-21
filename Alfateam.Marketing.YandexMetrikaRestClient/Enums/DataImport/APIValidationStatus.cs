using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum APIValidationStatus
    {
        [Description("PASSED")]
        Passed = 1,
        [Description("FAILED")]
        Failed = 2
    }
}
