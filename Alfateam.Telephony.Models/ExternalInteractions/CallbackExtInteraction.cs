using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback;
using Alfateam.Telephony.Models.General.WorkingDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions
{
    public class CallbackExtInteraction : ExtInteraction
    {
        public string DisplayedName { get; set; }
        public WorkingDaysModel WorkingDays { get; set; }
        public string? URLCallback { get; set; }
        public string? ForMetricsJSCode { get; set; }
        public bool RestrictCallsCount { get; set; }

        public List<CallbackExtInteractionBannedIP> BannedIPs { get; set; } = new();
        public bool EnableRecaptcha { get; set; }
        public string WebsiteDomain { get; set; }


        public CallbackClientsScoringCriterias ClientsScoringCriterias { get; set; }
        public CallbackUICustomization UICustomization { get; set; }
        public CallbackNumbersFilter NumbersFilter { get; set; }
        public CallbackCountriesFilter CountriesFilter  { get; set; }
    }
}
