using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions
{

    /// <summary>
    /// Базовая модель бухгалтерской транзакции
    /// </summary>
    public abstract class Transaction : AbsModel
    {






        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Currency Currency { get; set; }
        public double Value { get; set; }

        public TransactionDirection Direction { get; set; } = TransactionDirection.Debit;

        public string? Comment { get; set; }


        /// <summary>
        /// Если true - учитывается в налоговом расчете
        /// </summary>
        public bool IsOfficial { get; set; }



        /// <summary>
        /// Ожидаемая транзакция
        /// </summary>
        public bool IsPlanned { get; set; }
        public DateTime? PlannedDate { get; set; }

    }
}
