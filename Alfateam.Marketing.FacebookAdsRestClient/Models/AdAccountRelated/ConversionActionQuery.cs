using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class ConversionActionQuery
    {
        [JsonProperty("action_type")]
        public object ActionType { get; set; } //list<(list) or (string)>

        [JsonProperty("application")]
        public object Application { get; set; } //list<(list) or (id)>

        [JsonProperty("conversion_id")]
        public List<int> ConversionId { get; set; } = new List<int>();

        [JsonProperty("creative")]
        public object Creative { get; set; } //list<(list) or (id)>

        [JsonProperty("dataset")]
        public List<int> Dataset { get; set; } = new List<int>();

        [JsonProperty("event")]
        public List<int> Event { get; set; } = new List<int>();

        [JsonProperty("event_creator")]
        public List<string> EventCreator { get; set; } = new List<string>();

        [JsonProperty("event_type")]
        public List<string> EventType { get; set; } = new List<string>();

        [JsonProperty("fb_pixel")]
        public List<int> FBPixel { get; set; } = new List<int>();

        [JsonProperty("fb_pixel_event")]
        public List<string> FBPixelEvent { get; set; } = new List<string>();

        [JsonProperty("leadgen")]
        public List<int> Leadgen { get; set; } = new List<int>();

        [JsonProperty("object")]
        public List<int> Object { get; set; } = new List<int>();

        [JsonProperty("object_domain")]
        public List<int> ObjectDomain { get; set; } = new List<int>();

        [JsonProperty("offer")]
        public List<int> Offer { get; set; } = new List<int>();

        [JsonProperty("offer_creator")]
        public List<int> OfferCreator { get; set; } = new List<int>();

        [JsonProperty("offsite_pixel")]
        public List<int> OffsitePixel { get; set; } = new List<int>();

        [JsonProperty("page")]
        public List<int> Page { get; set; } = new List<int>();

        [JsonProperty("page_parent")]
        public List<int> PageParent { get; set; } = new List<int>();

        [JsonProperty("post")]
        public List<int> Post { get; set; } = new List<int>();

        [JsonProperty("post_object")]
        public List<int> PostObject { get; set; } = new List<int>();

        [JsonProperty("post_object_wall")]
        public List<int> PostObjectWall { get; set; } = new List<int>();

        [JsonProperty("post_wall")]
        public List<int> PostWall { get; set; } = new List<int>();

        [JsonProperty("question")]
        public List<int> Question { get; set; } = new List<int>();

        [JsonProperty("question_creator")]
        public List<int> QuestionCreator { get; set; } = new List<int>();

        [JsonProperty("response")]
        public List<string> Response { get; set; } = new List<string>();

        [JsonProperty("subtype")]
        public List<string> Subtype { get; set; } = new List<string>();
    }
}
