﻿using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.DocumentRecognizedInfo
{
    public class PersonalDocumentRecognizedInfoDTO : DTOModelAbs<PersonalDocumentRecognizedInfo>
    {
        public string DocumentCountryCode { get; set; }
        public string CitizenshipCountryCode { get; set; }


        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronynic { get; set; }
        public DateTime BirthDate { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentOwnerGender Gender { get; set; }


        public DateTime IssuedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public string? Address { get; set; }



        public string? AdditionalInfo { get; set; }
    }
}
