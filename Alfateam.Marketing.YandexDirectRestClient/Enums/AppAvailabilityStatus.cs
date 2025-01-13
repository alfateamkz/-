using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums
{
    public enum AppAvailabilityStatus
    {
        [Description("UNPROCESSED")]
        Unprocessed = 1,
        [Description("AVAILABLE")]
        Available = 2,
        [Description("NOT_AVAILABLE")]
        NotAvailable = 3,
    }
}
