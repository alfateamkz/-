using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.Enums.Roles.Financier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Planning
{
    /// <summary>
    /// Группа элементов финансового плана
    /// </summary>
    public class FinanicialPlanItemsGroup : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }


        /// <summary>
        /// Тип. Доходы или расходы
        /// </summary>
        public TransactionDirection Direction { get; set; } = TransactionDirection.Debit;
        /// <summary>
        /// Вид денежного потока
        /// </summary>
        public CashFlowType CashFlowType { get; set; } = CashFlowType.Operating;



        public List<FinanicialPlanItem> Items { get; set; } = new List<FinanicialPlanItem>();
    }
}
