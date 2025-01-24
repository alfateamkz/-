using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.StaticTextsConstructor
{
    public class TextCategoryDTO : DTOModelAbs<TextCategory>
    {
        public string Title { get; set; }
        public string ProductIdentifier { get; set; }





        [ForClientOnly]
        public TextCategoryDTO? ParentCategory { get; set; }

        [HiddenFromClient]
        public int? ParentCategoryId { get; set; }
    }
}
