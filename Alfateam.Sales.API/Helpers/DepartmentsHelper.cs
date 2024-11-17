using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Helpers
{
    public static class DepartmentsHelper
    {
        public static void HideSoftDeletedDepartments(List<Department> departments)
        {
            for (int i = departments.Count - 1; i >= 0; i--)
            {
                var department = departments[i];
                if (department.IsDeleted)
                {
                    departments.Remove(department);
                    continue;
                }

                HideSoftDeletedDepartments(department);
            }


        }
        public static void HideSoftDeletedDepartments(Department root)
        {
            for (int i = root.SubDepartments.Count - 1; i >= 0; i--)
            {
                var subDepartment = root.SubDepartments[i];
                if (subDepartment.IsDeleted)
                {
                    root.SubDepartments.Remove(subDepartment);
                }
            }

            foreach (var subDepartment in root.SubDepartments)
            {
                HideSoftDeletedDepartments(subDepartment);
            }
        }


        public static List<Department> GetThisAndAllSubDepartments(Department department, bool isRoot)
        {
            List<Department> departments = new List<Department>();

            if (isRoot)
            {
                departments.Add(department);
            }

            foreach (var subDepartment in department.SubDepartments)
            {
                departments.Add(subDepartment);
                departments.AddRange(GetThisAndAllSubDepartments(subDepartment, false));
            }

            return departments;
        }
    }
}
