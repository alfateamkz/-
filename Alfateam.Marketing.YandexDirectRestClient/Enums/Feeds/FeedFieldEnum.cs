using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds
{
    public enum FeedFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Name")]
        Name = 2,
        [Description("BusinessType")]
        BusinessType = 3,
        [Description("SourceType")]
        SourceType = 4,
        [Description("FilterSchema")]
        FilterSchema = 5,
        [Description("UpdatedAt")]
        UpdatedAt = 6,
        [Description("CampaignIds")]
        CampaignIds = 7,
        [Description("NumberOfItems")]
        NumberOfItems = 8,
        [Description("Status")]
        Status = 9,
        [Description("TitleAndTextSources")]
        TitleAndTextSources = 10,
    }
}
