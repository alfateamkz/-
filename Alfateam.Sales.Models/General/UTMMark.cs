using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class UTMMark : AbsModel
    {
        public string Source { get; set; }
        public string Medium { get; set; }
        public string Campaign { get; set; }


        public string? Content { get; set; }
        public string? Term { get; set; }
    }
}
