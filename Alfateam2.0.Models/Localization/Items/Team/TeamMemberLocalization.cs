using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Team
{
    public class TeamMemberLocalization : LocalizableModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }


        public string Position { get; set; }
        public string ShortExpierence { get; set; }
        public string Quote { get; set; }


        public Content DetailContent { get; set; }
        public string? CVFilepath { get; set; }
    }
}
