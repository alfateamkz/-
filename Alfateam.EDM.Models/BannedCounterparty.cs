using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models
{
    public class BannedCounterparty : AbsModel
    {
        public Counterparty Counterparty { get; set; }
        public int CounterpartyId { get; set; }


        public string BanReason { get; set; }
    }
}
