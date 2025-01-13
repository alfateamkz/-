using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum ClientRestrictionEnum
    {
        [Description("CAMPAIGNS_TOTAL_PER_CLIENT")]
        CampaignsTotalPerClient = 1,
        [Description("CAMPAIGNS_UNARCHIVED_PER_CLIENT")]
        CampaignsUnarchivedPerClient = 2,
        [Description("ADGROUPS_TOTAL_PER_CAMPAIGN")]
        AdGroupsTotalPerCampaign = 3,
        [Description("ADS_TOTAL_PER_ADGROUP")]
        AdsTotalPerAdgroup = 4,
        [Description("KEYWORDS_TOTAL_PER_ADGROUP")]
        KeywordsTotalPerAdgroup = 5,
        [Description("AD_EXTENSIONS_TOTAL")]
        AdExtensionsTotal = 6,
        [Description("STAT_REPORTS_TOTAL_IN_QUEUE")]
        StatReportsTotalInQueue = 7,
        [Description("FORECAST_REPORTS_TOTAL_IN_QUEUE")]
        ForecastReportsTotalInQueue = 8,
        [Description("WORDSTAT_REPORTS_TOTAL_IN_QUEUE")]
        WordstatReportsTotalInQueue = 9,
        [Description("API_POINTS")]
        APIPoints = 10,
        [Description("GENERAL_DOMAIN_BLACKLIST_SIZE")]
        GeneralDomainBlacklistSize = 11,
        [Description("VIDEO_DOMAIN_BLACKLIST_SIZE")]
        VideoDomainBlacklistSize = 12,
    }
}
