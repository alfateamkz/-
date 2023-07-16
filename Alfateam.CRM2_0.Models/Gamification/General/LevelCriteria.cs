using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.General
{
    /// <summary>
    /// Критерий для перехода на уровень
    /// </summary>
    public class LevelCriteria : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
