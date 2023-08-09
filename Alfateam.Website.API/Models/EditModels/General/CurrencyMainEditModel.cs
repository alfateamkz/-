using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.EditModels.General
{
    public class CurrencyMainEditModel : EditModel<Currency>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }


        public bool IsHidden { get; set; }


        public int MainLanguageId { get; set; }
    }
}
