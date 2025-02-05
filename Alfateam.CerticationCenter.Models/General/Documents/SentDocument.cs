using Alfateam.Core;
using Alfateam.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General.Documents
{
    public class SentDocument : AbsModel
    {
        public DocumentCountry Country { get; set; }
        public int CountryId { get; set; }



        public DocumentType Type { get; set; }
        public int TypeId { get; set; }

        public List<UploadedFile> Images { get; set; } = new List<UploadedFile>();
    }
}
