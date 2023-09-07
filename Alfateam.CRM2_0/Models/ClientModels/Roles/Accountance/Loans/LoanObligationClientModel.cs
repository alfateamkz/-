using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance.Loans
{
    public class LoanObligationClientModel : ClientModel<LoanObligation>
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public LoanObligationType Type { get; set; } = LoanObligationType.Loan;
        public LoadObligationDirection Direction { get; set; } = LoadObligationDirection.Debit;




        public CurrencyClientModel Currency { get; set; }

        public double Sum { get; set; }
        public double Percent { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        /// <summary>
        /// Информация о штрафах в случае просрочки
        /// Если Penalty == null, то штрафы не применяются по обязательству
        /// </summary>
        public PenaltyClientModel? Penalty { get; set; }
    }
}
