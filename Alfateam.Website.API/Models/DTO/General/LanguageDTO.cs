using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class LanguageDTO : DTOModel<Language>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public bool IsRightToLeft { get; set; }


        [HiddenFromClient]
        public bool IsHidden { get; set; }

        [HiddenFromClient]
        public int MainLanguageId { get; set; }
    }
}
