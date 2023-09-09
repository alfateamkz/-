using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer
{
    /// <summary>
    /// Тип судебного разбирательства
    /// </summary>
    public enum LitigationType
    {
        Administrative = 1, //Административное
        Arbitration = 2, //Арбитражное
        Civil = 3, //Гражданское
        Constitutional = 4, //Конституционное
        Criminal = 5, //Уголовное
    }
}
