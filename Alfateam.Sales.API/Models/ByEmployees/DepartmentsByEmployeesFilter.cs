using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.ByEmployees
{
    public class DepartmentsByEmployeesFilter : ByEmployeesFilter
    {
        public bool Excluding { get; set; }
        public List<int> DepartmentsIds { get; set; } = new List<int>();


        public override IEnumerable<User> GetEmployees(IEnumerable<User> allCompanyUsers)
        {
            if (Excluding)
            {
                return allCompanyUsers.Where(o => !DepartmentsIds.Any(i => i == o.DepartmentId));
            }
            return allCompanyUsers.Where(o => DepartmentsIds.Any(i => i == o.DepartmentId));
        }
    }
}
