using Alfateam.Core.Attributes.DTO;
using Alfateam.SharedModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.Abstractions
{
    public class BlogPostBlockWithFileDTO : BlogPostBlockDTO
    {
        [ForClientOnly]
        public UploadedFileDTO File { get; set; }

        [HiddenFromClient]
        public string FileId { get; set; }
    }
}
