using Alfateam.Core;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions.ApprovalRoutes
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AfterDocSigningAction>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AfterDocSigningMoveToDepartment), "AfterDocSigningMoveToDepartment")]
    [JsonKnownType(typeof(AfterDocSigningNotifyUsers), "AfterDocSigningNotifyUsers")]
    public abstract class AfterDocSigningAction : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
