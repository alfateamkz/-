using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.General.SEO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.General.SEO
{
    public class LanguageDictionaryDTO : DTOModelAbs<LanguageDictionary>
    {
        public string Title { get; set; }
        public string LanguageCode { get; set; }

        [ForClientOnly]
        public string DictionaryPath { get; set; }
    }
}
