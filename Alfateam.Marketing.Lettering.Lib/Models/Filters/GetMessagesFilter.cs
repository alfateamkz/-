using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Lettering.Lib.Models.Filters
{
    public class GetMessagesFilter
    {
        public int Offset { get; set; }
        public int Count { get; set; } = 20;
        public string Contact { get; set; }

    }
}
