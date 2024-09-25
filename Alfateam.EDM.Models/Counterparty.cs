using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models
{
    public class Counterparty : AbsModel
    {

        public string Title { get; set; }


        public CounterpartyGroup Group { get; set; } 
        public int GroupId { get; set; }
    }
}
