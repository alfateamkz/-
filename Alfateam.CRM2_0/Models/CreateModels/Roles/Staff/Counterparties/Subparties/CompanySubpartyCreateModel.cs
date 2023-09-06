using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Staff.Counterparties.Subparties
{
    public class CompanySubpartyCreateModel : CounterpartySubpartyCreateModel
    {
        public int CompanyId { get; set; }

        /// <summary>
        /// Субподрядчики/работники субподрядчика
        /// </summary>
        public List<CounterpartySubpartyCreateModel> Subparties { get; set; } = new List<CounterpartySubpartyCreateModel>();


        public override bool IsValid()
        {
            bool isValid = base.IsValid();
         
            foreach (var subparty in Subparties)
            {
                isValid &= subparty.IsValid();  
            }

            return isValid;
        }

        public override CounterpartySubparty Create()
        {
            var item = base.Create() as CompanySubparty;

            foreach(var subparty in Subparties)
            {
                item.Subparties.Add(subparty.Create());
            }

            return item;
        }
    }
}
