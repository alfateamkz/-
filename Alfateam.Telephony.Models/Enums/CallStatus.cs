using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Enums
{
    public enum CallStatus
    {
        Dialing = 1,
        Active = 2,
        Finished = 3,
        NotAnswered = 4,
        Declined = 5,
        SubscriberNotAvailable = 6,
    }
}
