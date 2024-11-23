using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.Analytics.Sales.InWorkByManagers
{
    public class SalesInWorkByManagersItem
    {
        public User Manager { get; set; }
        public int InWorkOrdersCount { get; set; }
        public int WonOrdersCount { get; set; }
    }
}
