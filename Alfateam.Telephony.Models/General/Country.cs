using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General
{
    public class Country : AbsModel
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }
    }
}
