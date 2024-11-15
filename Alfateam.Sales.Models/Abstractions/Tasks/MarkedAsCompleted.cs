using Alfateam.Core;
using Alfateam.Sales.Models.Tasks;
using Alfateam.Sales.Models.Tasks.AsCompleted;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions.Tasks
{

    [JsonConverter(typeof(JsonKnownTypesConverter<MarkedAsCompleted>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(SimpleMarkedAsCompleted), "SimpleMarkedAsCompleted")]
    [JsonKnownType(typeof(WithAmountMarkedAsCompleted), "WithAmountMarkedAsCompleted")]
    public class MarkedAsCompleted : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string? Comment { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int UserTaskId { get; set; }
    }
}
