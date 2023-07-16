using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales
{
    /// <summary>
    /// Тип блока скрипта продаж
    /// </summary>
    public enum SalesScriptBlockType
    {
        Intro = 1, //Начало разговора
        Answer = 2, //Ответ на вопрос
        Question = 3, //Вопрос 
        Narrative = 4, //Рассказ о чем-либо
        Completion = 5, //Завершение разговора


        Other = 999 //Прочее
    }
}
