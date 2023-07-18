using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties
{
    /// <summary>
    /// Информация о работнике контрагента, который учавствует в разработке проектов 
    /// </summary>
    public class EmployeeSubparty : CounterpartySubparty
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public string Position { get; set; }
        public string Description { get; set; }
        public string? CVPath { get; set; }


        public Country Country { get; set; }
    }
}
