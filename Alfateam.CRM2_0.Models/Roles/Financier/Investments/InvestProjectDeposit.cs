using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Investments
{
    /// <summary>
    /// Сущность взноса в наш инвест проект
    /// </summary>
    public class InvestProjectDeposit : AbsModel
    {
        public User Investor { get; set; }

        /// <summary>
        /// Движения по депозиту.
        /// Эти же транзакции находятся на едином счете инвест проекта
        /// </summary>
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();


        /// <summary>
        /// Договор с инвестором
        /// </summary>
        public Document Contract { get; set; }
    }
}
