using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier
{
    /// <summary>
    /// Сущность фонда фирмы
    /// </summary>
    public class Foundation : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        /// <summary>
        /// Счета фонда. Все счета должны иметь Type = AccountType.FoundationAccount
        /// </summary>
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
