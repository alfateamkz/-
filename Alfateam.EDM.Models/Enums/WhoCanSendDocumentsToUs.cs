using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums
{
    public enum WhoCanSendDocumentsToUs
    {
        AllExceptingBlocked = 1,
        OnlyOurCounterparties = 2,
    }
}
