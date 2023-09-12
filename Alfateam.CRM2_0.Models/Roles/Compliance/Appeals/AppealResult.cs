using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Appeals
{
    /// <summary>
    /// Результат решения по обращению в службу комплаенс
    /// </summary>
    public class AppealResult : AbsModel
    {
        public string Description { get; set; }
        public List<AppealResultAction> Actions { get; set; } = new List<AppealResultAction>();


        public bool IsLockedForEdit { get; set; }
    }
}
