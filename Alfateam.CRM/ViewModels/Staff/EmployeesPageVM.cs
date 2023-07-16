using Alfateam.Database.Enums.CRM.Staff;
using Alfateam.Database.Models.CRM;

namespace Alfateam.CRM.ViewModels.Sales {
    public class EmployeesPageVM {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public IEnumerable<Employee> StaffEmployees => Employees.Where(o => o.EmployeeType == EmployeeType.FullTime 
                                                                         || o.EmployeeType == EmployeeType.PartTime
                                                                         && o.Status != EmployeeStatus.Fired);
        public IEnumerable<Employee> OutstaffEmployees => Employees.Where(o => o.EmployeeType != EmployeeType.FullTime 
                                                                            && o.EmployeeType != EmployeeType.PartTime
                                                                            && o.Status != EmployeeStatus.Fired);

        public IEnumerable<Employee> FiredEmployees => Employees.Where(o => o.Status == EmployeeStatus.Fired);
    }
}
