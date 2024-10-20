using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.General.Subjects;
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

        /// <summary>
        /// Автоматическое поле, указывает на документ
        /// </summary>
        public int DocumentId { get; set; }

        public bool IsThisSubject(EDMSubject subject)
        {
            if (this is CompanyDocumentSigningSide companySide && subject is Company company)
            {
                return companySide.BusinessNumber == company.BusinessNumber && companySide.CountryCode == company.CountryCode;
            }
            else if (this is IndividualDocumentSigningSide individualSide && subject is Individual individual)
            {
                return individualSide.BusinessNumber == individual.BusinessNumber && individualSide.CountryCode == individual.CountryCode;
            }
            else if (this is AlfateamEDMDocumentSigningSide edmSide)
            {
                return edmSide.SubjectId == subject.Id;
            }
            return false;
        }
    }
}
