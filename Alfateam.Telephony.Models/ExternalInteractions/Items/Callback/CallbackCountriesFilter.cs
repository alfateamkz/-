using Alfateam.Core;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.Callback
{
    public class CallbackCountriesFilter : AbsModel
    {
        public CallbackCountriesFilterType Type { get; set; }
        public List<Country> CountriesExcept { get; set; } = new List<Country>();
    }
}
