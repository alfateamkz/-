using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.CertificationCenter.Models.DTO.DocumentRecognizedInfo;
using Alfateam.CertificationCenter.Models.RequestSuccessDocs;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.RequestSuccessDocs
{
    public class DigitalPOAIssueRequestSuccessDocsDTO : DTOModelAbs<DigitalPOAIssueRequestSuccessDocs>
    {
        public PersonalDocumentRecognizedInfoDTO PersonForDocumentRecognizedInfo { get; set; }
    }
}
