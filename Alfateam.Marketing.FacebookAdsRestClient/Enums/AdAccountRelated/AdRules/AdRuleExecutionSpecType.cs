using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules
{
    public enum AdRuleExecutionSpecType
    {
        [Description("DCO")]
        DCO = 1,
        [Description("PING_ENDPOINT")]
        PingEndpoint = 2,
        [Description("NOTIFICATION")]
        Notification = 3,
        [Description("PAUSE")]
        Pause = 4,
        [Description("REBALANCE_BUDGET")]
        RebalanceBudget = 5,
        [Description("CHANGE_BUDGET")]
        ChangeBudget = 6,
        [Description("CHANGE_BID")]
        ChangeBid = 7,
        [Description("ROTATE")]
        Rotate = 8,
        [Description("UNPAUSE")]
        Unpause = 9,
        [Description("CHANGE_CAMPAIGN_BUDGET")]
        ChangeCampaignBudget = 10,
        [Description("ADD_INTEREST_RELAXATION")]
        AddInterestRelaxation = 11,
        [Description("ADD_QUESTIONNAIRE_INTERESTS")]
        AddQuestionnaireInterests = 12,
        [Description("INCREASE_RADIUS")]
        IncreaseRadius = 13,
        [Description("UPDATE_CREATIVE")]
        UpdateCreative = 14,
        [Description("UPDATE_LAX_BUDGET")]
        UpdateLaxBudget = 15,
        [Description("UPDATE_LAX_DURATION")]
        UpdateLaxDuration = 16,
        [Description("AUDIENCE_CONSOLIDATION")]
        AudienceConsolidation = 17,
        [Description("AUDIENCE_CONSOLIDATION_ASK_FIRST")]
        AudienceConsolidationAskFirst = 18,
        [Description("AD_RECOMMENDATION_APPLY")]
        AdRecommendationApply = 19,
    }
}
