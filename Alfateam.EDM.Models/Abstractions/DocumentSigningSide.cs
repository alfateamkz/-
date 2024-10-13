using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentSigningSide>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamEDMDocumentSigningSide), "AlfateamEDMDocumentSigningSide")]
    [JsonKnownType(typeof(CompanyDocumentSigningSide), "CompanyDocumentSigningSide")]
    [JsonKnownType(typeof(IndividualDocumentSigningSide), "IndividualDocumentSigningSide")]
    public class DocumentSigningSide : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
