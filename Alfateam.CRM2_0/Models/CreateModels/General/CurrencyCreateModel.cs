using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class CurrencyCreateModel : CreateModel<Currency>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public CurrencyType Type { get; set; } = CurrencyType.Fiat;
    }
}
