using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    
    public enum CampaignFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("AttributionModel")]
        AttributionModel = 2,
        [Description("CounterIds")]
        CounterIds = 3,
        [Description("PriorityGoals")]
        PriorityGoals = 4,
        [Description("Type")]
        Type = 5,
        [Description("Name")]
        Name = 6,
        [Description("StatusArchived")]
        StatusArchived = 7,
    }
}
