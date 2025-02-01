using Alfateam.EDM.Models.Documents.Types.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Types.Items
{
    public class DocumentPositionItemModifierDTO : DTOModelAbs<DocumentPositionItemModifier>
    {
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
