using Alfateam.CRM2_0.Models.Abstractions;
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
        public List<Organization> Organizations { get; set; } = new List<Organization>();
    }
}
