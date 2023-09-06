using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Staff.Counterparties.Subparties
{
    public class BindedWorkerSubpartyCreateModel : CounterpartySubpartyCreateModel
    {
        public int WorkerId { get; set; }
    }
}
