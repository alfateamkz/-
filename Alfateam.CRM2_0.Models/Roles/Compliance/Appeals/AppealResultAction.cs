using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Appeals
{
    /// <summary>
    /// Сущность действия по результату обращения в службу комплаенс
    /// </summary>
    public class AppealResultAction : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public DateTime Deadline { get; set; }
        public DateTime? PerformedAt { get; set; }
        public AppealResultActionStatus Status { get; set; } = AppealResultActionStatus.NotPerformed;



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int AppealResultId { get; set; }
    }
}
