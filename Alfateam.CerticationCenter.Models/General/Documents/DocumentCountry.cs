using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General.Documents
{
    public class DocumentCountry : AbsModel
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }


        public List<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();
    }
}
