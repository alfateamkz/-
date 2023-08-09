using Alfateam.Models.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Team
{
    public class TeamMember : AbsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImgPath { get; set; }


        [NotMapped]
        public string Slug => SlugHelper.GetLatynSlug($"{Surname} {Name} - {Position}");


        public string Position { get; set; }
        public string ShortExpierence { get; set; }
        public string Quote { get; set; }


        public Content DetailContent { get; set; }
        public string? CVFilepath { get; set; }



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<TeamMemberLocalization> Localizations { get; set; } = new List<TeamMemberLocalization>();



        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (команду)
        /// </summary>
        public int TeamGroupId { get; set; }



        public override bool IsValid()
        {
            var isValid = base.IsValid();

            foreach(var localization in Localizations)
            {
                isValid = localization.IsValid();
            }

            return isValid;
        }
    }
}
