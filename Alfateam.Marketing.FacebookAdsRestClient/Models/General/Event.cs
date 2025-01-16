using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class Event : Profile
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("attending_count")]
        public int AttendingCount { get; set; }

        [JsonProperty("can_guests_invite")]
        public bool CanGuestsInvite { get; set; }

        [JsonProperty("category")]
        public EventCategory Category { get; set; }

        [JsonProperty("cover")]
        public CoverPhoto Cover { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("declined_count")]
        public int DeclinedCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("discount_code_enabled")]
        public bool DiscountCodeEnabled { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("event_times")]
        public List<ChildEvent> EventTimes { get; set; } = new List<ChildEvent>();

        [JsonProperty("guest_list_enabled")]
        public bool GuestListEnabled { get; set; }

        [JsonProperty("interested_count")]
        public int InterestedCount { get; set; }

        [JsonProperty("is_canceled")]
        public bool IsCanceled { get; set; }

        [JsonProperty("is_draft")]
        public bool IsDraft { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        [JsonProperty("is_page_owned")]
        public bool IsPageOwned { get; set; }

        [JsonProperty("maybe_count")]
        public int MaybeCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("noreply_count")]
        public int NoreplyCount { get; set; }

        [JsonProperty("online_event_format")]
        public OnlineEventFormat OnlineEventFormat { get; set; }

        [JsonProperty("online_event_third_party_url")]
        public string OnlineEventThirdPartyURL { get; set; }

        [JsonProperty("owner")]
        public object Owner { get; set; } //TODO: Event Owner

        [JsonProperty("parent_group")]
        public Group ParentGroup { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("scheduled_publish_time")]
        public DateTime ScheduledPublishTime { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("ticket_uri")]
        public string TicketURI { get; set; }

        [JsonProperty("ticket_uri_start_sales_time")]
        public DateTime TicketURIStartSalesTime { get; set; }

        [JsonProperty("ticketing_privacy_uri")]
        public string TicketingPrivacyURI { get; set; }

        [JsonProperty("ticketing_terms_uri")]
        public string TicketingTermsURI { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("type")]
        public EventType Type { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
