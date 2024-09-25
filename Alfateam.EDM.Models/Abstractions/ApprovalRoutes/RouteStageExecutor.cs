using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using Alfateam.EDM.Models.ApprovalRoutes.RouteStageExecutors;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Abstractions.ApprovalRoutes
{
    [JsonConverter(typeof(JsonKnownTypesConverter<RouteStageExecutor>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(RouteStageExecutorDepartment), "RouteStageExecutorDepartment")]
    [JsonKnownType(typeof(RouteStageExecutorUsers), "RouteStageExecutorUsers")]
    public abstract class RouteStageExecutor : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
