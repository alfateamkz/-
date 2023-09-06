using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Staff;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Staff.Counterparties.Subparties
{
    public class EmployeeSubpartyCreateModel : CounterpartySubpartyCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public string Position { get; set; }
        public string Description { get; set; }



        public int CountryId { get; set; }
    }
}
