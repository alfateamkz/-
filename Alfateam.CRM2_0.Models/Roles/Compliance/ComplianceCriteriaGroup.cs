using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance
{
    /// <summary>
    /// Сущность группы критерий соответствия
    /// </summary>
    public class ComplianceCriteriaGroup : AbsModel
    {
        public List<ComplianceCriteria> Criterias { get; set; } = new List<ComplianceCriteria>();   
    }
}
