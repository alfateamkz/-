using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption
{
    /// <summary>
    /// Сущность подробностей, как появлися коррупционный инцидент
    /// </summary>
    public class CorruptionCaseInitDetails : AbsModel
    {
        /// <summary>
        /// Человек, который подал заявление о взятке (в случае, если одна из сторон заявила о взятке)
        /// Или проверяющий (в случае если коррупционный инцидент был обнаружен при проверке)
        /// </summary>
        public User Applicant { get; set; }


        /// <summary>
        /// Сотрудник, который внес в базу коррупционный инцидент
        /// </summary>
        public User CreatedBy { get; set; }
    }
}
