using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Участник конфликта
    /// </summary>
    public class ConflictParticipant : AbsModel
    {
        public User User { get; set; }

        /// <summary>
        /// Может ли участник конфликта давать предложения и принимать решения от лица стороны конфликта
        /// Если в стороне конфликта только один человек, то по умолчанию равно true
        /// </summary>
        public bool IsLeader { get; set; } 

        /// <summary>
        /// Комментарий об участнике конфликта
        /// </summary>
        public string? Comment { get; set; }
        
    }
}
