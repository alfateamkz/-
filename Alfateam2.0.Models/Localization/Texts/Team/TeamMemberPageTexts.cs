using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Team
{
    public class TeamMemberPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Команда";



        public string ProjectZero { get; set; } = "Пока что без проектов";
        public string ProjectSingle { get; set; } = "1 проект";
        public string Project2_3_4 { get; set; } = "{count} проекта";
        public string ProjectPlural { get; set; } = "{count} проектов";



        public string AboutMember { get; set; } = "О СЕБЕ";
        public string MemberSkills { get; set; } = "НАВЫКИ";
        public string MemberPortfolio { get; set; } = "ПОРТФОЛИО";
    }
}
