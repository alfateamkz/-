using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Law
{
    /// <summary>
    /// Сущность услуги, оказание которой запрещено законодательством или внутренней политикой
    /// </summary>
    public class ProhibitedService : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public ProhibitedServiceType Type { get; set; } = ProhibitedServiceType.Legal;
    }
}
