using Alfateam.Administration.Models.DTO.Abstractions;
using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.StaticTextsConstructor
{
    public class StaticTextsModelDTO : DTOModelAbs<StaticTextsModel>
    {
        public string ClassName { get; set; }
        public string Title { get; set; }
        public List<AbsFieldDTO> Fields { get; set; } = new List<AbsFieldDTO>();
    }
}
