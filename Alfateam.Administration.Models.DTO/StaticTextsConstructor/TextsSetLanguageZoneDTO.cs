using Alfateam.Administration.Models.DTO.General;
using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.StaticTextsConstructor
{
    public class TextsSetLanguageZoneDTO : DTOModelAbs<TextsSetLanguageZone>
    {
        [ForClientOnly]
        public LanguageDTO Language { get; set; }

        [HiddenFromClient]
        public int LanguageId { get; set; }

    }
}
