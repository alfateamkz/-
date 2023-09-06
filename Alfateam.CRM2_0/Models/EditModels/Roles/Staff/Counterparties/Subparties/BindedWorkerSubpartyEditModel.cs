using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Staff.Counterparties.Subparties
{
    public class BindedWorkerSubpartyEditModel : EditModel<BindedWorkerSubparty>
    {
        public int WorkerId { get; set; }
    }
}
