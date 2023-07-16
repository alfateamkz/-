using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Loans
{
    /// <summary>
    /// Модель заемного обязательства
    /// </summary>
    public class LoanObligation : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public LoanObligationType Type { get; set; } = LoanObligationType.Loan;
        public LoadObligationDirection Direction { get; set; } = LoadObligationDirection.Debit;




        public Currency Currency { get; set; }
        public double Sum { get; set; }
        public double Percent { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        /// <summary>
        /// Информация о штрафах в случае просрочки
        /// Если Penalty == null, то штрафы не применяются по обязательству
        /// </summary>
        public Penalty? Penalty { get; set; }

        /// <summary>
        /// Залоги долгового обязательства. 
        /// Если список пустой - то обязательство беззалоговое
        /// </summary>
        public List<LoanObligationPledge> Pledges { get; set; } = new List<LoanObligationPledge>();
    }
}
