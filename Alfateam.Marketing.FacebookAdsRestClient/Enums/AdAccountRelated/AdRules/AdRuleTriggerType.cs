using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules
{
    public enum AdRuleTriggerType
    {
        [Description("METADATA_CREATION")]
        MetadataCreation = 1,
        [Description("METADATA_UPDATE")]
        MetadataUpdate = 2,
        [Description("STATS_MILESTONE")]
        StatsMilestone = 3,
        [Description("STATS_CHANGE")]
        StatsChange = 4,
        [Description("DELIVERY_INSIGHTS_CHANGE")]
        DeliveryInsightsChange = 5,
    }
}
