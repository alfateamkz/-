using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.DTO.Team
{
    public class TeamMemberDTO : DTOModel<TeamMember>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImgPath { get; set; }


        public string Position { get; set; }
        public string ShortExpierence { get; set; }
        public string Quote { get; set; }


        public string Slug => SlugHelper.GetLatynSlug($"{Surname} {Name} - {Position}");


        public Content DetailContent { get; set; }
        public string? CVFilepath { get; set; }


        public int MainLanguageId { get; set; }
    }
}
