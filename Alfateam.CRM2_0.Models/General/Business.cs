using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель самого бизнеса. 
    /// Он может принадлежать нам или партнеру ("франшиза" или сотрудничество)
    /// В нее входят организации, филиалы и т.д.
    /// </summary>
    public class Business : AbsModel
    {

        public string Title { get; set; }
        public string? LogoPath { get; set; }


        [NotMapped]
        public IEnumerable<User> Owners => Users.Where(o => o.RoleModel.IsPresident || o.RoleModel.IsPartnerOrganigationDirector);
        [NotMapped]
        public IEnumerable<User> TopManagers => Users.Where(o => o.RoleModel.IsTopManager || o.RoleModel.IsPartnerOrganigationTopManager);
        [NotMapped]
        public IEnumerable<User> Staff => Users.Where(o => o.RoleModel.IsStaff);


        /// <summary>
        /// Все пользователи всех мастей, которые хоть как-то связаны с этим бизнесом
        /// </summary>
        public List<User> Users { get; set; } = new List<User>();


        public BusinessType Type { get; set; } = BusinessType.Our;
        public List<Organization> Organizations { get; set; } = new List<Organization>();


        public BusinessContent Content { get; set; }
        public int ContentId { get; set; }
    }
}
