using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Items.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Team
{
    /// <summary>
    /// Структура отдельно взятой команды
    /// </summary>
    public class TeamGroup : AbsModel
    {
        public string Title { get; set; }
        public List<TeamMember> Members { get; set; } = new List<TeamMember>();


        public List<TeamGroupLocalization> Localizations { get; set; } = new List<TeamGroupLocalization>();
    }
}
