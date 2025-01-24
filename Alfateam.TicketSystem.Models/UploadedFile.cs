using Alfateam.Core;
using Alfateam.TicketSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models
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
