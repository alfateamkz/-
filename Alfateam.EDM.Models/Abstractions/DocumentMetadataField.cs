using Alfateam.Core;
using Alfateam.EDM.Models.Documents.Meta.Fields;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentMetadataField>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentMetadataCurrencyCodeField), "DocumentMetadataCurrencyCodeField")]
    [JsonKnownType(typeof(DocumentMetadataDateField), "DocumentMetadataDateField")]
    [JsonKnownType(typeof(DocumentMetadataDoubleField), "DocumentMetadataDoubleField")]
    [JsonKnownType(typeof(DocumentMetadataIntegerField), "DocumentMetadataIntegerField")]
    [JsonKnownType(typeof(DocumentMetadataStringField), "DocumentMetadataStringField")]
    [JsonKnownType(typeof(DocumentMetadataTaxSumInfoField), "DocumentMetadataTaxSumInfoField")]
    public class DocumentMetadataField : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string FieldName { get; set; }
    }
}
