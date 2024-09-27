using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.General;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    /// <summary>
    /// Модель документа
    /// </summary>
    [JsonConverter(typeof(JsonKnownTypesConverter<Document>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(NonFormalizedDocument), "NonFormalizedDocument")]
    public class Document : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }


        public string Title { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
    }
}
