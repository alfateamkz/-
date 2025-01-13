﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add
{
    public class TextAdGroupFeedParamsAdd
    {
        [JsonProperty("FeedId")]
        public long FeedId { get; set; }

        [JsonProperty("FeedCategoryIds")]
        public TextAdGroupFeedParamsFeedCategoryIds FeedCategoryIds { get; set; }
    }
}
