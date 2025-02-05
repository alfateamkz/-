using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    public enum SentFromWebsiteFormHandlingStatus
    {
        Waiting = 1,
        InWork = 2,
        HandledSuccessfully = 3,
        HandledThrashLead = 4,
        HandledUnsuccessfully = 5,
        ContactNotAvailable = 6,
        IgnoredByClient = 7
    }
}
