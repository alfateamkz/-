using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General.Documents
{
    public class DocumentCountryDTO : DTOModelAbs<DocumentCountry>
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }



        [ForClientOnly]
        public List<DocumentTypeDTO> DocumentTypes { get; set; } = new List<DocumentTypeDTO>();

        [HiddenFromClient, DTOFieldBindWith("DocumentTypes", typeof(DocumentType))]
        public List<int> DocumentTypeIds { get; set; } = new List<int>();
    }
}
