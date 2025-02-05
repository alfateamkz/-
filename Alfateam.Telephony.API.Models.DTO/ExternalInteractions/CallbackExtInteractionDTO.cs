using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback;
using Alfateam.Telephony.API.Models.DTO.General.WorkingDays;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback;
using Alfateam.Telephony.Models.General.WorkingDays;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions
{
    public class CallbackExtInteractionDTO : ExtInteractionDTO
    {
        public string DisplayedName { get; set; }
        public WorkingDaysModelDTO WorkingDays { get; set; }
        public string? URLCallback { get; set; }
        public string? ForMetricsJSCode { get; set; }
        public bool RestrictCallsCount { get; set; }

        public List<CallbackExtInteractionBannedIPDTO> BannedIPs { get; set; } = new();
        public bool EnableRecaptcha { get; set; }
        public string WebsiteDomain { get; set; }


        public CallbackClientsScoringCriteriasDTO ClientsScoringCriterias { get; set; }
        public CallbackUICustomizationDTO UICustomization { get; set; }
        public CallbackNumbersFilterDTO NumbersFilter { get; set; }
        public CallbackCountriesFilterDTO CountriesFilter { get; set; }
    }
}
