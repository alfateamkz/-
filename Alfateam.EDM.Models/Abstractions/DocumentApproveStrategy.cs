using Alfateam.Core;
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.Documents.Types;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentApproveStrategy>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentApprovalDepartmentStrategy), "DocumentApprovalDepartmentStrategy")]
    [JsonKnownType(typeof(DocumentApprovalRouteStrategy), "DocumentApprovalRouteStrategy")]
    public class DocumentApproveStrategy : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string? Comment { get; set; }
    }
}
