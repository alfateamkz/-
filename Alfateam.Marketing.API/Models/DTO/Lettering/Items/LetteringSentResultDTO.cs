using Alfateam.Marketing.API.Models.DTO.General;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Lettering.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Lettering.Items
{
    public class LetteringSentResultDTO : DTOModelAbs<LetteringSentResult>
    {
        public ContactInfoDTO Contact { get; set; }



        public LetteringSentResultType ResultType { get; set; }
        public string? ResultText { get; set; }
    }
}
