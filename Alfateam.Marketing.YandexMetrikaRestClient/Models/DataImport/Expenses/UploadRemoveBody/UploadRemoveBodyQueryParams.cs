﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadRemoveBody
{
    public class UploadRemoveBodyQueryParams
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }
    }
}
