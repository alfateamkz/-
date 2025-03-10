﻿using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.RequestSuccessDocs
{
    public class EDSIssueRequestSuccessDocs : AbsModel
    {
        public PersonalDocumentRecognizedInfo PersonalDocumentRecognizedInfo { get; set; }
        public CompanyDocumentRecognizedInfo? CompanyDocumentRecognizedInfo { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int EDSIssueRequestId { get; set; }
    }
}
