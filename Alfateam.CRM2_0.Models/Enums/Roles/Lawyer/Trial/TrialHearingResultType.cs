using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial
{
    /// <summary>
    /// Тип результата судебного заседания
    /// </summary>
    public enum TrialHearingResultType
    {
        LawsuitApproved = 1, //Иск удолетворен
        LawsuitApprovedPartialy = 2, //Иск удолетворен частично
        LawsuitNotApproved = 3, //Иск не удолетворен
        ExtraHearing = 4, //Назначено дополнительное слушание
        Postponed = 5, //Слушание перенесено
    }
}
