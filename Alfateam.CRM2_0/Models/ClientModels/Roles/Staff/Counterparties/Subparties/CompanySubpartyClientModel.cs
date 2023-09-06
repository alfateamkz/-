using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Staff.Counterparties.Subparties
{
    public class CompanySubpartyClientModel : CounterpartySubpartyClientModel
    {
        public CompanyClientModel Company { get; set; }

        /// <summary>
        /// Субподрядчики/работники субподрядчика
        /// </summary>
        public List<CounterpartySubpartyClientModel> Subparties { get; set; } = new List<CounterpartySubpartyClientModel>();
    }
}
