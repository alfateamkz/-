using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General.Documents
{
    public class DocumentTypePageDTO : DTOModelAbs<DocumentTypePage>
    {
        public string Title { get; set; }
    }
}
