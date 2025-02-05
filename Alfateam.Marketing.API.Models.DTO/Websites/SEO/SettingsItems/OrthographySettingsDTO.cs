using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.API.Models.DTO.General.SEO;
using Alfateam.Marketing.Models.General.SEO;
using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class OrthographySettingsDTO : DTOModelAbs<OrthographySettings>
    {
        public bool CheckOrthography { get; set; }

        [ForClientOnly]
        public List<LanguageDictionaryDTO> Dictionaries { get; set; } = new List<LanguageDictionaryDTO>();
        

        [DTOFieldBindWith(typeof(LanguageDictionary))]
        [HiddenFromClient]
        public List<int> DictionariesIds { get; set; } = new List<int>();


        public string WordsToIgnore { get; set; }
    }
}
