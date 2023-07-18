using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Владельцы бизнеса
        /// </summary>
        public List<User> Owners { get; set; } = new List<User>();
        public BusinessType Type { get; set; } = BusinessType.Our;
        public List<Organization> Organizations { get; set; } = new List<Organization>();
    }
}
