using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Scripting;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.Scripting
{
    public class SalesScriptBlockDTO : DTOModelAbs<SalesScriptBlock>
    {

        [Description("Текст фразы")]
        public string Text { get; set; }
        public string BGHexColor { get; set; }
        public string TextHexColor { get; set; }


        [Description("Тип блока")]
        public SalesScriptBlockType Type { get; set; } = SalesScriptBlockType.Intro;


        [ForClientOnly]
        [Description("Разветвления скрипта")]
        public List<SalesScriptBlockDTO> Nodes { get; set; } = new List<SalesScriptBlockDTO>();
    }
}
