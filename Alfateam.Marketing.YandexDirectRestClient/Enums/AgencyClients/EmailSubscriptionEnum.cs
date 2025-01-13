using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum EmailSubscriptionEnum
    {
        [Description("RECEIVE_RECOMMENDATIONS")]
        ReceiveRecommendations = 1,
        [Description("TRACK_MANAGED_CAMPAIGNS")]
        TrackManagedCampaigns = 2,
        [Description("TRACK_POSITION_CHANGES")]
        TrackPositionChanges = 3,
    }
}
