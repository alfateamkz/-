using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups
{
    public enum DynamicTextFeedAdGroupFieldEnum
    {
        [Description("Source")]
        Source = 1,
        [Description("FeedId")]
        FeedId = 2,
        [Description("SourceType")]
        SourceType = 3,
        [Description("SourceProcessingStatus")]
        SourceProcessingStatus = 4,
        [Description("AutotargetingCategories")]
        AutotargetingCategories = 5,
    }
}
