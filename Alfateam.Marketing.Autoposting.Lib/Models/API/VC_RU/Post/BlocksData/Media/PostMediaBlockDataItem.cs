﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Media
{
    public class PostMediaBlockDataItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public PostMediaBlockDataItemImage Image { get; set; }
    }
}
