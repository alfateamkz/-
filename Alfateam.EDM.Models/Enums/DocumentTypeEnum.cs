using Alfateam.EDM.Models.Attributes;
using Alfateam.EDM.Models.Documents.TypesMetadata;
using Alfateam.EDM.Models.Documents.TypesMetadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums
{
    public enum DocumentTypeEnum
    {
        [DocTypeRelatedTo(typeof(InternalConsignmentDocTypeMetadata))] InternalConsignment = -1,


        [DocTypeRelatedTo(typeof(ActDisagreementDocTypeMetadata))] ActDisagreement = 1,
        [DocTypeRelatedTo(typeof(ActDocTypeMetadata))] Act = 2,
        [DocTypeRelatedTo(typeof(ActReconciliationDocTypeMetadata))] ActReconciliation = 3,
        [DocTypeRelatedTo(typeof(AgreementDocTypeMetadata))] Agreement = 4,
        [DocTypeRelatedTo(typeof(AttorneyDocTypeMetadata))] Attorney = 5,
        [DocTypeRelatedTo(typeof(CertificateRegistryDocTypeMetadata))] CertificateRegistry = 6,
        [DocTypeRelatedTo(typeof(ClaimDocTypeMetadata))] Claim = 7,
        [DocTypeRelatedTo(typeof(ConsignmentDocTypeMetadata))] Consignment = 8,
        [DocTypeRelatedTo(typeof(DetalizationDocTypeMetadata))] Detalization = 9,
        [DocTypeRelatedTo(typeof(InvoiceDocTypeMetadata))] Invoice = 10,
        [DocTypeRelatedTo(typeof(LetterDocTypeMetadata))] Letter = 11,
        [DocTypeRelatedTo(typeof(NonFormalizedDocTypeMetadata))] NonFormalized = 12,
        [DocTypeRelatedTo(typeof(PriceListAgreementDocTypeMetadata))] PriceListAgreement = 13,
        [DocTypeRelatedTo(typeof(PriceListDocTypeMetadata))] PriceList = 14,
        [DocTypeRelatedTo(typeof(SupplementaryAgreementDocTypeMetadata))] SupplementaryAgreement = 15,
        [DocTypeRelatedTo(typeof(WaybillDocTypeMetadata))] Waybill = 16
    }
}
