using Alfateam.CRM2_0.Models.Roles.Staff.Employess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions
{
    /// <summary>
    /// Базовая сущность отдела
    /// </summary>
    public abstract class Department : AbsModel
    {
        /// <summary>
        /// Руководитель отдела. В разных отделах имеет разные названия, но суть одна
        /// Например: в бухгалтерии Head - главбух
        /// Если нет отдельного руководителя, то руководителем является директор организации/филиала
        /// </summary>
        public Employee Head { get; set; }
    }
}
