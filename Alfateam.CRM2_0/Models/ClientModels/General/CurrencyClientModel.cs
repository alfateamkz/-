using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class CurrencyClientModel : ClientModel<Currency>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public CurrencyType Type { get; set; } = CurrencyType.Fiat;
    }
}
