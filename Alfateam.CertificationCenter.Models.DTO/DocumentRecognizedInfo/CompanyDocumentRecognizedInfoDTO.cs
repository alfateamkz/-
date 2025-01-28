using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.DocumentRecognizedInfo
{
    public class CompanyDocumentRecognizedInfoDTO : DTOModelAbs<CompanyDocumentRecognizedInfo>
    {
        public string CompanyCountryCode { get; set; }
        public string CompanyFullName { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationForm { get; set; }
        public string CompanyMainSector { get; set; }
        public string BusinessNumber { get; set; }


        public DateTime? RegisteredAt { get; set; }


        public string LegalAddress { get; set; }
        public string LegalAddressState { get; set; }
        public string LegalAddressCity { get; set; }
        public string LegalAddressStreetAndHouse { get; set; }


        public string? PostalAddress { get; set; }
        public string? PostalAddressZIP { get; set; }


        public string? AdditionalInfo { get; set; }
    }
}
