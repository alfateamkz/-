using Alfateam.Administration.Models.DTO.General;
using Alfateam.Administration.Models.General;
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
    public class TextsSetDTO : DTOModelAbs<TextsSet>
    {
        public string Title { get; set; }
        public string UniqueIdentifier { get; set; }


        [ForClientOnly]
        public ProductDTO Product { get; set; }

        [HiddenFromClient]
        public int ProductId { get; set; }
    }
}
