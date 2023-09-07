using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans.Pledges;
using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.InvestProject;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions
{




    [JsonConverter(typeof(JsonKnownTypesConverter<Transaction>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(AdmissionInvestProjectTransaction), "AdmissionInvestProjectTransaction")]
    [JsonKnownType(typeof(DividendInvestProjectTransaction), "DividendInvestProjectTransaction")]

    [JsonKnownType(typeof(FranchiseTransaction), "FranchiseTransaction")]
    [JsonKnownType(typeof(MarketingTransaction), "MarketingTransaction")]
    [JsonKnownType(typeof(OrderTransaction), "OrderTransaction")]
    [JsonKnownType(typeof(SimpleTransaction), "SimpleTransaction")]
    [JsonKnownType(typeof(WorkerTransaction), "WorkerTransaction")]
    /// <summary>
    /// Базовая модель бухгалтерской транзакции
    /// </summary>
    public class Transaction : AbsModel
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


        /// <summary>
        /// История изменений свойств транзакции
        /// </summary>
        [JsonIgnore]
        public List<TransactionChanges> OldTransactionVersions { get; set; } = new List<TransactionChanges>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        [JsonIgnore]
        public int AccountId { get; set; }



        public void SaveOldChanges()
        {
            OldTransactionVersions.Add(new TransactionChanges
            {
                Comment = this.Comment,
                Date = this.Date,
                Direction = this.Direction,
                PlannedDate = this.PlannedDate,
                IsOfficial = this.IsOfficial,
                IsPlanned = this.IsPlanned,
                Value = this.Value,
                Title = this.Title,
            });
        }
    }
}
