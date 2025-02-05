using Alfateam.Administration.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.General
{
    public class LanguageDTO : DTOModelAbs<Language>
    {
        public string Title { get; set; }
        public string Code { get; set; }
    }
}
