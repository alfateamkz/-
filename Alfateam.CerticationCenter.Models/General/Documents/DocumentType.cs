using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General.Documents
{
    public class DocumentType : AbsModel
    {
        public DocumentFor For { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<DocumentTypePage> Pages { get; set; } = new List<DocumentTypePage>();







        public List<DocumentCountry> DocumentCountries { get; set; } = new List<DocumentCountry>();
    }
}
