using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Staff;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Staff.Counterparties.Subparties
{
    public class EmployeeSubpartyEditModel : CounterpartySubpartyEditModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public string Position { get; set; }
        public string Description { get; set; }



        public int CountryId { get; set; }
    }
}
