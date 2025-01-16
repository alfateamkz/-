using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated
{
    public enum WhatsAppBusinessPartnerClientVerificationRejectedReason
    {
        [Description("LEGAL_NAME_NOT_MATCHING")]
        LegalNameNotMatching = 1,
        [Description("WEBSITE_NOT_MATCHING")]
        WebsiteNotMatching = 2,
        [Description("NONE")]
        None = 3,
        [Description("BUSINESS_NOT_ELIGIBLE")]
        BusinessNotEligible = 4,
        [Description("LEGAL_NAME_NOT_FOUND_IN_DOCUMENTS")]
        LegalNameNotFoundInDocuments = 5,
        [Description("MALFORMED_DOCUMENTS")]
        MalformedDocuments = 6,
        [Description("ADDRESS_NOT_MATCHING")]
        AddressNotMatching = 7,
    }
}
