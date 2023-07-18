using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff.Counterparties
{
    /// <summary>
    /// Вид сотрудничества с контрагентом
    /// </summary>
    public enum CounterpartyCooperationType
    {
        ByProject = 1, //Попроектно
        Hourly = 2, //Почасовка


        Other = 999 //Иная форма сотрудничества
    }
}
