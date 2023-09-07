﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;

namespace Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Accountance
{
    public class TransactionEditModel : EditModel<Transaction>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
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
