﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add
{
    public class TextAdGroupFeedParamsFeedCategoryIds
    {
        [JsonProperty("Items")]
        public List<long> Items { get; set; } = new List<long>();
    }
}
