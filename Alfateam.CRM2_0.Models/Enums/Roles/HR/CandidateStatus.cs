using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.HR
{
    /// <summary>
    /// Статус кандидата
    /// </summary>
    public enum CandidateStatus
    {
        Waiting = 1, //В ожидании собеседования
        Processing = 2, //Обработка кандидата
        Interview = 3, //Собеседование
        AdditionalInteview = 4, //Дополнительное собеседование
        ReInteview = 5, //Повторное собеседование
        WaitingForDecision = 6, //В ожидании решения
        Approved = 7, //Одобрен
        Rejected = 8, //Отклонен 
        RejectedForFuture = 9, //Отклонен, резерв на будущее
    }
}
