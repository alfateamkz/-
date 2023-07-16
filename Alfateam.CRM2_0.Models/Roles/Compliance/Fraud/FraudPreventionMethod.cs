using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Fraud
{
    /// <summary>
    /// Сущность описания способа противодействия мошенничеству
    /// </summary>
    public class FraudPreventionMethod : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
