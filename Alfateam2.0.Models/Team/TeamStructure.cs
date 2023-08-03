using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Team
{
    /// <summary>
    /// Структура всех сотрудников 
    /// </summary>
    public class TeamStructure : AvailabilityModel
    {
        public List<TeamGroup> Groups { get; set; } = new List<TeamGroup>();
    }
}
