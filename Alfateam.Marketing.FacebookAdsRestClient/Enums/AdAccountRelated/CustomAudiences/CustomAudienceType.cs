using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.CustomAudiences
{
    public enum CustomAudienceType
    {
        [Description("UNKNOWN")]
        Unknown = 1,
        [Description("FILE_IMPORTED")]
        FileImported = 2,
        [Description("EVENT_BASED")]
        EventBased = 3,
        [Description("SEED_BASED")]
        SeedBased = 4,
        [Description("THIRD_PARTY_IMPORTED")]
        ThirdPartyImported = 5,
        [Description("COPY_PASTE")]
        CopyPaste = 6,
        [Description("CONTACT_IMPORTER")]
        ContactImporter = 7,
        [Description("HOUSEHOLD_AUDIENCE")]
        HouseholdAudience = 8,
    }
}
