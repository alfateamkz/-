using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Статус предложения по урегулированию конфликта
    /// </summary>
    public enum ConflictResolutionProposalStatus
    {
        Discussion = 1, //Обсуждение предложения
        Approved = 2, //Получено одобрение
        Revise = 3, //Нужно дополнительное обсуждение предложения
        Rejected = 4, //Предложение отклонено
    }
}
