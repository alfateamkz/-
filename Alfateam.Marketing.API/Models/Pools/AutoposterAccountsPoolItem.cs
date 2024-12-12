using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.API.Models.Pools
{
    public class AutoposterAccountsPoolItem
    {
        public AutopostingAccount Account { get; set; }
        public AbsAutoposter Autoposter { get; set; }
    }
}
