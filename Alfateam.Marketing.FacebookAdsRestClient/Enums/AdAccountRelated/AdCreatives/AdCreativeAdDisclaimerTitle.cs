using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives
{
    public enum AdCreativeAdDisclaimerTitle
    {
        [Description("health_disclaimer")]
        HealthDisclaimer = 1,
        [Description("important_safety_information")]
        ImportantSafetyInformation = 2,
        [Description("medication_guide")]
        MedicationGuide = 3,
        [Description("offer_details")]
        OfferDetails = 4,
        [Description("prescribing_information")]
        PrescribingInformation = 5,
        [Description("terms_and_conditions")]
        TermsAndConditions = 6,
    }
}
