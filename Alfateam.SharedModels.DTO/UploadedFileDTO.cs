using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO
{
    public class UploadedFileDTO : DTOModelAbsGuid<UploadedFile>
    {
        [ForClientOnly]
        public string? Server { get; set; }

        [ForClientOnly]
        public string RelativePath { get; set; }

        [ForClientOnly]
        public string FullPath => Server + RelativePath;
    }
}
