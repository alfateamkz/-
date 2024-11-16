using Alfateam.Sales.API.Models.ByEmployees;
using Alfateam.Sales.API.Models.DatePeriod;
using Alfateam.Sales.Models.General;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ByEmployeesFilter>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DepartmentsByEmployeesFilter), "DepartmentsByEmployeesFilter")]
    [JsonKnownType(typeof(UsersByEmployeesFilter), "UsersByEmployeesFilter")]
    public abstract class ByEmployeesFilter
    {
        public abstract IEnumerable<User> GetEmployees(IEnumerable<User> allCompanyUsers);
    }
}
