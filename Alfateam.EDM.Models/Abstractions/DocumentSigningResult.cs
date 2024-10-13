using Alfateam.Core;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentSigningResult>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentRejectedResult), "DocumentRejectedResult")]
    [JsonKnownType(typeof(DocumentSuccessfullySignedResult), "DocumentSuccessfullySignedResult")]
    public class DocumentSigningResult : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public DocumentSigningSide Side { get; set; }
        public int SideId { get; set; }
    }
}
