using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.Sides
{
    public class CompanyDocumentSigningSide
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }

        public string BusinessNumber { get; set; }
    }
}
