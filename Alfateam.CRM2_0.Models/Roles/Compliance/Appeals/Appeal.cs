using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Appeals
{

    /// <summary>
    /// Сущность обращения в службу комплаенс
    /// </summary>
    public class Appeal : AbsModel
    {
        public AppealSource Source { get; set; } = AppealSource.Public;

        /// <summary>
        /// От кого поступило обращение
        /// Если From == null, то обращение анонимное
        /// </summary>
        public User? From { get; set; }
        public int? FromId { get; set; }


        /// <summary>
        /// Токен, чтобы тот, кто обратился мог видеть движение по обращению
        /// </summary>
        public string PublicAccessToken { get; set; } = Guid.NewGuid().ToString();


        public AppealStatus Status { get; set; } = AppealStatus.Waiting;
        public string? StatusComment { get; set; }
        public List<AppealAction> Actions { get; set; } = new List<AppealAction>();


        public AppealResult? Result { get; set; }
        public int? ResultId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ComplianceDepartmentId { get; set; }


	}
}
