using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Staff.Counterparties.Subparties
{
    public class EmployeeSubpartyClientModel : CounterpartySubpartyClientModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public string Position { get; set; }
        public string Description { get; set; }
        public string? CVPath { get; set; }


        public CountryClientModel Country { get; set; }
    }
}
