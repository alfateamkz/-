using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.Manuals
{
    /// <summary>
    /// Модель категории методички для HR
    /// </summary>
    public class HRManualCategory : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
