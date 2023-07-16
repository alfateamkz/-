using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Content.Tests
{
    /// <summary>
    /// Условие, при котором можно можно использовать результат теста
    /// </summary>
    public enum TestResultConditionType
    {
        Equal = 1, //Равно
        Between = 2, //Между
        From = 3, //От
        To = 4, //До
        NoCondition = 5 //Без условия(если все другие результаты не отработали)
    }
}


