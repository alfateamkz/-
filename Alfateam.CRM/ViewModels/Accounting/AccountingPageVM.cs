using Alfateam.Database.Enums.CRM.Accounting;
using Alfateam.Database.Models.CRM.Accounting;

namespace Alfateam.CRM.ViewModels.Accounting {
    public class AccountingPageVM {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public List<AccountingItem> Items { get; set; } = new List<AccountingItem>();


        public double IncomesSum => Items.Where(o => o.Direction == AccountingItemDirection.Income).Sum(o => o.Sum);
        public double ExpensesSum => Items.Where(o => o.Direction == AccountingItemDirection.Expense).Sum(o => o.Sum);
        public double Turnover => IncomesSum + ExpensesSum;
        public double Profit => IncomesSum - ExpensesSum;
    }
}
