using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Investments
{
    /// <summary>
    /// Сущность условия досрочного снятия
    /// </summary>
    public class InvestmentEarlyWithdrawalCondition : AbsModel
    {  
        /// <summary>
        /// Доступно ли досрочное снятие
        /// </summary>
        public bool IsEarlyWithdrawalAllowed { get; set; }

        /// <summary>
        /// Процент потери гонорара при досрочном снятии от 0 до 100
        /// 0 - проценты не теряются
        /// 100 - теряются все проценты
        /// </summary>
        public bool LostInterestPercent { get; set; }
    }
}
