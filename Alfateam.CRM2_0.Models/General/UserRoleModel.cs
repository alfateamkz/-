using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Attributes;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Сущность модели ролей пользователя
    /// </summary>
    public class UserRoleModel : AbsModel
    {
        public List<UserGivenRole> GivenRoles { get; set; } = new List<UserGivenRole>();

        [NotMapped]
        public bool IsPresident => HasRole(UserRole.President);
        [NotMapped]
        public bool IsTopManager => HasRole(UserRole.TopManager);
        [NotMapped]
        public bool IsPartnerOrganigationDirector => HasRole(UserRole.PartnerOrganigationDirector);
        [NotMapped]
        public bool IsPartnerOrganigationTopManager => HasRole(UserRole.PartnerOrganigationTopManager);


        [NotMapped]
        public bool IsStaff
        {
            get
            {
                bool isStaff = false;

                isStaff |= HasRole(UserRole.BranchDirector);
                isStaff |= HasRole(UserRole.Financian);
                isStaff |= HasRole(UserRole.ProjectManager);
                isStaff |= HasRole(UserRole.Lawyer);
                isStaff |= HasRole(UserRole.TechLead);
                isStaff |= HasRole(UserRole.TeamLead);
                isStaff |= HasRole(UserRole.Employee);
                isStaff |= HasRole(UserRole.Sales);
                isStaff |= HasRole(UserRole.Marketing);
                isStaff |= HasRole(UserRole.HR);
                isStaff |= HasRole(UserRole.Compliance);
                isStaff |= HasRole(UserRole.SecurityService);
                isStaff |= HasRole(UserRole.ContentMaker);
                isStaff |= HasRole(UserRole.ContentMaker);

                return isStaff;
            }
        }

        [NotMapped]
        public bool IsJustRelatedToCompany
        {
            get
            {
                bool isRelated = false;

                isRelated |= HasRole(UserRole.Partner);
                isRelated |= HasRole(UserRole.Customer);
                isRelated |= HasRole(UserRole.Candidate);
                isRelated |= HasRole(UserRole.Investor);

                return isRelated;
            }
        }



        public int GetHighestRolePriority()
        {
            return GivenRoles.Max(o => GetRolePriority(o.Role));
        }

        public static int GetRolePriority(UserRole role)
        {
            var attribute = role.GetType().GetCustomAttribute(typeof(RolePriorityAttribute)) as RolePriorityAttribute;
            return attribute.Priority;
        }


        public bool HasRole(IEnumerable<UserRole> roles)
        {
            return GivenRoles.Select(o => o.Role).Intersect(roles).Any();
        }
        public bool HasRole(UserRole role)
        {
            return GivenRoles.Any(o => o.Role == role);
        }
        public bool AddRole(UserRole role)
        {
            if(HasRole(role)) return false;

            GivenRoles.Add(new UserGivenRole
            {
                Role = role
            });
            return true;
        }
    }
}
