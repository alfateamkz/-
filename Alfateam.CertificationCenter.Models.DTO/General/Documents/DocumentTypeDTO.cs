using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General.Documents
{
    public class DocumentTypeDTO : DTOModelAbs<DocumentType>
    {
        public DocumentFor For { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<DocumentTypePageDTO> Pages { get; set; } = new List<DocumentTypePageDTO>();
    }
}
