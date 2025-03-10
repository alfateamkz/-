﻿using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchAdd;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsList
{
    public class FeedsListResponse
    {
        [JsonProperty("feeds")]
        public List<Feed> Feeds { get; set; } = new List<Feed>();
    }
}
