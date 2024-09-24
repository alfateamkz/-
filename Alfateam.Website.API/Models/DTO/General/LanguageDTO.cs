using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class LanguageDTO : DTOModel<Language>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public bool IsRightToLeft { get; set; }


        public bool IsHidden { get; set; }
        public int MainLanguageId { get; set; }
    }
}
