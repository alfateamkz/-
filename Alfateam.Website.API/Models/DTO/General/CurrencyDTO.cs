using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class CurrencyDTO : DTOModel<Currency>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }



        public bool IsHidden { get; set; }
        public int MainLanguageId { get; set; }
    }
}
