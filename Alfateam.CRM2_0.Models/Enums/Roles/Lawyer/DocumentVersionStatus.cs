using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer
{

    /// <summary>
    /// Статус версии документа
    /// </summary>
    public enum DocumentVersionStatus
    {
        FinalVersion = 1, //Финальная версия документа
        ApprovedVersion = 2, //Одобрен обоими сторонами
        ApprovedByAlfateam = 3, //Одобрен юристом Alfateam
        ApprovedBySecondSide = 4, //Одобрен клиентом
        RejectedByAlfateam = 5, //Отклонен юристом Alfateam
        RejectedBySecondSide = 6, //Отклонен клиентом
        Rejected = 7, //Отклонен обоими сторонами
        Revision = 8, //На доработке
        Review = 9, //Рассмотрение документа
    }
}
