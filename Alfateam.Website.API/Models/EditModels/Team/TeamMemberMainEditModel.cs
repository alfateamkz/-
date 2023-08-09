using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.EditModels.Team
{
    public class TeamMemberMainEditModel : EditModel<TeamMember>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImgPath { get; set; }


        public string Position { get; set; }
        public string ShortExpierence { get; set; }
        public string Quote { get; set; }


        public Content DetailContent { get; set; }
        public string? CVFilepath { get; set; }



        public int MainLanguageId { get; set; }
    }
}
