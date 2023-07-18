using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
    /// <summary>
    /// Сущность заявления в суд
    /// </summary>
    public class TrialRequest : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TrialRequestType Type { get; set; } = TrialRequestType.Lawsuit;
        public TrialRequestStatus Status { get; set; } = TrialRequestStatus.Preparing;



        public CourtStructure CourtStructure { get; set; }



        /// <summary>
        /// Сам исковой документ
        /// </summary>
        public Document Document { get; set; }

        public TrialRequestResult? Result { get; set; }
    }
}
