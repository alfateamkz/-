using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.API.Models.DTO.Contacts;
using Alfateam.Telephony.Models.Contacts;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.HLR.Numbers;

namespace Alfateam.Telephony.API.Models.DTO.HLR.Numbers.Types
{
    public class HLRNumbersToCheckCategoriesDTO : HLRNumbersToCheckDTO
    {
        [ForClientOnly]
        public List<ContactCategoryDTO> Categories { get; set; } = new List<ContactCategoryDTO>();

        [HiddenFromClient, DTOFieldBindWith("Categories", typeof(ContactCategory))]
        public List<int> CategoriesIds { get; set; } = new List<int>();


        public List<HLRNumberToCheck> IgnoreNumbers { get; set; } = new List<HLRNumberToCheck>();


    }
}
