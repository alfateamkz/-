using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Staff.Employess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Команда внутри офиса/филиала
    /// Например: команда разработки сайтов или мобильных приложений
    /// </summary>
    public class WorkingTeam : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public Employee TeamLead { get; set; }
        public Employee? TechLead { get; set; }
        public List<Employee> Subordinates { get; set; } = new List<Employee>();
    }
}
