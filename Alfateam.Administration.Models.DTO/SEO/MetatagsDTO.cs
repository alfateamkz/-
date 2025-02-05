using Alfateam.Administration.Models.SEO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.SEO
{
    public class MetatagsDTO : DTOModelAbs<Metatags>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Keywords { get; set; }




        public string? Robots { get; set; }
        public string? Refresh { get; set; }
        public string? Author { get; set; }
        public string? Copyright { get; set; }
        public string? Address { get; set; }
    }
}
