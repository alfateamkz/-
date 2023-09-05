using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.General;
using Alfateam.DB.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Methods.CRMDBContext
{
    public class DepartmentsMethods : DBMethods
    {
        public DepartmentsMethods(DB.CRMDBContext db) : base(db)
        {
        }


        public bool HasAccessToDepartment(User user, int departmentId)
        {
            Department department = DB.Departments.Include(o => o.Employees)
                                                  .FirstOrDefault(o => o.Id ==  departmentId);
            if (user.RoleModel.IsPresident || user.RoleModel.IsTopManager)
            {
                return true;
            }
            else if (user.RoleModel.IsPartnerOrganigationDirector || user.RoleModel.IsPartnerOrganigationTopManager)
            {
                return user.BusinessId == GetDepartmentBusinessId(department);
            }
            return HasAccessToThisDepartment(user, department);
        }
        public Department? GetUserDepartment<T>(int userId) where T : Department
        {
            return DB.Departments.Include(o => o.Employees)
                                 .FirstOrDefault(o => o is T &&
                                                 o.Employees.Any(o => o.Id == userId));
        }




        #region Private methods for HasAccessToDepartment(User user, int departmentId)
        private int GetDepartmentBusinessId(Department department)
        {
            var departmentsGrouping = DB.DepartmentsGroupings.FirstOrDefault(o => o.Id == department.DepartmentsGroupingId);

            if (departmentsGrouping.OrganizationId != null)
            {
                var organization = DB.Organizations.FirstOrDefault(o => o.Id == departmentsGrouping.OrganizationId);
                return organization.BusinessId;
            }
            else if (departmentsGrouping.OrganizationOfficeId != null)
            {
                var office = DB.OrganizationOffices.FirstOrDefault(o => o.Id == departmentsGrouping.OrganizationOfficeId);
                return office.BusinessId;
            }
            throw new NotImplementedException();
        }
        private bool HasAccessToThisDepartment(User user, Department department)
        {
            if (department.Employees.Any(o => o.Id == user.Id))
            {
                return true;
            }

            //Поднимаемся выше, т.к. пользователь может быть в более главном офисе или быть в департаменте самой организации, а не офиса
            var higherDepartment = GetHigherDepartment(department);
            if(higherDepartment != null)
            {
                return HasAccessToThisDepartment(user, higherDepartment);
            }

            return false;
        }
       
        
        
        private Department? GetHigherDepartment(Department department)
        {
            var departmentsGrouping = DB.DepartmentsGroupings.FirstOrDefault(o => o.Id == department.DepartmentsGroupingId);

            //Возвращаем null, т.к. выше самой организации нет департаментов
            if(departmentsGrouping.OrganizationId != null)
            {
                return null;
            }
            else
            {
                IIncludableQueryable<OrganizationOffice,Department> includes;
                switch (department)
                {
                    case AccountanceDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.Accountance);
                        break;
                    case ComplianceDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.Compliance);
                        break;
                    case FinanceDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.Finance);
                        break;
                    case HRDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.HR);
                        break;
                    case LawDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.Law);
                        break;
                    case MarketingDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.Marketing);
                        break;
                    case SalesDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.Sales);
                        break;
                    case SecurityServiceDepartment:
                        includes = DB.OrganizationOffices.Include(o => o.Departments).ThenInclude(o => o.SecurityService);
                        break;
                    default:
                        throw new NotImplementedException("Check DepartmentsGrouping entity for new departments");
                }

                var office = includes.FirstOrDefault(o => o.Id == departmentsGrouping.OrganizationOfficeId);
           
                var higherDepartment = office.Departments.GetDepartment(department.GetType());
                if(higherDepartment != null)
                {
                    return higherDepartment;
                }
                else
                {
                    return SearchHigherDepartmentRecursively(includes,department.GetType(),office.Id);
                }

            }
        }
        private Department? SearchHigherDepartmentRecursively(IIncludableQueryable<OrganizationOffice, Department> includes, Type departmentType, int officeId)
        {
            var office = includes.FirstOrDefault(o => o.Id == officeId);

            var higherDepartment = office.Departments.GetDepartment(departmentType);
            if (higherDepartment != null)
            {
                return higherDepartment;
            }
            else
            {
                //Идем ввех по офисам, иначе - смотрим в организации
                if(office.OrganizationOfficeId != null)
                {
                    return SearchHigherDepartmentRecursively(includes, departmentType, (int)office.OrganizationOfficeId);
                }
                else
                {
                    IIncludableQueryable<Organization, Department> organizationIncludes;

                    if(departmentType == typeof(AccountanceDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.Accountance);
                    }
                    else if (departmentType == typeof(ComplianceDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.Compliance);
                    }
                    else if (departmentType == typeof(FinanceDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.Finance);
                    }
                    else if (departmentType == typeof(HRDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.HR);
                    }
                    else if (departmentType == typeof(LawDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.Law);
                    }
                    else if (departmentType == typeof(MarketingDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.Marketing);
                    }
                    else if (departmentType == typeof(SalesDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.Sales);
                    }
                    else if (departmentType == typeof(SecurityServiceDepartment))
                    {
                        organizationIncludes = DB.Organizations.Include(o => o.Departments).ThenInclude(o => o.SecurityService);
                    }
                    else
                    {
                        throw new NotImplementedException("Check DepartmentsGrouping entity for new departments");
                    }

                    var organization = organizationIncludes.FirstOrDefault(o => o.Id == office.OrganizationId);
                    return organization.Departments.GetDepartment(departmentType);
                }            
            }
        }
      
        #endregion
    }
}
