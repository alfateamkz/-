using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.HLR.Results
{
    public class HLRTaskIterationResult : AbsModel
    {
        public HLRTaskIteration Iteration { get; set; }
        public int IterationId { get; set; }


        public List<HLRTaskIterationResultNumber> Numbers { get; set; } = new List<HLRTaskIterationResultNumber>();
    }
}
