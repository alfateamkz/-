using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Core
{
    public class ItemsWithTotalCount<T> where T : class
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }



    }
}
