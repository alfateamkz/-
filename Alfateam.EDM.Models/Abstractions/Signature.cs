using Alfateam.Core;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<Signature>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamEDMSignature), "AlfateamEDMSignature")]
    [JsonKnownType(typeof(ScanSignature), "ScanSignature")]
    public class Signature : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public DocumentSigningSide Side { get; set; }
        public int SideId { get; set; }


        public User SignedBy { get; set; }
        public int SignedById { get; set; }


        /// <summary>
        /// Автоматическое поле. Указывает на конкретную сущность DocumentSuccessfullySignedResult
        /// </summary>
        public int? DocumentSuccessfullySignedResultId { get; set; }
    }
}
