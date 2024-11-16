using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.ByEmployees
{
    public class UsersByEmployeesFilter : ByEmployeesFilter
    {
        public bool Excluding { get; set; }
        public List<int> UserIds { get; set; } = new List<int>();


        public override IEnumerable<User> GetEmployees(IEnumerable<User> allCompanyUsers)
        {
            if (Excluding)
            {
                return allCompanyUsers.Where(o => !UserIds.Any(i => i == o.Id));
            }
            return allCompanyUsers.Where(o => UserIds.Any(i => i == o.Id));
        }
    }
}
