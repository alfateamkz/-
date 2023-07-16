using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Appeals
{
    /// <summary>
    /// Сущность действия по обращению в службу комплаенс
    /// </summary>
    public class AppealAction : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
