using Alfateam.Core;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.General.Subjects;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<Counterparty>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CompanyCounterparty), "CompanyCounterparty")]
    [JsonKnownType(typeof(EDMCounterparty), "EDMCounterparty")]
    [JsonKnownType(typeof(IndividualCounterparty), "IndividualCounterparty")]
    public class Counterparty : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public CounterpartyGroup Group { get; set; }
        public int GroupId { get; set; }


        public int EDMSubjectId { get; set; }


        public bool IsThisSubject(EDMSubject subject)
        {
            if(this is CompanyCounterparty companyCounterparty && subject is Company company)
            {
                return companyCounterparty.BusinessNumber == company.BusinessNumber && companyCounterparty.CountryCode == company.CountryCode;
            }
            else if (this is IndividualCounterparty individualCounterparty && subject is Individual individual)
            {
                return individualCounterparty.BusinessNumber == individual.BusinessNumber && individualCounterparty.CountryCode == individual.CountryCode;
            }
            else if (this is EDMCounterparty edmCounterparty)
            {
                return edmCounterparty.EDMSubjectId == subject.Id;
            }
            return false;
        }
        public bool IsThisDocumentSigningSide(DocumentSigningSide subject)
        {
            if (this is CompanyCounterparty companyCounterparty && subject is CompanyDocumentSigningSide company)
            {
                return companyCounterparty.BusinessNumber == company.BusinessNumber && companyCounterparty.CountryCode == company.CountryCode;
            }
            else if (this is IndividualCounterparty individualCounterparty && subject is IndividualDocumentSigningSide individual)
            {
                return individualCounterparty.BusinessNumber == individual.BusinessNumber && individualCounterparty.CountryCode == individual.CountryCode;
            }
            else if (this is EDMCounterparty edmCounterparty && subject is AlfateamEDMDocumentSigningSide edmSubject)
            {
                return edmCounterparty.EDMSubjectId == edmSubject.SubjectId;
            }
            return false;
        }      
    }
}
