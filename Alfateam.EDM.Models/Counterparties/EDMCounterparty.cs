using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Counterparties
{
    public class EDMCounterparty : Counterparty
    {
        public EDMSubject Subject { get; set; }
        public int SubjectId { get; set; }


        public override string ToString()
        {
            return Subject.ToString();
        }
    }
}
