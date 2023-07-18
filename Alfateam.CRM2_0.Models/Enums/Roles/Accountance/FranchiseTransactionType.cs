using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Accountance
{
    /// <summary>
    /// Тип транзакции с привязкой к франшизе
    /// </summary>
    public enum FranchiseTransactionType
    {
        EntryFee = 1, //Стартовый взнос
        Royalty = 2, //Роялти


        Other = 999 //Иной тип транзакции
    }
}
