using Alfateam.Core;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<Signature>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamEDMSignature), "AlfateamEDMSignature")]
    [JsonKnownType(typeof(MarkedAsElectronicallySignature), "MarkedAsElectronicallySignature")]
    [JsonKnownType(typeof(ScanSignature), "ScanSignature")]
    [JsonKnownType(typeof(ScanSignatureWithoutDocFlow), "ScanSignatureWithoutDocFlow")]
    public class Signature : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public DocumentSigningSide Side { get; set; }
        public int SideId { get; set; }
    }
}
