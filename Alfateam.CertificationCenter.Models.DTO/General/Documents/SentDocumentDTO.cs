using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.Core.Attributes.DTO;
using Alfateam.SharedModels;
using Alfateam.SharedModels.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General.Documents
{
    public class SentDocumentDTO : DTOModelAbs<SentDocument>
    {
        [ForClientOnly]
        public DocumentCountryDTO Country { get; set; }

        [HiddenFromClient]
        public int CountryId { get; set; }





        [ForClientOnly]
        public DocumentTypeDTO Type { get; set; }

        [HiddenFromClient]
        public int TypeId { get; set; }




        [ForClientOnly]
        public List<UploadedFileDTO> Images { get; set; } = new List<UploadedFileDTO>();

        [DTOFieldBindWith("Images", typeof(UploadedFile))]
        public List<string> ImagesIds { get; set; } = new List<string>();
    }
}
