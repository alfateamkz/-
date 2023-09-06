using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Staff;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Staff.Counterparties.Subparties
{
    public class BindedWorkerSubpartyClientModel : CounterpartySubpartyClientModel
    {
        public WorkerClientModel Worker { get; set; }
    }
}
