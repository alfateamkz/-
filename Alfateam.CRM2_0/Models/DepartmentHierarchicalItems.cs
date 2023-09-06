using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models
{
    public class DepartmentHierarchicalItems<T> where T : AbsModel
    {
        public HierarchicalItemsInOrganization<T> ItemsInOrganization { get; set; }
        public List<HierarchicalItemsInOffice<T>> ItemsInOffices { get; set; } = new List<HierarchicalItemsInOffice<T>>();
    }

    public class HierarchicalItemsInOrganization<T> where T : AbsModel
    {
        public Organization Organization { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }

    public class HierarchicalItemsInOffice<T> where T : AbsModel
    {
        public OrganizationOffice Office { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
