using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.General;
using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Accountance.Loans
{
    public class LoanObligationEditModel : EditModel<LoanObligation>
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public LoanObligationType Type { get; set; } = LoanObligationType.Loan;
        public LoadObligationDirection Direction { get; set; } = LoadObligationDirection.Debit;


        public int CurrencyId { get; set; }

        public double Sum { get; set; }
        public double Percent { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        /// <summary>
        /// Информация о штрафах в случае просрочки
        /// Если Penalty == null, то штрафы не применяются по обязательству
        /// </summary>
        public PenaltyEditModel? Penalty { get; set; }

        public override void Fill(LoanObligation item)
        {
            base.Fill(item);
            Penalty.Fill(item.Penalty);
        }
    }
}
