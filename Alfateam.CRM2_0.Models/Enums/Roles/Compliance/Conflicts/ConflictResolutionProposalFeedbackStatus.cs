using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Тип ответа на предложение по урегулированию конфликта
    /// </summary>
    public enum ConflictResolutionProposalFeedbackStatus
    {
        Approved = 1, //Получено одобрение
        Revise = 2, //Нужно дополнительное обсуждение предложения
        Rejected = 3, //Предложение отклонено
    }
}
