using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Сущность всех сотрудников офиса
    /// </summary>
    public class OrganizationOfficeStaff : AbsModel
    {
        /// <summary>
        /// Все сотрудники офиса
        /// </summary>
        public List<Worker> Employees { get; set; } = new List<Worker>();

        /// <summary>
        /// Директор офиса/филиала
        /// Он же находится и списке сотрудников Employees
        /// Если не назначено отдельное лицо директором, 
        /// то директором офиса/филиала становится вышестоящий директор или владелец организации
        /// </summary>
        public Worker Head { get; set; }
        /// <summary>
        /// Команды внутри офиса
        /// </summary>
        public List<WorkingTeam> Teams { get; set; } = new List<WorkingTeam>();
    }
}
