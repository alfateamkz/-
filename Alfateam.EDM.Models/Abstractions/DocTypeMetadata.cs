using Alfateam.Core;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Documents.TypesMetadata;
using JsonKnownTypes;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<DocTypeMetadata>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ActDisagreementDocTypeMetadata), "ActDisagreementDocTypeMetadata")]
    [JsonKnownType(typeof(ActDocTypeMetadata), "ActDocTypeMetadata")]
    [JsonKnownType(typeof(ActReconciliationDocTypeMetadata), "ActReconciliationDocTypeMetadata")]
    [JsonKnownType(typeof(AgreementDocTypeMetadata), "AgreementDocTypeMetadata")]
    [JsonKnownType(typeof(AttorneyDocTypeMetadata), "AttorneyDocTypeMetadata")]
    [JsonKnownType(typeof(CertificateRegistryDocTypeMetadata), "CertificateRegistryDocTypeMetadata")]
    [JsonKnownType(typeof(ClaimDocTypeMetadata), "ClaimDocTypeMetadata")]
    [JsonKnownType(typeof(ConsignmentDocTypeMetadata), "ConsignmentDocTypeMetadata")]
    [JsonKnownType(typeof(DetalizationDocTypeMetadata), "DetalizationDocTypeMetadata")]
    [JsonKnownType(typeof(InvoiceDocTypeMetadata), "InvoiceDocTypeMetadata")]
    [JsonKnownType(typeof(LetterDocTypeMetadata), "LetterDocTypeMetadata")]
    [JsonKnownType(typeof(NonFormalizedDocTypeMetadata), "NonFormalizedDocTypeMetadata")]
    [JsonKnownType(typeof(PriceListAgreementDocTypeMetadata), "PriceListAgreementDocTypeMetadata")]
    [JsonKnownType(typeof(PriceListDocTypeMetadata), "PriceListDocTypeMetadata")]
    [JsonKnownType(typeof(SupplementaryAgreementDocTypeMetadata), "SupplementaryAgreementDocTypeMetadata")]
    [JsonKnownType(typeof(WaybillDocTypeMetadata), "WaybillDocTypeMetadata")]
    public class DocTypeMetadata : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }




        [NotMapped]
        public virtual string Title => "Абстрактный тип";

        [NotMapped]
        public virtual int? RequiredDocumentSides => 2;


        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }



        public string? Comment { get; set; }
    }
}
