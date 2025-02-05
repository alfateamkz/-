using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.DTO.General;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.Blogs
{
    public class BlogLanguageZoneDTO : DTOModelAbs<BlogLanguageZone>
    {
        [ForClientOnly]
        public LanguageDTO Language { get; set; }

        [HiddenFromClient]
        public int LanguageId { get; set; }
    }
}
