using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models
{
    public class UploadedFile : AbsModelGuid
    {
        public string? Server { get; set; }
        public string RelativePath { get; set; }



        public int? RelatedEntityId { get; set; }
        public UploadedFileRelatedEntity? RelatedEntityType { get; set; }


        [NotMapped]
        public bool IsUsed => RelatedEntityId != null;

    }
}
